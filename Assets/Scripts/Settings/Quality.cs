using UnityEngine;
using UnityEngine.UI;

public class Quality : MonoBehaviour
{
    public Button lowBtn;
    public Button mediumBtn;
    public Button highBtn;
    
    void Start()
    {
        int savedQualityLevel = PlayerPrefs.GetInt("QualityLevel", 2); 
        QualitySettings.SetQualityLevel(savedQualityLevel, true);
 
        switch (savedQualityLevel)
        {
            case 0:
                lowBtn.image.color = Color.yellow;
                break;
            case 1:
                mediumBtn.image.color = Color.yellow;
                break;
            case 2:
                highBtn.image.color = Color.yellow;
                break;
            default:
                break;
        }
    }
    //0.06862833,,0.1886792,,0

    public void LowQ()
    {
        QualitySettings.SetQualityLevel(0, true);
        PlayerPrefs.SetInt("QualityLevel", 0);
        PlayerPrefs.Save();
 
        lowBtn.image.color = Color.yellow;
        mediumBtn.image.color = new Color(0.06862833f, 0.1886792f, 0);
        highBtn.image.color = new Color(0.06862833f, 0.1886792f, 0);
    }

    public void MedQ()
    {
        QualitySettings.SetQualityLevel(1, true);
        PlayerPrefs.SetInt("QualityLevel", 1);
        PlayerPrefs.Save();
 
        lowBtn.image.color  = new Color(0.06862833f, 0.1886792f, 0);
        mediumBtn.image.color = Color.yellow;
        highBtn.image.color  = new Color(0.06862833f, 0.1886792f, 0);
    }

    public void HighQ()
    {
        QualitySettings.SetQualityLevel(2, true);
        PlayerPrefs.SetInt("QualityLevel", 2);
        PlayerPrefs.Save();
 
        lowBtn.image.color  = new Color(0.06862833f, 0.1886792f, 0);
        mediumBtn.image.color = new Color(0.06862833f, 0.1886792f, 0);
        highBtn.image.color = Color.yellow;
    }
}