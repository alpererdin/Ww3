using Units;

namespace States.EnemyState
{
    public abstract class EnemyStateBase
    {
        public abstract void EnterState(EnemyMain enemy);

        public abstract void UpdateState();

        public abstract void FixedUpdate();

        public abstract void ExitState();
    }
}