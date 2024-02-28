using System;
using System.Collections.Generic;
using System.Linq;
using Data.ScriptableObjects;
using Signals;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Managers
{
    public class AIManager : MonoBehaviour
    {
        public LevelData _levelData;
      //  public float _spawnPoints;
        public GameObject enemyBasic;
        public GameObject enemyMachin;
        public GameObject enemyGunner;

        public SoldierData BasicEnemyData;
        public SoldierData MachinEnemyData;
        public SoldierData GunnerEnemyData;
        
        public List<GameObject> enemies;
        public List<GameObject> spawnPointX;
        
        public float y, u, v;
        private int _counter;

        private void Start()
        {
            //Debug.Log("spawn");
            int t= Random.Range(0, enemies.Count());
            int z= Random.Range(0, spawnPointX.Count());
            Instantiate(enemies[t], spawnPointX[z].gameObject.transform.position, enemies[t].gameObject.transform.rotation);
            _counter++;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Spawn();
            }
        }
        private void Spawn()
        {
            //  Debug.Log("spawn");
            int t= Random.Range(0, enemies.Count());
            int z= Random.Range(0, spawnPointX.Count());
            Instantiate(enemies[t], spawnPointX[z].gameObject.transform.position, enemies[t].gameObject.transform.rotation);
            _counter++;
        }
        private void ElapsedSpawner()
        {
            //BasicEnemyData.coolDownTime
        }
    }
}