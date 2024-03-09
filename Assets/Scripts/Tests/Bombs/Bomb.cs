using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int _clc = 4;
    public GameObject explosionPrefab; 

    
    public float explosionRadius = 5f;
    public LayerMask enemyLayer;
    public GameObject explosionCollider;
    
    private void Start()
    {
        StartCoroutine(DestroyWithExplosion());
    }

    private IEnumerator DestroyWithExplosion()
    {
        yield return new WaitForSeconds(_clc);
 
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
          
        }
       
        var i =Instantiate(explosionCollider, transform.position, Quaternion.identity);
 
        
        Destroy(i.gameObject,0.1f);
        Destroy(gameObject,0.2f);
       
        
    }
}
