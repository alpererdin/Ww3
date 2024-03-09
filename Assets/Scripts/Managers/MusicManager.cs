using Data.ScriptableObjects;
using Signals;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource aSource;
    public GameData _data;
    private void Awake()
    {
        aSource = transform.GetComponent<AudioSource>();
        aSource.volume = _data.musicValue;
    }
    private void OnEnable()
    {
        GameSignals.Instance.MusicValue += SetValue;
    }
    private void SetValue(float valu)
    {
        aSource.volume = valu;
    }
    private void OnDisable()
    {
        GameSignals.Instance.MusicValue -= SetValue;
    }
   
}
