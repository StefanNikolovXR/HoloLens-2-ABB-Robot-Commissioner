using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAnimation : MonoBehaviour {

	Shaper2D shaper2d;

	void Start(){
		//Just sets the window size of the windows application
		Screen.SetResolution(300,300,false);
		//Getting the Shaper2D component
		shaper2d=GetComponent<Shaper2D>();
		//Start the first animation
		//After it finishes it startes the next one and so on
		StartCoroutine(Appear());
	}

	//Expand the arc and rotate
	private IEnumerator Appear(){
		//Setting initial parameters
		shaper2d.innerColor=new Color(0.9f,1f,0.5f);
		shaper2d.outerColor=new Color(1f,0.5f,0.5f);
		shaper2d.sectorCount=35;
		shaper2d.arcDegrees=1;
		shaper2d.rotation=180;
		shaper2d.outerRadius=5;
		shaper2d.innerRadius=3;
		shaper2d.starrines=0;
		//Start animation
		while(shaper2d.arcDegrees<360){
			//Increase arcDegrees and decrease rotation each frame
			shaper2d.arcDegrees+=2;
			shaper2d.rotation-=1f;
			yield return new WaitForEndOfFrame();
		}
		shaper2d.arcDegrees=360;
		//Start the next animation
		StartCoroutine(RadiusChange());
	}

	//Animate inner radius
	private IEnumerator RadiusChange(){
		while(shaper2d.innerRadius>0){
			//Decrease inner radius each frame
			shaper2d.innerRadius-=0.05f;
			yield return new WaitForEndOfFrame();
		}
		shaper2d.innerRadius=0f;
		//Start the next animation
		StartCoroutine(ColorChange());
	}

	//Animate color and starriness parameters
	private IEnumerator ColorChange(){
		Color inner=shaper2d.innerColor;
		Color outer=shaper2d.outerColor;
		for(float i=0f;i<=1;i+=0.02f){
			shaper2d.innerColor=Color.Lerp(inner,new Color(0f,0.5f,1f),i);
			shaper2d.outerColor=Color.Lerp(outer,new Color(0.5f,0.4f,0.6f),i);
			if(i<=0.5f) shaper2d.starrines+=0.005f;
			if(i>0.5f) shaper2d.starrines-=0.005f;
			yield return new WaitForEndOfFrame();
		}
		//Start the next animation
		StartCoroutine(AngleChange());
	}

	//Animate sector count, rotation and size
	private IEnumerator AngleChange(){
		for(int i=0;i<360;i++){
			shaper2d.rotation++;
			//Decrease sector count each 10th
			if(i%10==0 && shaper2d.sectorCount>3){
				shaper2d.sectorCount--;
			}
			yield return new WaitForEndOfFrame();
		}
		//Start the next animation
		StartCoroutine(Disappear());
	}

	//Disappear like a pacman
	private IEnumerator Disappear(){
		for(int i=360;i>0;i--){
			if(i%10==0 && shaper2d.sectorCount<20)shaper2d.sectorCount++;
			shaper2d.arcDegrees-=2;
			shaper2d.rotation+=1f;
			//Stop when ar degrees reach zero
			if(shaper2d.arcDegrees<1) break;
			yield return new WaitForEndOfFrame();
		}
		//Start the first animation again
		StartCoroutine(Appear());
	}

}
