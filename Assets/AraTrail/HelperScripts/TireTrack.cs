using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ara{

[RequireComponent(typeof(AraTrail))]
public class TireTrack : MonoBehaviour {

    AraTrail trail;
    public float offset = 0.05f;
    public float maxDist = 0.1f;

    // Use this for initialization
    void OnEnable () {
        trail = GetComponent<AraTrail>();
        trail.onUpdatePoints += ProjectToGround;
    }

    void OnDisable () {
        trail.onUpdatePoints -= ProjectToGround;
    }

    void ProjectToGround(){
           
        RaycastHit hit;

        if (Physics.Raycast(new Ray(transform.position,-Vector3.up),out hit,maxDist)){

            if (trail.emit && trail.points.Count > 0){
                AraTrail.Point point = trail.points[trail.points.Count-1];   
                if (!point.discontinuous){
                    point.normal = hit.normal;
                    point.position = hit.point + hit.normal * offset;
                    trail.points[trail.points.Count-1] = point;
                }
            }

            trail.emit = true;

        }else if (trail.emit){
            // stop emitting trail when too far from the ground.
            trail.emit = false;

            // delete the last point, as it probably didn't have a chance to be projected to the ground.
            if (trail.points.Count > 0)
                trail.points.RemoveAt(trail.points.Count-1);
         
        }

    }
    
}
}

