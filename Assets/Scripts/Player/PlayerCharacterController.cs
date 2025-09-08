using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerCharacterController : MonoBehaviour
{
    [Tooltip("The object that will rotate with the mouse")]
    [SerializeField] Transform cameraRotationPivot;

    [SerializeField] InputActionMap playerInputMap;

    void Start()
    {
        
    }


    void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        throw new NotImplementedException();
    }

    private void ApplyMovement()
    {
        throw new NotImplementedException();
    }
}
