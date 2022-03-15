using UnityEngine;
using System.Collections;

public class MouseSwitcher : MonoBehaviour {

	void Update()
	{
		if (Input.GetKey (KeyCode.Mouse0)) {
			GetComponent<uMouseLook>().enabled = true;
		} else {
			GetComponent<uMouseLook>().enabled = false;
		}
	}
}
