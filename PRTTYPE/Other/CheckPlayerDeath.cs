using UnityEngine;
using System.Collections;

public class CheckPlayerDeath : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    void Update()
    {
        if (!_player)
        {
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);

        Application.LoadLevel(0);
    }
    
}
