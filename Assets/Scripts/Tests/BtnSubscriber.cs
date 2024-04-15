using System.Collections;
using System.Collections.Generic;
using Tests;
using UnityEngine.UI;
using UnityEngine;

public class BtnSubscriber : MonoBehaviour
{
    
    public Button ThisButton;
    public int lvl;
    private bool ready = false;
    public void LoadLevelOnBtn(int arg)
    {
        AudioManager.Instance.PlaySFX("Click");
        if (arg !=0)
        {
            lvl = arg;
            if (ready)
            {
                LevelTests.Instance.i = lvl; 
            }
           
        }
    }
    void Start()
    {
        LevelTests levelTests = FindObjectOfType<LevelTests>();
        if (levelTests != null)
        {
            ready = true;
        }
        else
        {
            ready = false;
        }
    }
}
