using UnityEngine;
using BabyStack.Model;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IModificationListener<float>
{
    [SerializeField] private DoctorAnimation _animation;
    [SerializeField] private Transform _playerModel;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private float _speedRate = 1f;
    private float _flySpeedRate = 1f;
    public float _jumpForce = 10.0f;

    [SerializeField] private InputAction _moveAction;
    [SerializeField] private InputAction _jumpAction;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        _playerModel.LookAt(_playerModel.position + moveDirection);
        _rigidbody.velocity += moveDirection * _speed;
        _animation.SetSpeed(moveDirection.magnitude);
        IsMoving = true;

        if (_jumpAction.triggered)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
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
