using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class EnemyAISignals: MonoSingleton<EnemyAISignals>
    {
   
        public UnityAction EnemyOnTrench = delegate{};
        public UnityAction<int> EnemyTrenchID= delegate{  };
        
        public UnityAction<byte> SpawnAtIndex = delegate{}; 
        
        public UnityAction<byte> spawnFirstUnit = delegate{};
    }
}