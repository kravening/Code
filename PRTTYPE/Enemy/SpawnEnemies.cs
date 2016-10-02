using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemies = new GameObject[3];
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private float _spawnDelay;
    [SerializeField]
    private float _minSpawnDistance;

    private float _timeFor2Enemies;
    private float _timeFor3Enemies;

    private float _spawnArea = 31;

	private float _spawnCooldownDecrease = 0.0250f;
	private float _spawnCooldownDecreaseDecrease = 0.0005f;
    void Start()
    {
        _timeFor2Enemies = Time.time + 30;//adds enemy2 after 20 seconds
        _timeFor3Enemies = Time.time + 60;//adds enemy3 after 40 seconds

        StartCoroutine(SpawnEnemy());
    }

    //Private Functions
    private IEnumerator SpawnEnemy()
    {
        while (_player)
        {
            Vector3 playerPos = _player.transform.position;
            Vector3 spawnPos = RandomWorldPoint();
            float distance = Vector3.Distance(playerPos, spawnPos);
            float randomIndex = Random.value;

            if (_minSpawnDistance >= distance)
            {
                spawnPos = RandomWorldPoint();
            }

            //add enemies over time
            if (Time.time > _timeFor2Enemies && Time.time < _timeFor3Enemies)
            {
                GameObject enemyClone = (GameObject)Instantiate(ChosenEnemyFromTwo(randomIndex), spawnPos, Quaternion.identity);
                //spawn 1 of 2 enemies
            }
            else if (Time.time > _timeFor3Enemies)
            {
                //spawn 1 of 3 enemies
                GameObject enemyClone = (GameObject)Instantiate(ChosenEnemyFromThree(randomIndex), spawnPos, Quaternion.identity);
            }
            else
            {
                //spawn only weakest enemy
                GameObject enemyClone = (GameObject)Instantiate(_enemies[0], spawnPos, Quaternion.identity);
            }

            //wait for new spawn
            yield return new WaitForSeconds(_spawnDelay);
			_spawnDelay -= _spawnCooldownDecrease;
			_spawnCooldownDecrease -= _spawnCooldownDecreaseDecrease;
			if(_spawnCooldownDecrease < 0){
				_spawnCooldownDecrease = 0;
			}
        }
    }

    private Vector3 RandomWorldPoint()
    {
        Vector3 randomWorldPoint;
        randomWorldPoint.x = Random.Range(-_spawnArea, _spawnArea);
        randomWorldPoint.y = 1f;
        randomWorldPoint.z = Random.Range(-_spawnArea, _spawnArea);
        return randomWorldPoint;
    }

    private GameObject ChosenEnemyFromTwo(float randomValue)
    {
        if (randomValue < .7)
        {
            return _enemies[0];
        }
        else
        {
            return _enemies[1];
        }
    }

    private GameObject ChosenEnemyFromThree(float randomValue)
    {
        if (randomValue > .5)//50% chance 
        {
            return _enemies[0];
        }
        else if (randomValue > .2 && randomValue < .5)//30% chance
        {
            return _enemies[1];
        }
        else //20% chance
        {
            return _enemies[2];
        }
    }
}
