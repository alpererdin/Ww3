using System.Collections;
using System.Collections.Generic;
using Data.ScriptableObjects;
using Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class OptionsPanel : MonoBehaviour
{
    public TextMeshProUGUI sliderMusicTxt;
    public TextMeshProUGUI sliderEffectTxt;
    public Slider sliderMusic;
    public Slider sliderEffect;
    
    
    public GameData _gameData;
    void Start()
    {
        sliderMusic.value = _gameData.musicValue;
        sliderEffect.value = _gameData.effectValue;
        UpdateValueText();
      
    }
    public void EffectSliderValueChanged()
    {
        
        UpdateValueText();
        _gameData.effectValue=sliderEffect.value;
        GameSignals.Instance.EffectValue?.Invoke(sliderEffect.value);
    }
    void UpdateValueText()
    {
        
        sliderMusicTxt.text = (sliderMusic.value * 100).ToString("0");
        sliderEffectTxt.text = (sliderEffect.value * 100).ToString("0");
    }
 
    public void MusicSliderValueChanged()
    {
        
        UpdateValueText();
        _gameData.musicValue=sliderMusic.value;
        GameSignals.Instance.MusicValue?.Invoke(sliderMusic.value);
    }
 
}
