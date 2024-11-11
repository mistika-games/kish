namespace Game.Scripts.Controllers.Interfaces
{
    public interface IInteractableHit
    {
        void InteractWithHit(IInteractionParameters interactionParameters);
    }

    public interface IInteractableCollision
    {
        void InteractWithCollision(IInteractionParameters interactionParameters);
    }
}