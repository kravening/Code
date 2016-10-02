using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
    [SerializeField]
    private GameObject leftWeaponSlot;
    [SerializeField]
    private GameObject rightWeaponSlot;

    public void Attack(string wichWeapon)
    {
        switch (wichWeapon)
        {
            case "leftWeapon":
                leftWeaponSlot.GetComponent<RangedProjectileWeapon>().Attack();
                break;
            case "rightWeapon":
                rightWeaponSlot.GetComponent<RangedProjectileWeapon>().Attack();
                break;
        }
    }
    public void ReleaseTrigger(string wichWeapon)
    {
        switch (wichWeapon){
            case "leftWeapon":
                leftWeaponSlot.GetComponent<RangedProjectileWeapon>().triggerReleased = true;
                break;
            case "rightWeapon":
                rightWeaponSlot.GetComponent<RangedProjectileWeapon>().triggerReleased = true;
                break;
        }
    }

    public void ManualReload(string wichWeapon)
    {
        switch (wichWeapon)
        {
            case "leftWeapon":
                leftWeaponSlot.GetComponent<RangedProjectileWeapon>().ManualReload();
                break;
            case "rightWeapon":
                rightWeaponSlot.GetComponent<RangedProjectileWeapon>().ManualReload();
                break;
        }
    }
}
