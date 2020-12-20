using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _project.Scripts
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject
    {
        private PlayerInputActions _gameInput;

        public event UnityAction JumpEvent;
        public event UnityAction CatchEvent;
        public event UnityAction<float> MoveEvent;


        public void OnMove(InputAction.CallbackContext context)
        {
            if (MoveEvent != null)
                MoveEvent.Invoke(context.ReadValue<float>());
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (JumpEvent != null && context.phase == InputActionPhase.Performed)
                JumpEvent.Invoke();
        }

        public void OnCatch(InputAction.CallbackContext context)
        {
            if (JumpEvent != null && context.phase == InputActionPhase.Performed)
                CatchEvent.Invoke();
        }

        #region -Enable/disable-

        private void OnEnable()
        {
            _gameInput = new PlayerInputActions();
            _gameInput.Enable();
        }

        private void OnDisable()
        {
            _gameInput.Disable();
        }

        #endregion
    }
}