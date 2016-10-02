using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;


public class CameraEffectsController : MonoBehaviour {

	[SerializeField]private float motionBlurFalloff;
	[SerializeField]private float motionBlurBuildup;
	[SerializeField]private float blurCooldown;
	[SerializeField]private float maxBlurAmount;
	private float blurTimeStamp;
	private bool blurBuildup = false;
	private bool startBlur;
	private bool setBlurCooldown;// set it to the boost cooldown of player
	private bool blurSwitch;
	private MotionBlur motionBlur;

	// Use this for initialization
	void Start () {
		motionBlur = GetComponent<MotionBlur> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(startBlur){ // while this is true, blur the heck out of the screen
			MotionBlurRoutine();

			if(setBlurCooldown){
				blurTimeStamp = Time.time + blurCooldown;
				setBlurCooldown = false;
			}
		}
	}

	private void MotionBlurRoutine(){

		if (blurBuildup) { //adding blur strength
			motionBlur.blurAmount += Time.deltaTime * motionBlurBuildup;
			if(motionBlur.blurAmount >= maxBlurAmount){
				blurBuildup = false;
			}
		} else {// descreasing blur strength
			motionBlur.blurAmount -= Time.deltaTime * motionBlurFalloff;
		}

		if (motionBlur.blurAmount <= 0 && !blurBuildup) { // if not increasing blur and velocity reaches 0 stop routine till triggered again
			motionBlur.blurAmount = 0;
			startBlur = false; //stops running this function in the update
			motionBlur.enabled = false;
		}
	}

	public void startBlurRoutine(){ //works
		if(Time.time >= blurTimeStamp){
			startBlur = true;
			setBlurCooldown = true;
			blurBuildup = true;
			motionBlur.enabled = true;
		}
	}
}
