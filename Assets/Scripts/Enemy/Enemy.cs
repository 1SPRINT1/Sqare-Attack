using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
   public float speed;
   public int Health = 10;
   private Rigidbody2D rb2d;
   public float force;
   public GameObject effect;
   public AudioSource AU;
   [Header("Reclining")]
   public float recoilDistance = 1f;
   public float recoilDuration = 0.2f;
   public Color flashColor = Color.red;
   public float flashDuration = 0.2f;

   private Vector3 originalPosition;
   private Renderer enemyRenderer;
   private Color originalColor;

   private bool isRecoiling = false;
   private bool isFlashing = false;

   private Vector2 director;

   public Slider HealtSL;
   public GameObject items;
   private int randomNum;
   public GameManager GM;
   
   private void Start()
   {
      originalPosition = transform.position;
      enemyRenderer = GetComponent<Renderer>();
      originalColor = enemyRenderer.material.color;
      rb2d = GetComponent<Rigidbody2D>();
      randomNum = Random.Range(0, 10);
      GM = FindObjectOfType<GameManager>();
   }
   private void Update()
   {
      HealtSL.value = Health;
      if (isFlashing)
      {
         // Мигание цветом
         enemyRenderer.material.color = flashColor;
         Invoke("ResetColor", flashDuration);
      }
      transform.Translate(-speed * Time.deltaTime,0,0);
      if (Health <= 0)
      {
         Destroy(gameObject);
         Instantiate(effect, transform.position, Quaternion.identity);
         GM.EnemyKillCount++;
         if(randomNum >= 8)
         {
            Instantiate(items,transform.position, Quaternion.identity);
         }
      }
      
   }

   public void TakeDamage(int damage,float recilling)
   {
      Health -= damage;
      // Запуск эффекта отдачи и мигания
      // isRecoiling = true;
      isFlashing = true;
      rb2d.velocity = new Vector2(recilling,0);
      AU.Play();
   }
   private void ResetColor()
   {
      // Возврат оригинального цвета
      enemyRenderer.material.color = originalColor;
      isFlashing = false;
   }
}
