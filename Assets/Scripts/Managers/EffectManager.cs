using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;

namespace Managers
{
    public class EffectManager : MonoBehaviour
    {
        private AudioSource _thisAS;
        //public AudioClip Sounds;
        public List<AudioClip> Sounds = new List<AudioClip>();
        private void OnEnable()
        {
            GameSignals.Instance.PlayEffect += playOneShotSounds;
        }

        private void playOneShotSounds(int i)
        {
           
            AudioSource.PlayClipAtPoint(Sounds[i],Vector3.zero);
            
        }
        private void OnDisable()
        {
            GameSignals.Instance.PlayEffect -= playOneShotSounds;
        }
    }
}