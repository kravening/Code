using UnityEngine;
using System.Collections;

public class CameraObjectFollower : MonoBehaviour {
    [SerializeField]private Transform target;
    [SerializeField]private float dampeningSpeed;
    [SerializeField]private float cameraHeight; // should be zoomed in if player is in a corridor for le epic effect;
	[SerializeField]private float horMinClamp;// horizontal clamp values
	[SerializeField]private float horMaxClamp;
	[SerializeField]private float verMinClamp;//vertical clamp values
	[SerializeField]private float verMaxClamp;
	[SerializeField]private float shakeFalloff;

	public float shakeLength;
	private bool shake = true;

	private Vector3 clampedCameraPos;
	private float baseDampeningSpeed;

    private float modifiedCameraHeight;

    private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	void Start () {
        modifiedCameraHeight = cameraHeight;
		baseDampeningSpeed = dampeningSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		FollowTarget ();
		Shake();
		transform.position = Vector3.SmoothDamp(transform.position, clampedCameraPos, ref velocity, dampeningSpeed);
	}

	void FollowTarget(){
		if (target)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);//grab target worldPos
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); 
			Vector3 destination = transform.position + delta;
			float xClamp = Mathf.Clamp(destination.x,horMinClamp,horMaxClamp);
			float zClamp = Mathf.Clamp(destination.z,verMinClamp,verMaxClamp);
			clampedCameraPos = new Vector3(xClamp,modifiedCameraHeight,zClamp);
		}
	}

	public void Shake(){
		if (shakeLength > 0) {
			float randomX = clampedCameraPos.x + Random.Range(-shakeLength,shakeLength);
			float randomZ = clampedCameraPos.z + Random.Range(-shakeLength,shakeLength);
			clampedCameraPos = new Vector3(randomX,cameraHeight,randomZ);
			shakeLength -= Time.deltaTime * shakeFalloff;
		} else {
			dampeningSpeed = baseDampeningSpeed;
		}
	}
}
