using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using UnityEngine;
public class TankBombTest : MonoBehaviour
{
    
    public GameObject explosionPrefab; 
    public LayerMask enemyLayer;
    public GameObject explosionCollider;
   public Rigidbody rb;
   public float forceMagnitude =15f;
   public bool isAbility;
   private void Awake()
   {
       rb = gameObject.GetComponent<Rigidbody>();
   }
    private void Start()
    { 
        if (rb != null)
        {
            Vector3 forwardForce = transform.forward * forceMagnitude;  
            rb.AddForce(forwardForce, ForceMode.Impulse);
        }
        if (isAbility)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Plane"))
        {
            AudioManager.Instance.PlaySFX("bombSmall");
            //UnitSignals.Instance.PlaySound?.Invoke(3,transform.position);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Instantiate(explosionCollider, transform.position, Quaternion.identity);
            Destroy(gameObject,0.2f);
        }
    }
}