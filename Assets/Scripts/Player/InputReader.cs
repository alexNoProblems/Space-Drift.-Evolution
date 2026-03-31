using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
   [SerializeField] private Joystick _joystick;
   
   private InputSystem_Actions _inputActions;

   public event Action<Vector2> MoveChanged;

   private void Awake()
   {
      _inputActions = new InputSystem_Actions();
      
      _inputActions.Player.Move.performed += OnMovePerformed;
      _inputActions.Player.Move.canceled += OnMoveCanceled;
   }

   private void OnEnable()
   {
      _inputActions.Player.Enable();
   }

   private void OnDisable()
   {
      _inputActions.Player.Disable();
   }

   private void Update()
   {
      if (_joystick != null)
         ProcessInput(_joystick.Direction);
   }

   private void OnDestroy()
   {
      _inputActions.Player.Move.performed -= OnMovePerformed;
      _inputActions.Player.Move.canceled -= OnMoveCanceled;
      
      _inputActions.Dispose();
   }

   private void OnMovePerformed(InputAction.CallbackContext context)
   {
      ProcessInput(context.ReadValue<Vector2>());
   }

   private void OnMoveCanceled(InputAction.CallbackContext context)
   {
      MoveChanged?.Invoke(Vector2.zero);
   }

   private void ProcessInput(Vector2 input)
   {
      if (input.magnitude < 0.2f)
      {
         MoveChanged?.Invoke(Vector2.zero);
         
         return;
      }
      
      MoveChanged?.Invoke(input.normalized);
   }
}
