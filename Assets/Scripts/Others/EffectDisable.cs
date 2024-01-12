using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EffectDisable : MonoBehaviour
{
   public GameObject obj;
   public void DisableEffect()
   {
      obj.SetActive(false);
   } 
}
