namespace States.EnemyState
{
    public abstract class EnemyBaseState : EnemyStateBase
    {
        public abstract EnemyStateType Type { get; }
        
    }

    public enum EnemyStateType
    {
        None,Move,Idle,Fight,
    }
}