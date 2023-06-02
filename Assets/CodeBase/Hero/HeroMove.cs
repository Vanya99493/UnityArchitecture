using Assets.CodeBase.CameraLogic;
using Assets.CodeBase.Infrastructure;
using Assets.CodeBase.Services.Input;
using UnityEngine;

namespace Assets.CodeBase.Hero
{
    public class HeroMove : MonoBehaviour
    {
        public CharacterController characterController;
        public float movementSpeed;

        private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Start()
        {
            _camera = Camera.main;
            CameraFollow();
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if(_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.z = movementVector.y;
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            characterController.Move(movementSpeed * movementVector * Time.deltaTime);
        }

        private void CameraFollow() => 
            _camera.GetComponent<CameraFollow>().Follow(gameObject);
    }
}