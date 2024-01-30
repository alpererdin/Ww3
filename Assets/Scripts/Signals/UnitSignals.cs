using Extensions;
using UnityEngine;
using UnityEngine.Events;
namespace Signals 
{
    public class UnitSignals : MonoSingleton<UnitSignals>
    {
        public UnityAction<int,Color,Transform> OnUnitID = delegate {  };
        public UnityAction<int> SetUnitState = delegate {  };
    }
}