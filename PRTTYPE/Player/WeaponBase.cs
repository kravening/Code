﻿using UnityEngine;
using System.Collections;
public enum WeaponType
{
    Melee,
    NonAutomatic,
    Automatic,
}
public class WeaponBase : MonoBehaviour {//setting up some base variables for the weapon
    //Weapon Modifiers
    [SerializeField]protected int weaponAmmo;  //ammo of the weapon
    [SerializeField]protected int baseWeaponAmmo;  //ammo of the weapon
    [SerializeField]protected float attackCooldownPeriod; // "attackSpeed" of the weapon
    [SerializeField]protected float reloadTime; // reload time of the weapon
    [SerializeField]protected float attackTimeStamp;
    [SerializeField]protected float reloadTimeStamp;


    [SerializeField]protected bool isAutomatic; // is a weapon automatic or no?
	[SerializeField]protected bool canAttack; // a boolean for the player to see if he can attack, if it's false cooldownperiod starts/counts up till conditions are met and you can attack again.
	[SerializeField]protected bool isReloading;

	protected int weaponModifierArrayIndex;

    public bool isPickup; // if the weapon is a pickup, you can't shoot or do anything with it except for picking it up.
    public bool triggerReleased = true;

    private bool playerFound = true;
}
