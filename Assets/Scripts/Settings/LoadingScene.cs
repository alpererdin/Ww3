 
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    public TextMeshProUGUI loadingText;

    private int random;
    private void Start()
    {
      
        random = Random.Range(0, 3);
        if (random == 0)
        {
            loadingText.text ="Units gain extra damage in trenches.";
        }else if (random == 1)
        {
            loadingText.text ="Be cautious when calling in for air support.";
        }
        else
        {
            loadingText.text ="The capacity of the trenches is five personnel.";
        }

    }
}
