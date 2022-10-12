using Zenject;

namespace Code.Player.StateMachine
{
    public sealed class PlayerStateMachine : MonoInstaller
    {
        private IPlayerState _currentState;

        private void Start()
        {
            ChangeState(new IdleState());
        }

        private void Update()
        {
            _currentState?.HandleInput();
            _currentState?.LogicUpdate();
        }

        private void LateUpdate()
        {
            _currentState?.PhysicsUpdate();
        }

        public void ChangeState(IPlayerState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}
