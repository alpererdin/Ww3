using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class ScoreBoardSignals : MonoSingleton<ScoreBoardSignals>
    {
        public UnityAction OnKillEnemy = delegate {  };
        public UnityAction OnUnitDeploy = delegate {  };
        public UnityAction OnUnitLost = delegate {  };
        public UnityAction OnTrenchTaken = delegate {  };
        public UnityAction OnSupportUsed = delegate {  };
        public UnityAction<byte> SetTexts = delegate {  };
        
        public UnityAction OnEnemyKillEnemy = delegate {  };
        public UnityAction OnEnemyUnitDeploy = delegate {  };
        public UnityAction OnEnemyUnitLost = delegate {  };
        public UnityAction OnEnemyTrenchTaken = delegate {  };
        public UnityAction OnEnemySupportUsed = delegate {  };
        
        public UnityAction SetUpgradePoints = delegate {  };
        
        
        public UnityAction ShowPanel = delegate {  };
    }
}