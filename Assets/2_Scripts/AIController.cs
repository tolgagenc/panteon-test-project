using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform finishPlane;

    Vector3 firstPos;

    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(finishPlane.position);

        firstPos = transform.position;

        GetComponent<Animator>().SetBool("Run", true);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Rotating Plat")
        {
            nav.speed = 100;
        }
        else
        {
            nav.speed = 5;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Last Plane")
        {
            GetComponent<Animator>().SetBool("Run", false);
            GetComponent<NavMeshAgent>().isStopped = true;
            nav.speed = 0;
            gameObject.SetActive(false);
        }
        if (other.tag == "Obstacle")
        {
            transform.position = firstPos;
        }
    }
}
