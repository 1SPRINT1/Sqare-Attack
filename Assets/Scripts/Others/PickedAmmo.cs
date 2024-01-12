using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickedAmmo : MonoBehaviour
{
   public int pickelAmmo;
   private Gun gun;
   private float otchet = 10f;

   private void Update()
   {
      gun = FindObjectOfType<Gun>();
      pickelAmmo = Random.Range(1, 31);
      otchet -= Time.deltaTime;
      if (otchet <= 0)
      {
         Destroy(gameObject);
         otchet = 10f;
      }
   }
   public void Pick()
   {
      gun.allAmmo += pickelAmmo;
      Destroy(gameObject);
   }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Pick();
        }
    }
}
