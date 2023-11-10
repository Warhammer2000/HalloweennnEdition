using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Switch;

public class NintendoSwitchController : MonoBehaviour
{
    public PlayerInputScript playerInput;
    private float moveSpeed = 50;
    private float jumpForce = 100f;
    private NPad pad;
    private InputAction inputActionsMove;
    private Rigidbody rb;
    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        playerInput = new PlayerInputScript();

        //playerInput.Player.Enable();
        //playerInput.Player.Move.performed += OnLeftStickMove;

       
        //playerInput.Player.Jump.performed += OnJumpPerformed;
     
        //playerInput.Player.Forward.performed += onForwaedButtonclick;
        //playerInput.Player.Back.performed += onBackButtonclick;
        //playerInput.Player.Left.performed += onLeftButtonclick;
        //playerInput.Player.Right.performed += onRightButtonclick;
    }
    
    private void onForwaedButtonclick(InputAction.CallbackContext context)
    {
        Debug.Log("Fwd");
        transform.Translate(Vector3.forward * moveSpeed);
    }
    private void onBackButtonclick(InputAction.CallbackContext context)
    {
        Debug.Log("BAck");
        transform.Translate(Vector3.back * moveSpeed);
    }
    private void onLeftButtonclick(InputAction.CallbackContext context)
    {
        Debug.Log("Left");
        transform.Translate(Vector3.left * moveSpeed);
    }
    private void onRightButtonclick(InputAction.CallbackContext context)
    {
        Debug.Log("Right");
        transform.Translate(Vector3.right * moveSpeed);
    }
    private void OnLeftStickMove(InputAction.CallbackContext context)
    {

        Vector2 movementInput = context.ReadValue<Vector2>();
        Debug.Log(movementInput);
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        if (movementInput != Vector2.zero)
        {
            Debug.Log("Left stick moved on Nintendo Switch!");
        }
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("juu,,,lpp");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Physics.gravity = new Vector3(0f,-20f,0f);   
    }
    private void OnDisable()
    {
        //playerInput.Player.Move.performed -= OnLeftStickMove;


        //playerInput.Player.Jump.performed -= OnJumpPerformed;

        //playerInput.Player.Forward.performed -= onForwaedButtonclick;
        //playerInput.Player.Back.performed -= onBackButtonclick;
        //playerInput.Player.Left.performed -= onLeftButtonclick;
        //playerInput.Player.Right.performed -= onRightButtonclick;
        //playerInput.Player.Disable();
    }
}
