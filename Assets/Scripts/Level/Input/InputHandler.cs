using System;
using UnityEngine;

namespace Arkanoid.Level.Input
{
    public class InputHandler : MonoBehaviour
    {
        public Action<Vector2> OnPositionChangedEvent { get; set; }

        [SerializeField] private PlatformControls playerInput;

        private void Awake()
        {
            playerInput = new PlatformControls();
        }

        private void OnEnable()
        {
            playerInput.Enable();
        }

        private void OnDisable()
        {
            playerInput.Disable();
        }

        private void Update()
        {
#if UNITY_EDITOR
            Vector2 position = playerInput.Mouse.Input.ReadValue<Vector2>();
#else
        Vector2 position = playerInput.Touch.Input.ReadValue<Vector2>();
#endif
            OnPositionChangedEvent?.Invoke(position);
        }
    }
}
