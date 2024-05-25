using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /*    public Transform firePoint_Left;
        public Transform firePoint_Right;
        public Transform firePoint_Bottom;
        public Transform firePoint_Top;*/
    public Transform firePoint;
    private Transform firePoint_main = null;
    private bool mouseDown = false;
    private float fireRate = 0.1f; // Seconds between each shot
    private float nextFireTime = 0f;
    public GameObject bulletPrefab;
    public Camera mainCamera; // Assign your main camera
    private bool canShoot;

    private void Update()
    {

/*        if (Input.GetKey(KeyCode.W))
        {
            firePoint_main = firePoint_Top;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            firePoint_main = firePoint_Bottom;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            firePoint_main = firePoint_Right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            firePoint_main = firePoint_Left;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Shoot();
            mouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }*/

        if (Time.time >= nextFireTime)
        {
            // Call the method that should run repeatedly while the mouse is held down
            // Update the next fire time
            nextFireTime = Time.time + fireRate;
            Shoot();
        }

        /*        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.W)) {Shoot(DirectionEnum.TOP); }
                if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.S)) { Shoot(DirectionEnum.BOTTOM); }
                if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.A)) { Shoot(DirectionEnum.LEFT); }
                if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.D)) { Shoot(DirectionEnum.RIGHT); }*/
    }

    IEnumerator DelayedAction(float delayTime)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Code to execute after the delay
        Debug.Log("This message is shown after a delay of " + delayTime + " seconds.");
    }


    void Shoot()
    {
        //Shooting logic
        //StartCoroutine(DelayedAction(100.0f)); // Delay for 2 seconds
        Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
/*        switch (d)
        {
            case DirectionEnum.LEFT:
                Instantiate(bulletPrefab, firePoint_Left.position, firePoint_Left.rotation);
                break;
            case DirectionEnum.RIGHT:
                Instantiate(bulletPrefab, firePoint_Right.position, firePoint_Right.rotation);
                break;
            case DirectionEnum.TOP:
                Instantiate(bulletPrefab, firePoint_Top.position, firePoint_Top.rotation);
                break;
            case DirectionEnum.BOTTOM:
                Instantiate(bulletPrefab, firePoint_Bottom.position, firePoint_Bottom.rotation);
                break;

        }*/

    }
        
}
