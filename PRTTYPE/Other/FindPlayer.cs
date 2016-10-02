using UnityEngine;
using System.Collections;

public class FindPlayer : MonoBehaviour {
	public GameObject playerObject;
	private void Start(){
		playerObject = GameObject.FindGameObjectWithTag ("Player");
	}

}
