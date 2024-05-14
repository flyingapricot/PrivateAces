using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint_Left;
    public Transform firePoint_Right;
    public Transform firePoint_Bottom;
    public Transform firePoint_Top;
    public GameObject bulletPrefab;
    private bool canShoot;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.W)) { Shoot(DirectionEnum.TOP); }
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.S)) { Shoot(DirectionEnum.BOTTOM); }
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.A)) { Shoot(DirectionEnum.LEFT); }
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.D)) { Shoot(DirectionEnum.RIGHT); }
    }

    void Shoot(DirectionEnum d)
    {
        Instantiate(bulletPrefab, firePoint_Left.position, firePoint_Left.rotation);
        //Shooting logic
        switch (d)
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

        }

    }
        
}
