using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ara;

namespace AraSamples{

[RequireComponent(typeof(AraTrail))]
public class WallPlayerController : MonoBehaviour {

    public float speed = 10;
    public int boardSize = 5;
    public int maxTrailLenght = 10;

    public Color[] colors = new Color[4];

    int coordX = 0;
    int coordZ = 0;

    AraTrail trail;

    void Awake(){
        trail = GetComponent<AraTrail>();
    }
	
	void Update () {

        float delta = Time.deltaTime * speed;

        // get current position and target:
        Vector3 pos = transform.position;
        Vector3 target = new Vector3(coordX,pos.y,coordZ);

        // move towards the target:
        transform.position = Vector3.MoveTowards(pos,target,delta);

        // make sure there's always at least 1 point:
        if (trail.points.Count == 0){
            trail.initialColor = colors[0];
            trail.EmitPoint(pos);
        }

        // if we are at the target, allow the user to input a new direction.
        if (Vector3.Distance(pos,target) < delta){

            transform.position = target;

            // emit a new point every time we move to new coordinates.
            if (Input.GetKey(KeyCode.W)){
                trail.initialColor = colors[0];
                trail.EmitPoint(pos);
                coordX++;
            }else
            if (Input.GetKey(KeyCode.S)){ 
                trail.initialColor = colors[1];
                trail.EmitPoint(pos);
                coordX--;
            }else
            if (Input.GetKey(KeyCode.A)){
                trail.initialColor = colors[2];
                trail.EmitPoint(pos);
                coordZ++;
            }else
            if (Input.GetKey(KeyCode.D)){
                trail.initialColor = colors[3];
                trail.EmitPoint(pos);
                coordZ--;
            }

            // clamp player coordinates so that he doesn't end up outside the board:
            coordX = Mathf.Clamp(coordX,-boardSize,boardSize);
            coordZ = Mathf.Clamp(coordZ,-boardSize,boardSize);
        }

        // Remove excess points once weve reached the limit:
        int excess = Mathf.Max(0,trail.points.Count-maxTrailLenght);
        if (excess > 0){
            // TODO:  implement:
            //trail.points.RemoveRange(0,excess);
        }

	}

}
}
