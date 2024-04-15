
using System.Collections;
using Signals;
using UnityEngine;


public class AILevelSetterManager : MonoBehaviour
{
    
    // take data from Scriptable Object *****************

    public int _currentLevel;
    public float enemyLevelDatai;
    public float repeatTime;
    public float LuckAmount;
    public byte EnemyIndex;
    public bool teeest;
    public float Timer;

    private byte current;

    public int maxZ;

    private bool isFirstUnit;
    private void Start()
    {
      //  EnemyIndex = 0;
        teeest = true;
        StartCoroutine(testEnumerator());
        
        //create new class
        GameSignals.Instance.CameraMaxZAmount?.Invoke(maxZ);
        
    }

    IEnumerator testEnumerator()
    {
        while (teeest)
        {
            if (!isFirstUnit)
            {
                yield return new WaitForSeconds(1f);
                isFirstUnit = true;
            }
            else
            {
                yield return new WaitForSeconds(Timer);
            }
            
            EnemyAISignals.Instance.SpawnAtIndex?.Invoke(EnemyIndex);
        
            if (EnemyIndex == 4)
            {
                EnemyIndex--;
            }
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
