using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    private float i = 2.5f;
    private float incrementPerFrame;
    public Slider _slider;
    public string sceneName;
    void Start()
    {
        incrementPerFrame = 1 / i * Time.deltaTime;
        StartCoroutine(LoadSceneAsync());
       // LevelSignals.Instance.LoadThatScene?.Invoke(4);
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (_slider.value < 1)
            {
                _slider.value += incrementPerFrame;
            }

            if (_slider.value >= 1)
            {
                yield return new WaitForSeconds(4f);
                asyncLoad.allowSceneActivation = true;
                
            }

            yield return null;
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
