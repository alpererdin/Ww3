using Extensions;
using UnityEngine;
using UnityEngine.Events;
namespace Signals 
{
    public class UnitSignals : MonoSingleton<UnitSignals>
    {
        public UnityAction<int,Color,Transform,GameObject> OnUnitID = delegate {  };
        public UnityAction<int> SetUnitState = delegate {  };
        
        public UnityAction<int,Vector3> PlaySound =delegate{  };
    }
}