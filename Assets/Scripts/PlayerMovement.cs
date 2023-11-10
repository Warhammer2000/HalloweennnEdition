using UnityEngine;
using BabyStack.Model;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IModificationListener<float>
{
    [SerializeField] private DoctorAnimation _animation;
    [SerializeField] private Transform _playerModel;
    [SerializeField] private float _speed;

    [SerializeField] private Animator _animator;

    private Rigidbody _rigidbody;
    private float _speedRate = 1f;
    private float _flySpeedRate = 1f;
    public float _jumpForce = 10.0f;

    [SerializeField] private InputAction _moveAction;
    [SerializeField] private InputAction _jumpAction;
    private float teleportHeight = 1.500002f;
    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        CheckHightness();
        Move();
    }
    public void Move()
    {
        _moveAction.Enable();
        _jumpAction.Enable();
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();

        IsMoving = true;
        AnotherMove(moveInput);
        if (_jumpAction.triggered)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
    private void AnotherMove(Vector2 movementInput)
    {


        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);
        _rigidbody.velocity = movement * _speed;
        transform.Translate(movement * _speed * Time.deltaTime);


        if(_jumpAction.triggered) _rigidbody.AddForce(Vector3.up *_speed * 2, ForceMode.Impulse);
        _playerModel.LookAt(_playerModel.position + movement);
        _animation.SetSpeed(movementInput.magnitude);
        if (movement != Vector3.zero)
        {
            Debug.Log("Animation Succesed");
            _rigidbody.isKinematic = false;
            _animation.SetWalking(true);
        }
        IsMoving = true;


        if (movementInput == Vector2.zero)
        {
            _animation.SetWalking(false);
        }
    }
    private void CheckHightness()
    {
        if (transform.position.y > teleportHeight)
        {
            Physics.gravity = new Vector3(default, -500f, default);
           
        }
        else
        {
            Physics.gravity = new Vector3(default, -9.81f, default);
        }
        if(transform.position.y < -teleportHeight)
        {
            transform.position = new Vector3(transform.position.x, teleportHeight, transform.position.z);
        }
    }
    public void MoveJoystick(Vector3 direction)
    {
        //Старый код 
        _playerModel.LookAt(_playerModel.position + direction);
        _rigidbody.velocity = direction * _speed * _speedRate * _flySpeedRate;

        _animation.SetSpeed(direction.magnitude);
        IsMoving = true;
    }


    public void Stop()
    {
        if (_rigidbody != null)
            _rigidbody.velocity = Vector3.zero;



        _animation.SetSpeed(0);
        IsMoving = false;
    }

    public void OnModificationUpdate(float value)
    {
        _speedRate = value;
    }

    public void SetFlySpeedRate(float rate)
    {
        if (rate <= 0)
            throw new System.ArgumentOutOfRangeException(nameof(rate));

        _flySpeedRate = rate;
    }
}
