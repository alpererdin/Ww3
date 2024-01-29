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
    }
 
}