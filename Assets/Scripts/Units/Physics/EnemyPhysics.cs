using System;
using Signals;
using Units;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemyPhysics : MonoBehaviour
{
    public Transform _quadTransform;
    public int enemyID;
    public GameObject takeDmgParticle;
    public GameObject takeHeadShotParticle;
    public GameObject takeHeadShotTextParticle;
    public GameObject DeadParticle;
    public float enemyHealth;
    public float baseHealth;
    void Start()
    {
        _quadTransform = _quadTransform.transform;
        enemyID = transform.parent.gameObject.GetComponent<EnemySolider>().ID;
        enemyHealth = transform.parent.gameObject.GetComponent<EnemySolider>().Health;
        baseHealth = enemyHealth;
    }
    private void OnParticleCollision(GameObject other)
    {
        float attackDamage=  other.transform.parent.GetComponent<Soldier>().Damage; 
        int a = Random.Range(1, 5);
        if (a==3)
        {
            Instantiate(takeHeadShotParticle, transform.position, quaternion.identity);
            Instantiate(takeHeadShotTextParticle, transform.position+new Vector3(0,1,0), quaternion.identity);
            DeadFunc(attackDamage*2);
        }
        else
        {
            Instantiate(takeDmgParticle, transform.position, quaternion.identity);
            DeadFunc(attackDamage);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            DeadFunc(5);
        }
        if (other.CompareTag("Tank"))
        {
            DeadFunc(10);
        }
    }
    private void DeadFunc(float i)
    {
        enemyHealth -= i;
        float scaledHealth = Mathf.Clamp01((float)enemyHealth/baseHealth); 
        _quadTransform.localScale = new Vector3( scaledHealth, 1, 1);
        //another dmg and dead func+++
        if (enemyHealth <= 0)
        {
            Instantiate(DeadParticle, transform.position, quaternion.identity);
            transform.GetComponent<CapsuleCollider>().isTrigger = true;       //24.02
            UnitSignals.Instance.DeathAnimAction?.Invoke(enemyID);
            Destroy(transform.parent.gameObject,2f);
        }
    }
}
 