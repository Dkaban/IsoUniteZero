using UnityEngine;

namespace Code.Player.StateMachine
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private IPlayerState _currentState;
        [SerializeField] private PlayerData PlayerData;
        
        private void Start()
        {
            ChangeState(new IdleState());
            PlayerData = Resources.Load<PlayerData>("PlayerData");
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
