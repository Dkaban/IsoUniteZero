using UnityEngine;
using Code.Managers;
using Zenject;

namespace Code.Player.StateMachine
{
    public class MoveState : IPlayerState
    {
        [Inject] private IsoWorldManager _isoWorldManager;
        [Inject] private PlayerStateMachine _playerStateMachine;
        private Vector3 _input;
        private PlayerData _playerData;
        private GameObject _playerObject;
        private Rigidbody _rigidbody;
        
        public void Enter()
        {
            _playerObject = _isoWorldManager.PlayerObject;
            _rigidbody = _playerObject.GetComponent<Rigidbody>();
        }

        public void HandleInput()
        {
            _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }

        public void LogicUpdate()
        {
            
        }

        public void PhysicsUpdate()
        {
            PlayerMove();
            PlayerLook();
        }

        private void PlayerMove()
        {
            _rigidbody.MovePosition(_playerObject.transform.position + 
                                    (_playerObject.transform.forward * _input.magnitude) 
                                    * _playerData.movementSpeed * Time.deltaTime);
        }

        private void PlayerLook()
        {
            if (_input == Vector3.zero) return;
            
            var skewedInput = _isoWorldManager.ToIso(_input);
            var relative = (_playerObject.transform.position + skewedInput) - _playerObject.transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            _playerObject.transform.rotation = Quaternion.RotateTowards(
                _playerObject.transform.rotation, rot, _playerData.turnSpeed * Time.deltaTime);
        }

        public void Exit()
        {
            
        }
    }
}
