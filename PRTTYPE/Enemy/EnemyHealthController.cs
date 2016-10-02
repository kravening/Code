using UnityEngine;
using System.Collections;

public class EnemyHealthController : HealthController {
	private GameObject player;
	private bool once = true;
	private void Start(){
		player = GetComponent<FindPlayer> ().playerObject;
	}
	public void TakeDamage()
	{
		healthPoints--;
		if (healthPoints <= 0) {
			if(once){
				once = false;
				Instantiate(deathParticles,transform.position,Quaternion.identity);
				player.GetComponent<ComboSystem>().IncreaseCombo();
				GetComponent<ChildDecoupler>().DeCoupler();
			}
			Destroy(this.gameObject);
		}
	}
	//Private Functions
	
	
	//Public Functions
}
