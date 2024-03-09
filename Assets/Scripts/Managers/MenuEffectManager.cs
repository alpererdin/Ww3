using Data.ScriptableObjects;
using Signals;
using UnityEngine;

public class MenuEffectManager : MonoBehaviour
{
    public AudioSource aSource;
    public GameData _data;
    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        aSource.volume = _data.effectValue;
    }
    public void PlayMenuSound()
    {
        aSource.PlayOneShot(aSource.clip);
    }
    private void OnEnable()
    {
        GameSignals.Instance.PlayOneShotEffect += PlayMenuSound;
        GameSignals.Instance.EffectValue += SetValue;
    }
    private void SetValue(float valu)
    {
        aSource.volume = valu;
    }
    private void OnDisable()
    {
        GameSignals.Instance.PlayOneShotEffect-= PlayMenuSound;
        GameSignals.Instance.EffectValue -= SetValue;
    }
}
