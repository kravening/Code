using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour
{
    private GameObject _target;

    private float _moveSpeed = 12;
    private float _speedIncrease = 0.03f;
    private float _maxSpeed = 15;
    [SerializeField]private float _dashMovement = 1f;

    private float _speedIncreaseDelay = 0.1f; 
    private float _minDistance = 2.49f;
    [SerializeField]private float _dashSpeed = 1f;

    [SerializeField]private float _minDisForDash = 10;
    [SerializeField]private float _maxDisForDash = 15;

	[SerializeField]private float dashCooldown;
	[SerializeField]private float dashLength;
	private bool DashRoutine = false;
	private bool dashing = false;
	private float dashTimeStamp;

	private PlayerDistance playerDistance;
	void Start()
    {
		playerDistance = GetComponent<PlayerDistance> ();
		_target = GetComponent<FindPlayer> ().playerObject;
		dashTimeStamp = Time.time + 2f;
        StartCoroutine(GradualSpeedIncrease());
    }

    void Update()
    {
		if (_target != null) {
			transform.LookAt (_target.transform.position);
			//when distance is bigger than
			if (playerDistance.playerDistance >= _minDistance) {
				//move to target
				transform.position += transform.forward * _moveSpeed * Time.deltaTime;//moves over time
				Dash();
			}
		}
    }

	private void Dash(){
		if (Time.time >= dashTimeStamp && dashing == false) {
			dashing = true;
		}
		if (dashing) {
			if(DashRoutine == false){
				DashRoutine = true;
				StartCoroutine(DashTimer());
			} 
			if(DashRoutine == true){
			transform.position += transform.forward * Time.deltaTime * _dashSpeed;
			}
		}
	}

	IEnumerator DashTimer(){
		yield return new WaitForSeconds (dashLength); // stop dashing after this
		dashTimeStamp = Time.time + Random.Range(3f,dashCooldown); // set new time stamp for setting dashing on true again
		dashing = false;
		DashRoutine = false; //coroutine is over, if enemy is dashing again set new cooldown.
	}

    IEnumerator GradualSpeedIncrease()
    {
        while (true)
        {
            _moveSpeed += _speedIncrease;
            yield return new WaitForSeconds(_speedIncreaseDelay);
        }
    }
}
