using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public GameObject[] shootPoint;
    public Animator AN;
    public Animator cumShake;
    public bool isShoot;
    public GameObject FireSys;
    public AudioSource AU;
    [Header("Timer")] private float timeBTWshoot;
    public float starttimeBTWshoot;
    [Header("Ammo")] public int allAmmo;
    public Text txtAmmo;

    private void Update()
    {
        //RotateGun();
        InputShootGun();
        AN.SetBool("isShoot",isShoot);
        txtAmmo.text = allAmmo.ToString("Ammo: #");
    }

    public void RotateGun()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotateZ + offset);
    }
    public void InputShootGun()
    {
        if (timeBTWshoot <= 0 && allAmmo > 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shootPoint[shootPoint.Length - 1].transform.position, transform.rotation);
                isShoot = true;
                timeBTWshoot = starttimeBTWshoot;
                FireSys.SetActive(true);
                cumShake.SetTrigger("isShake");
                AU.Play();
                allAmmo--;
            }
            else
            {
                isShoot = false;
            }
        }
        else
        {
            timeBTWshoot -= Time.deltaTime;
        }
    }
}
