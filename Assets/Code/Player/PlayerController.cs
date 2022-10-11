using Code.Managers;
using UnityEngine;
using Zenject;

namespace Code.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidBody;
        [Inject] private IsoWorldManager _isoWorldManager;
        private Vector3 _input;
        private PlayerData _playerData;

        private void Awake()
        {
            _playerData = Resources.Load<PlayerData>("PlayerData");
        }

        private void Update()
        {
            GatherInput();
            Look();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void GatherInput()
        {
            _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }

        private void Look()
        {
            if (_input == Vector3.zero) return;
            
            var skewedInput = _isoWorldManager.ToIso(_input);
            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _playerData.turnSpeed * Time.deltaTime);
        }

        private void Move()
        {
            _rigidBody.MovePosition(
                transform.position + (transform.forward * _input.magnitude) 
                * _playerData.movementSpeed * Time.deltaTime);
        }
    }
}
