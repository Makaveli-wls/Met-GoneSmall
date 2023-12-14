using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class AutoShot : MonoBehaviour
{
    public float damage = 10f;
    public float fireRate = 15;
    public float range = 100f;
    public int currentAmmo = 1;
    public int maxAmmo = 25;
    public float reloadTime = 2f;
    private bool isReloading = false;

    public Camera fpsCam;
    public TMP_Text ammoDisplay;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;
    
    void Start() 
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }

        ammoDisplay.text = currentAmmo.ToString();

        if (Input.GetKeyDown("r") && (currentAmmo < maxAmmo))
        {
            StartCoroutine(Reload());
            return;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("Reloaded");
    }


    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        currentAmmo--;
        Debug.Log("Ammo: " + currentAmmo);
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range));
        {
            Health enemy = hit.transform.GetComponent<Health>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            
        }
    }
}
