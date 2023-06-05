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

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if(_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = Camera.main.transform.TransformDirection(_inputService.Axis);
                movementVector.z = movementVector.y;
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            characterController.Move(movementSpeed * movementVector * Time.deltaTime);
        }
    }
}