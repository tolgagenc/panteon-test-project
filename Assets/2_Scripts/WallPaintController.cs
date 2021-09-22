using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallPaintController : MonoBehaviour
{
    RaycastHit hit;

    int percent = 0;

    public TextMeshProUGUI percentText;
    public TextMeshProUGUI infoText;

    public GameObject panel;
    public Material mat;

    void Start()
    {
        percentText.text = "Painted Wall\n%" + percent.ToString();
    }

    void Update()
    {
        if (Prefrences.isFinish)
        {
            if (!percentText.gameObject.activeInHierarchy)
            {
                percentText.gameObject.SetActive(true);
                infoText.gameObject.SetActive(true);
            }
            if (Input.GetMouseButton(0))
            {
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
        }
        if (percent == 100)
        {
            panel.SetActive(true);
        }
    }

}
