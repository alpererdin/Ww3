using System;
using TMPro;
using UnityEngine;

public class AndroidTest : MonoBehaviour
{
    public float updateInterval = 0.5f;

    private float accum = 0;  
    private int frames = 0; 
    private float timeleft;

   [SerializeField] private TextMeshProUGUI pfstext;

   private void Awake()
   {
       Application.targetFrameRate = 555;
   }

   private void Start()
    {
        timeleft = updateInterval;
        
    }

    private void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        frames++;
        
        if (timeleft <= 0.0)
        {
            float fps = accum / frames;
            pfstext.text= string.Format("{0:F2} FPS", fps);
            timeleft = updateInterval;
            accum = 0.0F;
            frames = 0;
        }
    }
}