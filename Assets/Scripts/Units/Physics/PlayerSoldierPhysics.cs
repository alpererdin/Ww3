using Managers;
using Signals;
using Units;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class PlayerSoldierPhysics : MonoBehaviour
{
    public ButtonManager btnManager;
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
        btnManager = FindObjectOfType<ButtonManager>();
        _quadTransform = _quadTransform.transform;  
        playerID = transform.parent.gameObject.GetComponent<Soldier>().ID;
        soldierHealth = transform.parent.gameObject.GetComponent<Soldier>().Health;
        baseHealth = soldierHealth;
    }
    private void OnParticleCollision(GameObject other)
    {
        float attackDamage=  other.transform.parent.GetComponent<EnemySolider>().Damage; 
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
        /*if (other.CompareTag("Tank"))
        {
            DeadFunc(10);
        }*/
    }
    void DeadFunc(float i)
    {
        soldierHealth -= i;
        float scaledHealth = Mathf.Clamp01((float)soldierHealth / baseHealth); 
        _quadTransform.localScale = new Vector3( scaledHealth, 1, 1);
        if (soldierHealth <= 0)
        {
            Instantiate(DeadParticle, transform.position, quaternion.identity);
            transform.GetComponent<CapsuleCollider>().isTrigger = true; 
            UnitSignals.Instance.DeathAnimAction?.Invoke(playerID);
            if (transform.parent.gameObject.GetComponent<Soldier>().onStage == true)
            {
                Destroy(btnManager.idToButtonMap[playerID]);
                btnManager.idToButtonMap.Remove(playerID);
                Destroy(transform.parent.gameObject,2f);
            }
            else
            {
                Destroy(transform.parent.gameObject,2f);
            }
        }
    }
}
