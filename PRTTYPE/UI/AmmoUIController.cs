using UnityEngine;
using UnityEngine.UI;

public class AmmoUIController : MonoBehaviour
{

    [SerializeField]
    private Text _ammoText;

    [SerializeField]
    private RangedProjectileWeapon _weapon;


	private int _totalAmmo;

	private int _currentAmmo;


    // Use this for initialization
    void Start()
    {
        _totalAmmo = _weapon.TotalAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        _currentAmmo = _weapon.CurrentAmmo();

        DisplayAmmo();
    }

    void DisplayAmmo()
    {
		if (_weapon.CurrentReloadState() == false) {
			_ammoText.text = _currentAmmo.ToString ();
		} else {
            _ammoText.text = "...";
		}
    }
}
