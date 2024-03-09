using System;
using System.Collections;
using System.Collections.Generic;
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
            Destroy(gameObject.transform.parent.gameObject,0.1f);
        }
    }
}
