using System;
using Signals;
using Tests;
using UnityEngine;

namespace Managers
{
    public class GameManager: MonoBehaviour
    {
        public int playerUnitsCount;
        private void Awake()
        {
            Application.targetFrameRate = 555;
        }

        private void OnEnable()
        {
            GameSignals.Instance.CreatedPlayerUnit += Counter;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                LevelTests.Instance.NextLvl();
            } 
            /* if (Input.GetKeyDown(KeyCode.N))
            {
                
            }*/
        }
        private void Counter()
        {
            playerUnitsCount++;
            ScoreBoardSignals.Instance.OnUnitDeploy?.Invoke();
        }

        private void OnDisable()
        {
            GameSignals.Instance.CreatedPlayerUnit -= Counter;
        }
    }
}