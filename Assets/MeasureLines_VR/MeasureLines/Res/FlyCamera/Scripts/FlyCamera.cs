using UnityEngine;
using System.Collections;

public class FlyCamera : MonoBehaviour {

	public float speed= 12.0f;
	public float gravity= 0;
	private Vector3 moveDirection= Vector3.zero;
	public bool Flyfaster;
	private float actspeed;
	
	void  FixedUpdate ()
	{
		//if want to flyfaster
		Flyfaster=false;
		if (Input.GetKey(KeyCode.LeftShift))
		{
			Flyfaster=true;
		};
		if (Flyfaster)
		{
			actspeed=2.5f*speed;
		}
		else
		{
			actspeed=speed;
		};
		//increase / decrease the speed
		if (Input.GetKeyDown (KeyCode.PageUp))
		{
			speed++;
		};
		if (Input.GetKeyDown (KeyCode.PageDown))
		{
			speed--;
		};
		//Up / Down Movement --Space.Self /Space.World
		if (Input.GetKey (KeyCode.Q))
		{
			transform.Translate(new Vector3(0,0.8f,0) * actspeed * Time.deltaTime, Space.World);
		};
		if (Input.GetKey (KeyCode.E))
		{
			transform.Translate(new Vector3(0,-0.8f,0) * actspeed * Time.deltaTime, Space.World);
		};
		// We are grounded, so recalculate movedirection directly from axes
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= actspeed;
		
		// Apply gravity
		moveDirection.y -= gravity * Time.deltaTime;
		//Move
		transform.Translate(moveDirection * Time.deltaTime, Space.World);
		
	}
	
	
}