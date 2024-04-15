using Tests;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public Transform Holder;
    public int wieGehtEsLevels;

    private void Start()
    {
        LevelTests levelTests = FindObjectOfType<LevelTests>();
        wieGehtEsLevels = levelTests != null ? levelTests.maxLevel : 0;
        SetupLevelButtons();
      Invoke("testMusicFnc",.2f);
    }

    private void testMusicFnc()
    {
        AudioManager.Instance.PlayMusic("Theme");
    }
    private void SetupLevelButtons()
    {
        for (int i = 0; i < Holder.childCount; i++)
        {
            var buttonObject = Holder.GetChild(i);
            var buttonComponent = buttonObject.GetComponent<Button>();
            var imageComponent = buttonObject.GetChild(1).GetComponent<Image>();
            var textComponent = buttonObject.GetChild(0).GetComponent<TextMeshProUGUI>();

            var levelButton = new LevelButton(buttonComponent, imageComponent, textComponent);

            if (i < wieGehtEsLevels)
            {
                levelButton.Activate();
            }
            else
            {
                levelButton.Deactivate();
            }
        }
    }
}

public class LevelButton
{
    private Button button;
    private Image image;
    private TextMeshProUGUI text;

    public LevelButton(Button button, Image image, TextMeshProUGUI text)
    {
        this.button = button;
        this.image = image;
        this.text = text;
    }

    public void Activate()
    {
        button.interactable = true;
        image.enabled = false;
        text.enabled = true;
    }

    public void Deactivate()
    {
        button.interactable = false;
        image.enabled = true;
        text.enabled = false;
        
    }
}


