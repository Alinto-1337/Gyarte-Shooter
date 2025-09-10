using System;
using GyarteShooter.Input;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerCharacterController : MonoBehaviour, ProjectWideInputActions.IPlayerActions
{
    [Tooltip("The object that will rotate with the mouse")]
    [SerializeField] Transform cameraRotationPivot;

    void Start()
    {
        var inputActions = InputManager.Instance.inputActions;
        inputActions.Player.Move.performed += OnMove;
    }


    void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        
    }

    private void ApplyMovement()
    {
        throw new NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("character move");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
