using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using UnityEngine;

public class PlaneTest : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;

    private void OnEnable()
    {
        GameSignals.Instance.PlaneAnim += StartToEndFunc;
    }

    private void OnDisable()
    {
        GameSignals.Instance.PlaneAnim -= StartToEndFunc;
        StopAllCoroutines();
    }

    void StartToEndFunc()
    {
        StartCoroutine(MoveObject(startPos.position, endPos.position, 4f)); 
    }

    IEnumerator MoveObject(Vector3 startPos, Vector3 endPos, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPos, endPos, t); 
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos; 
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    
    
}
