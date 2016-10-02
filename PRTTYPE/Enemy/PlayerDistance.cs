using UnityEngine;
using System.Collections;

public class PlayerDistance : MonoBehaviour {
	private GameObject _player;
	public float playerDistance;
	// Use this for initialization
	void Start () {
		_player = GetComponent<FindPlayer> ().playerObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(_player != null)
		playerDistance = Vector3.Distance (transform.position,_player.transform.position);
	}
}
