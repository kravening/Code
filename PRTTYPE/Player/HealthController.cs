using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{
    private float _endGameDelay = 1;

	[SerializeField]protected ParticleSystem deathParticles;

    [SerializeField]protected int healthPoints = 10;
    public void TakeDamage()
    {
        healthPoints--;
		if (healthPoints <= 0) {
			Instantiate(deathParticles,transform.position,Quaternion.identity);
            //StartCoroutine(GoToMenu());
            Destroy(this.gameObject);
		}
    }

    /*IEnumerator GoToMenu()
    {
        Destroy(this.gameObject);
        yield return new WaitForSeconds(_endGameDelay);

        //Destroy(this.gameObject);
        Application.LoadLevel(0);
    }*/

    public int GetHealth()
    {
        return healthPoints;
    }
}
