using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ara;

[RequireComponent(typeof(AraTrail))]
public class BakeTrail : MonoBehaviour {

    AraTrail trail;

    void Awake ()
    {
        // grab the trail on awake.
        trail = GetComponent<AraTrail>();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Bake();
	}

    public void Bake()
    {
        // Create a filter/renderer combo. Note this will only work IF THE OBJECT DOES NOT HAVE THEM ALREADY!
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        if (filter != null && meshRenderer != null)
        {
            // Feed a copy of the mesh
            filter.mesh = Instantiate(trail.mesh);

            // Feed the material list.
            meshRenderer.materials = trail.materials;

            // destroy this component, it has no longer any use as the trail has already been baked.
            Destroy(this);

            // destroy the trail:
            Destroy(trail);
        }
        else
            Debug.LogError("[BakeTrail]: Could not bake the trail because the object already had a MeshRenderer.");
    }
}
