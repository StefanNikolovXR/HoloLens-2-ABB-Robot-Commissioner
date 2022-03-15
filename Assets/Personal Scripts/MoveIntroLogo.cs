using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIntroLogo : MonoBehaviour
{
    private float x;
    private Vector3 newpos;
    private float movespeed;
    private bool clicked;

    public void ClickLogo()
    {
        clicked = true;
        x = transform.position.x + 1f;
        movespeed = 2f;
        newpos = new Vector3(x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (clicked) { 
        
        transform.position = Vector3.Lerp(transform.position, newpos, movespeed * Time.deltaTime);
        }
    }

    
}
