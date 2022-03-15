using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMaterialInstance : MonoBehaviour
{
    public Material m_Material;

    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        m_Material = GetComponent<Renderer>().material;
    }
}
