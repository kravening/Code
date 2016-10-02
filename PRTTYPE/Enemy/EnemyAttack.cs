using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	private GameObject _target;
	private PlayerDistance _playerDistance;

	[SerializeField]private GameObject muzzle;
	[SerializeField]private ParticleSystem attackParticles;

	[SerializeField]private float _attackDelay;
	[SerializeField]private float _attackCooldown;
	[SerializeField]private float _attackRange;
	private float _timeStamp;
	private float _attackDelayTimeStamp;

	void Start () {
		_playerDistance = GetComponent<PlayerDistance> ();
	}
	void Update () {
		if (_target) {
			if (_playerDistance.playerDistance <= _attackRange) {
				if (Time.time >= _timeStamp && Time.time >= _attackDelayTimeStamp) {
					_timeStamp = Time.time + _attackCooldown;
					Instantiate(attackParticles,muzzle.transform.position,muzzle.transform.rotation);
					GetComponent<AudioSourceController>().ChangeAudioSourceByIndex(0);
					_target.GetComponent<HealthController> ().TakeDamage ();

				}
			} else {
				_attackDelayTimeStamp = Time.time + _attackDelay;
			}
		} else {
			_target = GetComponent<FindPlayer> ().playerObject;
		}
	
	}
}
