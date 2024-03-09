using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;
public class TankTest : MonoBehaviour
{
    public GameObject _Turret;
    public float speed = 0.7f;
    public float rotationSpeed = 1f;  
    public LayerMask enemyLayer;
    private Transform _target;
    public Transform _shootPoint;
    private bool onFight = false;
    public float Health = 99f;
    public float shootDelay;
  // public GameObject explosionPrefab;
    //public GameObject explosionCollider;
    private bool shoot = false;
    private bool Fire = false;

    public GameObject tankBullet;
    private Quaternion rot;
    void Update()
    {
        if (!onFight)
        {
            MoveTankForward();
        }
        CheckForEnemies();
        if (_target != null)
        {
            SmoothLookAt(_target.position);
        }
    }

    private void Start()
    {
        rot = _Turret.transform.rotation;
    }

    void MoveTankForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void CheckForEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 25, enemyLayer);
        if (hitColliders.Length > 0 && _target == null)
        {
            onFight = true;
            int randomIndex = Random.Range(0, hitColliders.Length);
            _target = hitColliders[randomIndex].transform;
        }
        if (hitColliders.Length == 0)
        {
            ResetTurret();
            onFight = false;
        }
    }
    void ResetTurret()
    {
        _Turret.transform.rotation = rot;
    }
    void SmoothLookAt(Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - _Turret.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        _Turret.transform.rotation = Quaternion.Slerp(_Turret.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        if (Quaternion.Angle(_Turret.transform.rotation, targetRotation) < 1f)
        {
            if (!Fire)
            {
                Fire = true;
                StartCoroutine(FireCoroutine());
            }
        }
    }
    private IEnumerator FireCoroutine()
    {
        shoot = false;
        yield return new WaitForSeconds(shootDelay);
        shoot = true;
        if (shoot)
        {
            Debug.Log("ateeees");
            Instantiate(tankBullet, _shootPoint.transform.position, _shootPoint.transform.rotation);
         
        }
        Fire = false;
    }
}