using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using UnityEngine;

public class PlayerBulletChecker : MonoBehaviour
{
    public GameObject explosionPrefab, explosionCollider;
   private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Instantiate(explosionCollider, transform.position, Quaternion.identity);
            Destroy(gameObject,0.1f);
           // UnitSignals.Instance.PlaySound?.Invoke(3,transform.position);
           AudioManager.Instance.PlaySFX("bombSmall");
        }
    }
   
}