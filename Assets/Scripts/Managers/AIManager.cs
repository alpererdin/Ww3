using System;
using System.Collections.Generic;
using System.Linq;
using Data.ScriptableObjects;
using Signals;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
namespace Managers
{
    public class AIManager : MonoBehaviour
    {
        public LevelData _levelData;
        public GameObject enemyBasic;
        public GameObject enemyMachin;
        public GameObject enemyGunner;
        public GameObject enemyBomber;
        public SoldierData BasicEnemyData;
        public SoldierData MachinEnemyData;
        public SoldierData GunnerEnemyData;
        public SoldierData BomberEnemyData;
        public List<GameObject> enemies;
        public List<GameObject> spawnPointX;
        private int _counter;
        private GameObject finishLineObj;
        private bool isFirstUnitDeployed;
        private void Start()
        {
            int t= Random.Range(0, enemies.Count());
            int z= Random.Range(0, spawnPointX.Count());
           finishLineObj=GameObject.FindGameObjectWithTag("EnemyFinish");
           if (finishLineObj==null)return;
            Transform firstChild = finishLineObj.transform.GetChild(0);
            int childCount = firstChild.childCount;
           for (int i = 0; i < childCount; i++)
           {
               spawnPointX.Add(firstChild.GetChild(i).gameObject);
           }
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
            ScoreBoardSignals.Instance.OnEnemyUnitDeploy?.Invoke();
        }
        
        private void Spawn(byte arg0)
        {
            int z= Random.Range(0, spawnPointX.Count());
            if (!isFirstUnitDeployed)
            {
                if (arg0==4)
                {
                    Vector3 vec = spawnPointX[arg0].gameObject.transform.position;
                    vec.x = -1;
                    vec.y = 0;
                    Instantiate(enemies[arg0], vec, enemies[arg0].gameObject.transform.rotation);
                    StartCoroutine(TankIEnum());
                }
                else
                {
                    Instantiate(enemies[arg0], spawnPointX[z].gameObject.transform.position, enemies[arg0].gameObject.transform.rotation);
                }

                isFirstUnitDeployed = true;
            }
            else
            {
                int k = Random.Range(0, arg0+1);
                Instantiate(enemies[k], spawnPointX[z].gameObject.transform.position, enemies[k].gameObject.transform.rotation);
            }
          
            _counter++;
            ScoreBoardSignals.Instance.OnEnemyUnitDeploy?.Invoke();
        }

        IEnumerator TankIEnum()
        {
           bool teeest = true;
            while (teeest)
            {
                yield return new WaitForSeconds(55f);
                Vector3 vec = spawnPointX[4].gameObject.transform.position;
                vec.x = -1;
                vec.y = 0;
                Instantiate(enemies[4], vec, enemies[4].gameObject.transform.rotation);
            }
            
        }
     
        private void OnEnable()
        {
            EnemyAISignals.Instance.SpawnAtIndex += Spawn;
        }
        private void OnDisable()
        {
            EnemyAISignals.Instance.SpawnAtIndex -= Spawn;
            StopAllCoroutines();
        }
        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}