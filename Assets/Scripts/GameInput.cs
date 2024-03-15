using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private GameIControl gameIControl;
    private void Awake() {
        gameIControl = new GameIControl();
        gameIControl.Player.Enable();

        gameIControl.Player.Interact.performed += Interact_Perform;

    }
    private void Interact_Perform(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this,EventArgs.Empty);
    }
    public Vector3 GetMovementDirectionNormalized()
    {    
        Vector2 inputVector2 = gameIControl.Player.Move.ReadValue<Vector2>();
        // float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(inputVector2.x, 0, inputVector2.y);

        // 考虑单位化处理：斜向移动大于单向
        direction = direction.normalized;

        return direction;
    }
}
