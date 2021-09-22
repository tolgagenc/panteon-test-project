using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallPaintController : MonoBehaviour
{
    RaycastHit hit;

    public Material mat;

    int percent = 0;

    public TextMeshProUGUI percentText;

    public GameObject panel;

    void Start()
    {
        percentText.text = "Painted Wall\n%" + percent.ToString();
    }

    void Update()
    {
        if (Prefrences.isFinish && Input.GetMouseButton(0))
        {
            if (!percentText.gameObject.activeInHierarchy)
            {
                percentText.gameObject.SetActive(true);
            }

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 53.8f));

            if (Physics.Raycast(Camera.main.transform.position, ray.direction * 10000f, out hit, ray.direction.z * 10000f))
            {
                if (hit.transform.tag == "Paint")
                {
                    hit.transform.gameObject.GetComponent<Renderer>().material = mat;
                    hit.transform.tag = "Painted";
                    percent += 4;
                    percentText.text = "Painted Wall\n%" + percent.ToString();
                }
            }
        }
        if (percent == 100)
        {
            panel.SetActive(true);
        }
    }


}
