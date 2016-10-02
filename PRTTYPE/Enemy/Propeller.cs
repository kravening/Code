using UnityEngine;
using System.Collections;

public class propeller : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * 1440);
	}
	
	//Private Functions
	
	
	//Public Functions
}
