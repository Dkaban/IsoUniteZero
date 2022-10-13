
namespace Code.Player.StateMachine
{
    public interface IPlayerState
    {
        void Enter();
        void HandleInput();
        void LogicUpdate();
        void PhysicsUpdate();
        void Exit();
    }
}