using UnityEngine;
using System;// needed for serializable
using System.Collections;

/* This script changes Material Main Colors.
	 * Created by OctoMan 2014
	 * Version 1.03
	 * 
	 * Usage:
	 * Drag the Script to any object with a Mesh Render Component.
	 * Assign a Material you like.
	 * Set Switch Colors > Size to at least 2
	 * Choose at least 2 colors you want to cycle through.
	 * Set the interval and other options you need
	 * Done.
	 * 
	 * History of content
	 * 
	 * Version 1.04
	 * - better GUI
	 * - a button to set all intervals at the same time
	 * 
	 * Version 1.03
	 * - Increased flexibility
	 * - every color have it's own interval
	 * - every color can fade to the next color
	 * - you can start with any color in the list(begin with element)
	 * 
	 * Version 1.02
	 * - now Ping Pong is available
	 * 
	 * Version 1.01
	 * New Stuff
	 * - now you can enable and disable it from outside(Inspector) or script based
	 * - now you can reverse the order of from last to first in runtime, but need to wait until the loop in the other direction has ended
	 */

[Serializable]
public class switcher
{
	public bool fadeToNext;//fade for all colors
	public float interval;//interval for all colors
	public Color32 color;//the color itself
}

public class ColorSwitcher: MonoBehaviour 
{
	public bool enable = false;//can enable/ disable the script
	public bool pingPong = false;// loop through colors back and forth
	public bool reverse = false;// reverse the Switcher
	public bool useCurrentAsFirst = false;// Use current main color of the first material in the list as first color on start
	public int beginWithElement = 0;// choose startposition in the array
	public switcher[] switcherElements; //use own class as an array
	
	private int adder = 1;//needed for pingpong
	private int countcolors = 0;//needed for pingpong
	private int tmp;//needed for fading
	
	private bool isRunning = false;// needed for checking if its running or not
	
	void Start () 
	{
		//use current Main as first no matter at which element you start
		if(switcherElements.Length > 0 && useCurrentAsFirst)
			switcherElements[beginWithElement].color = GetComponent<Renderer>().material.color;
		
		//need to check on start if reverse is already on and set the values to reverse correctly
		if (reverse)
		{
			adder = -1;
		}
		else
		{
			adder = 1;
		}
		// clamp begin with element - also clamped in inspector GUI
		beginWithElement = Mathf.Clamp (beginWithElement, 0, switcherElements.Length-1);

		//TODO clamp intervals not smaller than 0


		//set start color
		countcolors = beginWithElement;
	}
	
	void Update()
	{
		if (enable == true)//if enable is active or set to active
			EnableIt();// start the funtion to enable the coroutine
		else
			isRunning = false;//if its not, disable running coroutine
	}
	
	void EnableIt()
	{
		//To Avoid Multithreading
		if(isRunning == false)//check if coroutine isrunning
			StartCoroutine("Switcher");// start the coroutine
	}
	
	//the coroutine
	private IEnumerator Switcher()
	{
		isRunning = true;
		//Debug Part - GUI setup later
		if(switcherElements.Length < 2) //Less than 2 colors choosen
		{
			Debug.Log("<color=red>Fatal error:</color>Choose at least 2 Colors in the ColorSwitcher!"); //when less then 2 color
			enable = false;//disable
		}
		//Debug End
		
		foreach (switcher mycolor in switcherElements)
		{
			Color32 from = switcherElements [countcolors].color;// set start color
			tmp = (countcolors+adder) % switcherElements.Length;//create a local variable to clamp the array length with modulo
			if (tmp<0) {tmp = switcherElements.Length-1;}//if the clamped value is negative, set it to the length of the array -1 (array out of bounds potection) 
			
			//to have to be 1 higher than countcolors except on end
			Color32 to = switcherElements [tmp].color;//set the next color to the clamped value
			
			//Fade Switcher
			if (switcherElements[countcolors].fadeToNext)//if currentcolor has fade option
			{
				float t = 0;//the timer
				while(t <= 1)
				{
					t += Time.deltaTime / switcherElements[countcolors].interval;//increase the time
					for (var i = 0; i < GetComponent<Renderer>().materials.Length; i++) // to support Multi Materials
					{
						GetComponent<Renderer>().materials[i].color = Color32.Lerp(from, to, t);//render the lerped color
					}
					yield return null;
				}
			}
			else
			{//Normal Switcher
				for (var i = 0; i < GetComponent<Renderer>().materials.Length; i++) // to support Multi Materials
				{
					GetComponent<Renderer>().materials[i].color = from;//render the given color
				}
				yield return new WaitForSeconds(switcherElements[countcolors].interval);//wait for the colors interval
			}
			
			countcolors += adder;//go to next the color in positive or negative direction
			
			//Check Reverse while PingPong is off
			if (pingPong == false)
			{
				if (reverse == false)//and reverse is off
				{
					adder = 1;// adder is positive
				}
				else
				{
					adder = -1;//if reverse is on adder is negative 
				}
			}
			
			//Check the Amount and Location of colors
			//while going forwards
			if (countcolors >= switcherElements.Length-1) //if countcolors has the same size of the array (max position) or is higher than that
			{
				if (pingPong) //and if pingpong is on
				{
					adder = -1;//set the adder to negative
					countcolors = switcherElements.Length-1;// and set countcolors 2 steps backward
				}
				if (countcolors >= switcherElements.Length) countcolors = 0;// set it back to 0 to restart
				
			}
			//while going reversed
			if (countcolors <= 0) //if countcolors is negative 
			{
				if (pingPong) //and if pingpong is on
				{
					adder = 1;//set the adder to positive
					countcolors = 0;// and set countcolors 1 step forward
				}
				if (countcolors < 0) countcolors = switcherElements.Length-1;// set it to array length -1(out of bounds protection)
			}
			
			if (enable == false)//stop it instandly if its not enabled, otherwise it would go to the last color in the list
			{
				isRunning = false;// stop coroutine where ever it is - delete this line (or comment out) if you want it go to the end of the color list
				yield break;
			}
			//if(isRunning == false) yield break;
		}
		isRunning = false;// needed to reset
	}
}