using UnityEngine;
namespace Units
{
    public class Archer : UnitMain
    {
        public int unitSpeed;
        protected override void Awake()
        {
            Speed = unitSpeed;
            BtnColor = Color.red;
            ID = GetInstanceID();
        }
        private void Update()
        {
            CurrentState?.UpdateState();
        }
    }
}