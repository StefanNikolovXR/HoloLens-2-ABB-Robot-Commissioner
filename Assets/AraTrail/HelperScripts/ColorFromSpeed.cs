using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ara{

[RequireComponent(typeof(AraTrail))]
public class ColorFromSpeed : MonoBehaviour {

    AraTrail trail;
    
    [Tooltip("Maps trail speed to color. Control how much speed is transferred to the trail by setting inertia > 0. The trail will be colorized even if physics are disabled. ")]
    public Gradient colorFromSpeed = new Gradient();    /**< maps GameObject speed to trail opacity.*/
    [Tooltip("Min speed used to map speed to color.")]
    public float minSpeed = 0;
    [Tooltip("Max speed used to map speed to color.")]
    public float maxSpeed = 5;

	// Use this for initialization
	void OnEnable () {
        trail = GetComponent<AraTrail>();
        trail.onUpdatePoints += SetColorFromSpeed;
	}

    void OnDisable () {
        trail.onUpdatePoints -= SetColorFromSpeed;
    }

    void SetColorFromSpeed(){

        float range = Mathf.Max(AraTrail.epsilon,maxSpeed - minSpeed);

        for (int i = 0; i < trail.points.Count; ++i){
            AraTrail.Point point = trail.points[i];          
            point.color = colorFromSpeed.Evaluate((point.velocity.magnitude - minSpeed) / range);
            trail.points[i] = point;
        }
    }
	
}
}
