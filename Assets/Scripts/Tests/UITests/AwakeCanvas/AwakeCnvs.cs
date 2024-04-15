using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AwakeCnvs : MonoBehaviour
{
    public Image imgPanel;
    private void Awake()
    {
        imgPanel.enabled = true;
    }

    void Start()
    {
        StartCoroutine(PanelDarkness());
        
    }

    IEnumerator PanelDarkness()
    {
        float duration = 1f;
        float elapsedTime = 0f;

        Color startColor = imgPanel.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < duration)
        {
            imgPanel.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            if (Time.timeScale == 0)
                yield break;
            yield return null;
        }

        imgPanel.color = targetColor;
        imgPanel.enabled = false;
       // Destroy(gameObject);
       
        
    }
    
    private void OnApplicationQuit()
    {
        StopCoroutine(PanelDarkness());
    }

    void OnDisable()
    {
        StopCoroutine(PanelDarkness());
    }

    private void OnDestroy()
    {
        StopCoroutine(PanelDarkness());
    }
}