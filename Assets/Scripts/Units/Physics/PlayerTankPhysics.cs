using Managers;
using Signals;
using Units;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class PlayerTankPyhsics : MonoBehaviour
{
    public int playerID;
    public Transform _quadTransform;
    public GameObject takeDmgParticle;
    public GameObject takeHeadShotParticle;
    public GameObject takeHeadShotTextParticle;
    public GameObject DeadParticle;
    public float soldierHealth;
    public float baseHealth;
    private void Start()
    {
        _quadTransform = _quadTransform.transform;  
        soldierHealth = transform.parent.gameObject.GetComponent<TankTest>().Health;
        baseHealth = soldierHealth;
    }
    private void OnParticleCollision(GameObject other)
    {
        float attackDamage=  other.transform.parent.GetComponent<EnemySolider>().Damage; 
        Instantiate(takeDmgParticle, transform.position, quaternion.identity);
        DeadFunc(attackDamage);
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
    void DeadFunc(float i)
    {
        soldierHealth -= i;
        float scaledHealth = Mathf.Clamp01((float)soldierHealth / baseHealth); 
        _quadTransform.localScale = new Vector3( scaledHealth, 1, 1);
        if (soldierHealth <= 0)
        {
            ScoreBoardSignals.Instance.OnUnitLost?.Invoke();
            Destroy(transform.parent.gameObject,2f);
            Instantiate(DeadParticle, transform.position, quaternion.identity);
            transform.GetComponent<BoxCollider>().isTrigger = true; 
         
        }
    }
}
