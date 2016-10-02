using UnityEngine;
using System.Collections;

public class EnemyCollisionController : MonoBehaviour {

    private EnemyHealthController _enemyHealth;
    private EnemyAttack _enemyAttack;

	void Start ()
    {
        _enemyHealth = GetComponent<EnemyHealthController>();
        _enemyAttack = GetComponent<EnemyAttack>();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bullet") {
            _enemyHealth.TakeDamage();
		}
	}

    /*void OnCollisionEnter(Collision other)
    {
        //attack function here
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("enemy is in attack range!");
            StartCoroutine(_enemyAttack.AttackPlayer());
        }
    }*/
    

	//Private Functions
	
	
	//Public Functions
}
