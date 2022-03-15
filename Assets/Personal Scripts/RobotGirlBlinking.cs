using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGirlBlinking : MonoBehaviour
{

    public Material material1;
    public Material material2;

    float duration = 0.5f;
    public Renderer rend;

    private bool ishovered;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // At start, use the first material
        rend.material = material1;
    }

    public void RobotGirlisHovered()
    {
        ishovered = true;
    }

    public void RobotGirlisNotHovered()
    {
        ishovered = false;
       
    }

    void Update()
    {
        if (ishovered == true) { 

        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.Lerp(material1, material2, lerp);

        }

    }
}

