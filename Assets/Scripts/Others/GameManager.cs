using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   [Header("Kills")]
   public int EnemyKillCount;
   public Text EKCTEXT;
    [Header("Health")]
    public int health;
    public int maxHealth = 3;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
   {
      EKCTEXT.text = EnemyKillCount.ToString("Kill: #");
   }
}
