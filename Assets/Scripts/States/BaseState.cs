namespace States
{
    public abstract class BaseState : StateBase
    {
        public abstract UnitStateType Type { get; }
        
    }

    public enum UnitStateType
    {
        None,Move,Idle,Fight,
    }
}