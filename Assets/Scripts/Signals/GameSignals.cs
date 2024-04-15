using Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class GameSignals : MonoSingleton<GameSignals>
    {

        public UnityAction PlayOneShotEffect = delegate { };
        public UnityAction<float> EffectValue = delegate { };
        public UnityAction<float> MusicValue = delegate { };
        public UnityAction CreatedPlayerUnit = delegate { };


        public UnityAction DrawSignal = delegate { };
        public UnityAction<Transform> AddEnemyTransform = delegate { };
        public UnityAction<Transform> AddPlayerTransform = delegate { };


        public UnityAction<Vector3> TargetTankAbility = delegate { };
        public UnityAction<Vector3> TargetPlaneAbility = delegate { };

        public UnityAction PlaneAnim = delegate { };

        public UnityAction<int> PlayEffect = delegate { };
        


        public UnityAction TakeCanvasObj = delegate { };

        //  public UnityAction TankAbilityCoolDown = delegate {  };

        public UnityAction<PlayerDataHandler.PlayerType,PlayerDataHandler.PlayerUpgradeSelection,int,int>
            UpgradePanel = delegate { };

        
        public UnityAction<int> CameraMaxZAmount = delegate { };
    }
}