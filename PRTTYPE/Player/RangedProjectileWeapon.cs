using UnityEngine;
using System.Collections;

public class RangedProjectileWeapon : WeaponBase
{
	private GameObject camera;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject muzzlePosition;
    [SerializeField]
    private float currentAngleOffset;
	[SerializeField]private ParticleSystem muzzleFlash;
	[SerializeField]private ParticleSystem muzzleSmoke;
	[SerializeField]private float weaponShakeStrength;

    // behaviour Modifiers
    [SerializeField]
    private float bulletSpreadAmount;
    [SerializeField]
    private bool multipleProjectiles;
    [SerializeField]
    private int projectileAmount;
    [SerializeField]
    private float BulletSpacing;
    [SerializeField]
    private bool isShotgun;
    // Use this for initialization
    void Start()
    {
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
        ResetAngleOffset();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBools();
    }
    private void CheckBools()
    {
        if (!canAttack && Time.time > attackTimeStamp)                                         //weapon attack cooldown check
        {
            canAttack = true;                                                                  // allows you to "attack"
        }
        if (Time.time > reloadTimeStamp)                                                       //reload cooldown check
        {
            isReloading = false;                                                               // you aren't reloading anymore woohoo!
        }
    }

    private void ReloadSequence()                                                              // reloads the weapon;
    {
			if (weaponAmmo <= 1 && isReloading == false) {                                                // checks if player has any ammo left
				isReloading = true;                                                            // sets bool
				reloadTimeStamp = Time.time + reloadTime;
				weaponAmmo = baseWeaponAmmo;
			}
			// sets time when reload is "done"
    }

    public void Attack()
    {
        if (weaponAmmo >= 1)
        {
            if (!isPickup && !isReloading)
            {
                if (canAttack)
                {
					if (isAutomatic)
                    {
                        Fire();
                    }
                    else
                    {
                        ManualFire();
                    }
                }
            }
        }
        else
        {
            ReloadSequence();                                                                   // reloads weapon for you if you hit 0 while trying to fire
        }
    }

    public void ManualReload()
    {
		if (weaponAmmo != baseWeaponAmmo)                                                       // you can't reload if ammo is full
        {
			weaponAmmo = 0;
        }
        ReloadSequence();
    }

    public void ManualFire()
    {
        if (triggerReleased)
        {
            triggerReleased = false;
            Fire();
        }
    }

    private void Fire()
    {
        if (multipleProjectiles)
        {
			for (int i = 0; i < projectileAmount; i++)
            {
				currentAngleOffset += BulletSpacing; //increases angle for next bullet
                createBullet();
            }
        }
        else
        {
            createBullet();
        }
		MuzzleEffects();
		camera.GetComponent<CameraObjectFollower> ().shakeLength = weaponShakeStrength;
        weaponAmmo--; // enable it later

        // reloads weapon for you if you hit 0 after firing
        if (weaponAmmo <= 0)
        {
            ReloadSequence();
        }
        ResetAngleOffset();
    }
    private void createBullet()
    {
        GameObject pBullet = Instantiate(bullet, muzzlePosition.transform.position, transform.rotation) as GameObject;
        if (multipleProjectiles == true && isShotgun == false)
        {
            pBullet.transform.Rotate(0, currentAngleOffset, 0);
        }
        else
        {
            float randomNumberY = Random.Range(-bulletSpreadAmount, bulletSpreadAmount);
            pBullet.transform.Rotate(0, randomNumberY, 0);
        }
        canAttack = false;
        attackTimeStamp = Time.time + attackCooldownPeriod;
    }


    private void ResetAngleOffset()
    {
        currentAngleOffset = -(((BulletSpacing * projectileAmount) * .5f)+ BulletSpacing/2); //create offset based on total rotation to be made
    }

    private float returnRandom(float min, float max)
    {
        return Random.Range(min, max);
    }

	private void MuzzleEffects(){
		if(muzzleFlash != null){
			GetComponent<AudioSourceController>().ChangeAudioSourceRandom();
            Instantiate(muzzleSmoke, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
		}else{
			Debug.Log("no muzzle reference");
		}
	}


    public int TotalAmmo()
    {
        return baseWeaponAmmo;
    }

    public int CurrentAmmo()
    {
        return weaponAmmo;
    }
	public bool CurrentReloadState(){
		return isReloading;
	}
}
