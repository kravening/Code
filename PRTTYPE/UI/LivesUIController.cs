using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesUIController : MonoBehaviour
{
    [SerializeField]
    private HealthController _healthController;

    [SerializeField]
    private Image _healthBart;//muwhahahaha

    [SerializeField]
    private Text _healthText;

    private float _health;

    // Use this for initialization
    void Start()
    {
        _healthText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayHealth();
    }

    void DisplayHealth()
    {
        _health = _healthController.GetHealth();

        _healthText.text = _health.ToString();
        _healthBart.fillAmount = _health * .1f;
    }
}
