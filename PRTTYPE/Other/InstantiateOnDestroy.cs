using UnityEngine;
using System.Collections;

public class InstantiateOnDestroy : MonoBehaviour
{
	[SerializeField]
	private GameObject objectToInstantiate;
	//private float timeStamp;
	//private bool Spawn;

	void Start ()
	{
		//timeStamp = Time.time + 2;
		StartCoroutine(Instantiate());
	}

	/*void Update(){
		if (Time.time >= timeStamp) {
			if(Spawn){
				Instantiate(objectToInstantiate,transform.position,Quaternion.identity);
				timeStamp += 4;
				Spawn = false;
				return;
			}
			Destroy(this.gameObject);
		}
	}*/

	IEnumerator Instantiate(){
		yield return new WaitForSeconds(2);
		Instantiate(objectToInstantiate,transform.position,Quaternion.identity);
		yield return new WaitForSeconds(2);
		Destroy(this.gameObject);
	}
	//Private Functions
	
	
	//Public Functions
}
