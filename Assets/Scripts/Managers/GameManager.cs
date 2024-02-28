using System;
using Signals;
using UnityEngine;

namespace Managers
{
    public class GameManager: MonoBehaviour
    {
        public int playerUnitsCount;
        private void Awake()
        {
            Application.targetFrameRate = 61;
        }

        private void OnEnable()
        {
            GameSignals.Instance.CreatedPlayerUnit += Counter;
        }

        private void Counter()
        {
            playerUnitsCount++;
        }
    }
}