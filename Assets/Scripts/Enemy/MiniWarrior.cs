using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class MiniWarrior : MonoBehaviour
{
   [Header("Warrior Information")]
   [SerializeField] private int health = Random.Range(1,5);
   [SerializeField] private float speed = Random.Range(1f,5f);
   [Space(20)]
   [Header("Player-Information")]
   [SerializeField] private Vector3 EnemyPosition;
   private void Update()
   {
      EnemyPosition = GetComponent<Player>().transform.position;
      RotateWarriorGun();
      Vector3.MoveTowards(transform.position, EnemyPosition, speed * Time.deltaTime);
   }

   public void RotateWarriorGun()
   {
      if (EnemyPosition != null)
      {
         Vector3 direction = EnemyPosition - transform.position;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0f, 0f, angle);
      }
   }
   
}
