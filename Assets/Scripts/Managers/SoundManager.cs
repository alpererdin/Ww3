using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource _thisAS;
        //public AudioClip Sounds;
        public List<AudioClip> Sounds = new List<AudioClip>();
        private void OnEnable()
        {
            UnitSignals.Instance.PlaySound += playOneShotSounds;
        }

        private void playOneShotSounds(int i,Vector3 t)
        {
           
            AudioSource.PlayClipAtPoint(Sounds[i],t);
            
        }
        private void OnDisable()
        {
            UnitSignals.Instance.PlaySound -= playOneShotSounds;
        }
    }
}