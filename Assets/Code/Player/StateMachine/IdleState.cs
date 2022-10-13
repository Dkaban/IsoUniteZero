using UnityEngine;
using Zenject;

namespace Code.Player.StateMachine
{
    public class IdleState : IPlayerState
    {
        [Inject] private PlayerStateMachine _playerStateMachine;
        
        public void Enter()
        {
            
        }

        public void HandleInput()
        {
            //If a direction is pressed, we want to move the player
            var input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (input.magnitude > 0)
            {
                //We are Moving
                _playerStateMachine.ChangeState(new MoveState());
            }
        }

        public void LogicUpdate()
        {
            
        }

        public void PhysicsUpdate()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}
