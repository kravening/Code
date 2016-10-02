using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Image _controlScheme;

    [SerializeField]
    private GameObject _goBackButton;
    
    // Use this for initialization
    void Start()
    {
        _controlScheme.enabled = false;
        _goBackButton.SetActive(false);
    }


    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void HowToPlay()
    {
        _controlScheme.enabled = true;
        _goBackButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoBack()
    {
        _controlScheme.enabled = false;
        _goBackButton.SetActive(false);
    }
}
