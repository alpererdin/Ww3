namespace States
{
    public class UnitStateFactory
    {
        public static MoveState MoveState()
        {
            return new MoveState();
        }

        public static IdleState IdleState()
        {
            return new IdleState();
        } 
        public static FightState FightState()
        {
            return new FightState();
        }  
        public static DeathState DeathState()
        {
            return new DeathState();
        } 
        public static JumpState JumpState()
        {
            return new JumpState();
        }public static JumpedState JumpedState()
        {
            return new JumpedState();
        }
    }
 
}