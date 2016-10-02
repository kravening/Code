using UnityEngine;
using System.Collections;

public class FindController : MonoBehaviour {

	private Xbox360Wired_InputController SearchController(){ // searches and returns the controller input
		return GameObject.FindGameObjectWithTag ("Controller").GetComponent<Xbox360Wired_InputController> ();
	}

	public Xbox360Wired_InputController GetController(){
		if (SearchController() != null) {
			return SearchController();
		} else {
			Debug.Log("no controller input was to be found");
			return null;
		}
	}
}
