using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCollision : MonoBehaviour
{
    public GameObject free, occupied;

    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RobotCollider"))
        {
            free.SetActive(false);
            occupied.SetActive(true);
            print("Collision!");
        }
    }

   /* void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "RobotCollider")
        {
            free.SetActive(true);
            occupied.SetActive(false);
        }
    }*/
}
