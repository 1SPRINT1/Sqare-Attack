using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossEnemy : MonoBehaviour
{
   [Header("Information-Boss")]
   public float speed = 1f;
   public int Health = Random.Range(70, 450);
   [Space(20)]
   [Header("Mini-Warriors")]
   public GameObject miniWariors;
   public Transform spawnWarriorsPosition;

   private void Update()
   {
     transform.Translate(-speed * Time.deltaTime,0f,0f); 
   }

   public void TakeDamageBoss(int damage)
   {
      Health -= damage;
      StartCoroutine(CreateMiniWarriors());
   }

   IEnumerator CreateMiniWarriors()
   {
      yield return new WaitForSeconds(3f);
      CreateMiniWarriors();
      yield return new WaitForSeconds(3f);
   }

   public void CreateRandomWarrior()
   {
      for (int i = 0; i < Random.Range(1,10); i++)
      {
         Instantiate(miniWariors, transform.position, Quaternion.identity);
      }
   }
}
