using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

    HealthController _hc;

    void Start()
    {
        _hc = GetComponent<HealthController>();
    }

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Enemy")//replace with tag class stuff
		{
            Debug.Log("enemy is touching me");
            _hc.TakeDamage();
		}
	}
}
