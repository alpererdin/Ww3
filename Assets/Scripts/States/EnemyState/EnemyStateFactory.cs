namespace States.EnemyState
{
    public class EnemyStateFactory
    {
        public static EnemyMoveState EnemyMoveState()
        {
            return new EnemyMoveState();
        }

        public static EnemyIdleState EnemyIdleState()
        {
            return new EnemyIdleState();
        }
        public static EnemyFightState EnemyFightState()
        {
            return new EnemyFightState();
        }  
        public static EnemyDeathState EnemyDeathState()
        {
            return new EnemyDeathState();
        } 
        public static EnemyJumpState EnemyJumpState()
        {
            return new EnemyJumpState();
        }
        public static EnemyJumpedState EnemyJumpedState()
        {
            return new EnemyJumpedState();
        }
    }
}