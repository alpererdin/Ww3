using Units;

namespace Interfaces
{
    public interface IInteractable
    {
        public void Interaction(UnitMain unit);
        public void KeepInteracting(UnitMain unit);
        public void EndInteraction(UnitMain  unit);
    }
}