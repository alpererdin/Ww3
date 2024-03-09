using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTest : MonoBehaviour
{
    public float sensitivity = 5f;
    public float minZ = -20f;
    public float maxZ = 20f;

    private bool duramk=false;
    void LateUpdate()
    {
        if (duramk)
        {
            Vector3 mousePosition = Input.mousePosition;
            float screenWidth = Screen.width;
            float normalizedX = mousePosition.x / screenWidth;
            float currentZ = transform.position.z;
            float moveAmount = sensitivity * Time.deltaTime;
        
            if (normalizedX < 0.07f && currentZ > minZ)
            {
                currentZ -= moveAmount;
            }
            else if (normalizedX > 0.93f && currentZ < maxZ)
            {
                currentZ += moveAmount;
            }
            currentZ = Mathf.Clamp(currentZ, minZ, maxZ);

            transform.position = new Vector3(transform.position.x, transform.position.y, currentZ);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            duramk = !duramk;
       
        }
    }
}