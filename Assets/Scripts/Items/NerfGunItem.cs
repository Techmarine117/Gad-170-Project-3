using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used while held acts as a physics based projectile instantiator
/// </summary>
public class NerfGunItem : InteractiveItem
{
    public GameObject nerfDartPrefab;
    public Transform nerfDartSpawnLocation;
    public float fireRate = 1;
    public float launchForce = 10;
    protected float fireRateCounter;
    protected override void Start()
    {
        base.Start();
        fireRateCounter = 0;


    }
    // added code which creates a delay for the speed the dart gun shoots



    protected void Update()
    {
        fireRateCounter += Time.deltaTime;

    }

    public override void OnUse()
    {
        base.OnUse();

        if (fireRateCounter >= fireRate)
        {
            fireRateCounter = 0;
            FireNow();
        }

    }
    // instantiated the nerf dart allowing it to shoot and added code to destroy the object (dart) after 5 seconds

    public void FireNow()
    {
        GameObject dart = Instantiate(nerfDartPrefab, nerfDartSpawnLocation.position, Quaternion.identity);
        dart.GetComponent<Rigidbody>().AddForce(transform.forward * launchForce);
        Destroy(dart, 5);

    }
}
