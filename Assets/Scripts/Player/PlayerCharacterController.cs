using System;
using GyarteShooter.Input;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerCharacterController : MonoBehaviour, ProjectWideInputActions.IPlayerActions
{
    [Tooltip("The Transform that will rotate up and down with the mouse")]
    [SerializeField] Transform cameraXRotationPivot;
    [SerializeField] Vector3 gravity;
    [SerializeField] float walkingSpeed = 1f;
    [SerializeField] float runningSpeed = 1.5f;

    CharacterController characterController;

    Vector2 moveInputVector;

    private float xCameraRotation;

    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        var inputActions = InputManager.Instance.inputActions;
        inputActions.Player.AddCallbacks(this);
    }

    void OnDisable()
    {
        var inputActions = InputManager.Instance.inputActions;
        inputActions.Player.RemoveCallbacks(this);
    }


    void Update()
    {
        velocity = Vector3.zero;

        ApplyGravity();
        ApplyMovement();

        characterController.Move(velocity * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        velocity += gravity;
    }

    private void ApplyMovement()
    {
        
        velocity += Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f) *  new Vector3(moveInputVector.x, 0, moveInputVector.y) * walkingSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInputVector = context.ReadValue<Vector2>();

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        RotateCamera(context.ReadValue<Vector2>());
    }

    void RotateCamera(Vector2 mouseDelta)
    {
        xCameraRotation -= mouseDelta.y;
        xCameraRotation = Mathf.Clamp(xCameraRotation, -90f, 90f);

        // Apply the rotation to the camera
        cameraXRotationPivot.localRotation = Quaternion.Euler(xCameraRotation, 0f, 0f);
        
        // Rotate the player body
        transform.Rotate(Vector3.up * mouseDelta.x);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
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
