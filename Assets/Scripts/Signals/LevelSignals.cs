using System;
using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class LevelSignals  : MonoSingleton<LevelSignals>
    {
      
        public UnityAction<int> OnLevelInitialize = delegate { };
        public UnityAction OnClearActiveLevel = delegate { };
        public UnityAction OnLevelSuccessful = delegate { };
        public UnityAction OnLevelFailed = delegate { };
        public UnityAction OnNextLevel = delegate { };
        public UnityAction OnRestartLevel = delegate { };
        public UnityAction OnPlay = delegate { };
        public UnityAction OnReset = delegate { };
       
        public Func<int> OnGetLevelID = delegate { return 0; };
        
       // public UnityAction<string> LoadThatScene = delegate { };
        public UnityAction<int> LoadThatScene = delegate { };
        
        public UnityAction<int> AddLevelPoints = delegate { };
        public UnityAction<int> DecreaseLevelPoints = delegate { };
        
        public UnityAction OnChangedLevelPoints = delegate { };
      
        
        
    }
}