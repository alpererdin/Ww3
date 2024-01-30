using UnityEngine;
namespace Units
{
    public class Soldier : UnitMain
    {
        public int unitSpeed;
        protected override void Awake()
        {
            Speed = unitSpeed;
            BtnColor = Color.blue;
            ID = GetInstanceID();
        }
        private void Update()
        {
            CurrentState?.UpdateState();
        }
    }
}