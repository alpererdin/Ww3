using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
namespace Sounds
{
    public class VolumeSettigs : MonoBehaviour
    {
        [SerializeField] private AudioMixer myMixer;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider  sFXSlider;
        private void Start()
        {
            if (PlayerPrefs.HasKey("musicVolume"))
            {
                LoadVolume();
            }
            else
            {
                SetMusicVolume();
                SetSFXVolume();
            }
        }
        public void SetMusicVolume()
        {
            float volume = musicSlider.value;
            myMixer.SetFloat("music", Mathf.Log10(volume) * 20f);
            PlayerPrefs.SetFloat("musicVolume",volume);
        }
        public void SetSFXVolume()
        {
            float volume = sFXSlider.value;
            myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20f);
            PlayerPrefs.SetFloat("SFXVolume",volume);
        }
        public void LoadVolume()
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            sFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            SetMusicVolume();
            SetSFXVolume();
        } 
    }
}