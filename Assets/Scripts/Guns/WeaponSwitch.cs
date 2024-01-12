using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
   public int wepontCount = 0;
   public GameObject Pistol;
   public GameObject Rifle;
   public GameObject Sniper;
   public GameObject ShotGun;

   private void Update()
   {
      if (wepontCount == 0)
      {
         Pistol.SetActive(true);
         Rifle.SetActive(false);
         Sniper.SetActive(false);
      }
      if (wepontCount == 1)
      {
         Pistol.SetActive(false);
         Rifle.SetActive(true);
         Sniper.SetActive(false);
      }
      if (wepontCount == 2)
      {
         Pistol.SetActive(false);
         Rifle.SetActive(false);
         Sniper.SetActive(true);
      }

      if (wepontCount == 3)
      {
         Pistol.SetActive(false);
         Rifle.SetActive(false);
         Sniper.SetActive(false);
         ShotGun.SetActive(true);
      }
   }

   public void ButtonSelectionUP()
   {
      wepontCount++;
   }

   public void ButtonSelectionDown()
   {
      wepontCount--;
   }
}
