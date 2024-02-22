using System;
using UnityEngine;

public class GameInput : MonoBehaviour {

    private PlayerInputActions playerInputActions;
    
    public event EventHandler OnFireAction;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Fire.performed += Fire_performed;
    }

    public Vector2 GetMovement() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    public Vector2 GetMousePosition() {
        return Input.mousePosition;
    }

    private void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnFireAction?.Invoke(this, EventArgs.Empty);
    }
}
