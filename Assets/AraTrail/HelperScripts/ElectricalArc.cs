using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ara{
    [RequireComponent(typeof(AraTrail))]
    public class ElectricalArc : MonoBehaviour {
    
        AraTrail trail;
        public Transform source;
        public Transform target;
        
        public int points = 20;
        public float burstInterval = 0.5f;
        public float burstRandom = 0.2f;
        public float speedRandom = 2;
        public float positionRandom = 0.1f;

        private float accum = 0;
    
    	void OnEnable () {
            trail = GetComponent<AraTrail>();
            trail.emit = false;
    	}
    
        void Update(){
    
            accum += Time.deltaTime;
            if (accum >= burstInterval){
                ChangeArc();
                accum = -burstInterval * Random.value * burstRandom;
            }
        }

        void ChangeArc(){

            trail.points.Clear();

            if (source != null && target != null){

                for (int i = 0; i < points; ++i){

                    float t = i/(float)(points-1);
                    float randomWeight = Mathf.Sin(t*Mathf.PI);

                    Vector3 point = Vector3.Lerp(source.position,target.position,t);
                    trail.points.Add(new AraTrail.Point(point + Random.onUnitSphere * positionRandom * randomWeight,
                                                                Random.onUnitSphere * speedRandom * randomWeight,Vector3.up,Vector3.forward,Color.white,1,0,burstInterval*2));
                }

            }
        }
    	
    }
}