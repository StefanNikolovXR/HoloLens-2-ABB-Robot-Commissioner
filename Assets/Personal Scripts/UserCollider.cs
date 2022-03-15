using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCollider : MonoBehaviour
{
    public main_ui_control rsmain;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ZoneCollision"))
        {
            rsmain.TaskOnClick_DisconnectBTN();
        }
    }
}
