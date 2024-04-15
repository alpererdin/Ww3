using System;
using Extensions;
using Signals;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class LevelTests : MonoSingleton<LevelTests>
    {
        public int maxLevel;
        public int i;
        public void NextLvl()
        {
            if (i<9)
            {
                i += 1;
            }

            if (maxLevel < 9)
            {
                maxLevel += 1;
            }
           
            PlayerPrefs.SetInt("LastLevel", i);
            PlayerPrefs.SetInt("MaxLevel", maxLevel);
            SceneManager.LoadScene("LoadingScene");
        }
        private void Awake()
        {
         
            if (PlayerPrefs.GetInt("LastLevel")!=0)
            {
             //   i = PlayerPrefs.GetInt("LastLevel");
                 maxLevel = PlayerPrefs.GetInt("MaxLevel", 1);
                 if (i<=maxLevel)
                 {
                     i = maxLevel;
                  //   Debug.Log(i);
                 }
                 
            }
            else
            { 
                i = 1;
            }
              
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }
 
    }
} 