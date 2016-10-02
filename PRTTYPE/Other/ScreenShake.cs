using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {
    private Vector3 centerPos;
    private float timeStamp;
    private float baseShakeStrength;
    [SerializeField]private float shakeLength;
    [SerializeField]private float shakeStrength;
    [SerializeField]private float shakeStrengthReductiontSpeed;
	// Use this for initialization
	void Start () {
        centerPos = transform.position;
        baseShakeStrength = shakeStrength;
        timeStamp = Time.time + shakeLength;
	}
	
	// Update is called once per frame
	void Update () {
        //Shake();
	}

    public void Shake(Vector3 pos)
    {
        if (Time.time <= timeStamp)
        {
            float randomisedPosX = pos.x + Random.Range(-shakeStrength,shakeStrength);
            float randomisedPosZ = pos.z + Random.Range(-shakeStrength,shakeStrength);
            shakeStrength -= Time.deltaTime * shakeStrengthReductiontSpeed;

            Vector3 newShakePos = new Vector3(randomisedPosX,pos.y, randomisedPosZ);
            transform.position = newShakePos;

        }
    }
}
