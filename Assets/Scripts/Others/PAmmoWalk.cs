using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAmmoWalk : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(-3 * Time.deltaTime,0f,0f);
    }
}
