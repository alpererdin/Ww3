using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using UnityEngine;

public class EnemyBulletChecker : MonoBehaviour
{
    public GameObject explosionPrefab, explosionCollider;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Instantiate(explosionCollider, transform.position, Quaternion.identity);
            Destroy(gameObject,0.2f);
            //UnitSignals.Instance.PlaySound?.Invoke(3,transform.position);
            AudioManager.Instance.PlaySFX("bombSmall");
        }
    }
}
