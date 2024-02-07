using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
   public float speed;
   private float lifeTime;
   public float startLifeTime;
   public float distance;
   public int damage;
   public int UpDamage;
   public float recilling;
   public LayerMask BulletMask;
   public GameObject effect;

   private void Start()
   {
      lifeTime = startLifeTime;
   }

   private void Update()
   {
      RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, BulletMask);
      if (hitInfo.collider != null)
      {
         if (hitInfo.collider.CompareTag("Enemy"))
         {
            hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage,recilling);
         }

         if (hitInfo.collider.CompareTag("Boss"))
         {
            hitInfo.collider.GetComponent<BossEnemy>().TakeDamageBoss(damage);
         }
         Destroy(gameObject);
         Instantiate(effect, transform.position, Quaternion.identity);
      }
      transform.Translate(Vector2.right * speed * Time.deltaTime);
      lifeTime -= Time.deltaTime;
      if (lifeTime <= 0)
      {
         Destroy(gameObject);
         lifeTime = startLifeTime;
      }
   }
}
