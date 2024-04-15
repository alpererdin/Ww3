using System;
using System.Collections;
using System.Collections.Generic;
using Signals;
using Tests;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SetScene : MonoBehaviour
{
    public List<GameObject> levels;

    public Button TankImage;
    public Image TTTankImage;
 //   public GameObject softPlane;
    
   
  /*  private void OnEnable()
    {
        LevelSignals.Instance.LoadThatScene += load;
    }

    private void OnDisable()
    {
        LevelSignals.Instance.LoadThatScene -= load;
    }

    private void load(int i)
    {
        Debug.Log(i);
    }
    */
  public TextMeshProUGUI lvlText;

  private void Awake()
  {
      LevelTests levelTests = FindObjectOfType<LevelTests>();
      if (levelTests != null)
      {
          int i = levelTests.i;
          GameObject a = levels[i].gameObject;
          Instantiate(a, transform.position, Quaternion.identity);
         // Debug.Log(i);
          lvlText.text = i.ToString();
          if (i>=8)
          {
              TankImage.image.enabled = true;
              TTTankImage.enabled = false;
          }
          else
          {
              TankImage.image.enabled = false;
              TTTankImage.enabled = true;
          }
      }
      /* int i = FindObjectOfType<LevelTests>().i;
    Debug.Log(i);
    GameObject a = levels[i].gameObject;
    Instantiate(a, transform.position, quaternion.identity);*/
      
    }  
    private void Start()
    {
        GameSignals.Instance.TakeCanvasObj?.Invoke();
      
       /* if (QualitySettings.GetQualityLevel() == 0)
        {
            terrain.SetActive(false);
            softPlane.SetActive(true);
        }
        else
        {
            terrain.SetActive(true);
            softPlane.SetActive(false);
        }
        */
      
    }
    
}
