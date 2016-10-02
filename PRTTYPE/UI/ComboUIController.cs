using UnityEngine;
using UnityEngine.UI;

public class ComboUIController : MonoBehaviour
{

    [SerializeField]
    private Text _comboText;

    [SerializeField]
    private ComboSystem _comboSystem;

    private int _currentCombo;
    private int _highestCombo;

    // Use this for initialization
    void Start()
    {
        _highestCombo = _comboSystem.getHighestCombo();
    }

    // Update is called once per frame
    void Update()
    {
        _currentCombo = _comboSystem.getCurrentCombo();
        _highestCombo = _comboSystem.getHighestCombo();

        DisplayCombo();
    }

    void DisplayCombo()
    {
        _comboText.text =   "Highest Combo: " + _highestCombo.ToString() + "\n" +
                            "Current Combo: " + _currentCombo.ToString();
    }
}
