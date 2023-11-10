using UnityEngine;

public class DoctorAnimation : MonoBehaviour
{
    [SerializeField] private StackPresenter _playerStack;
    public Animator animator;
    public bool isEnemy;
    public bool isStanding;

    private void Awake()
    {
        OnAwake();
    }

    private void OnEnable()
    {
        _playerStack.Added += OnAdded;
        _playerStack.BecameEmpty += OnBecameEmpty;
    }

    private void OnDisable()
    {
        _playerStack.Added -= OnAdded;
        _playerStack.BecameEmpty -= OnBecameEmpty;
    }

    public void SetSpeed(float normalizedSpeed)
    {
        if (animator && !isEnemy)
           animator.SetFloat(AnimationParams.Speed, normalizedSpeed);
        
    }
    public void SetCreature(float speed)
    {
        if (animator && isEnemy && !isStanding)
        {
            if (speed > 0 && speed >= 0.1) animator.SetBool("walking", true);
            if (speed < 0.1f || speed < 1f) animator.SetBool("walking", false);
        }
        
    }
    public void SetWalking(bool walking)
    {
        if (animator) animator.SetBool("walking", walking);
    }
    protected virtual void OnAwake() { }

    protected void SetFlying(bool value)
    {
        animator.SetBool(AnimationParams.Flying, value);
    }

    public void UpdateHolding()
    {
        if (_playerStack.Count == 0)
            StopHolding();
        else
        {
            Hold();
        }
    }

    public void StopHolding()
    {
        if (!isEnemy)
        {
            animator.SetLayerWeight(1, 0f);
        }
    }

    public void StartDigging()
    {
        animator.SetBool("isDig", true);
    }

    public void StopDigging()
    {
        animator.SetBool("isDig", false);
    }

    private void OnAdded(Stackable _)
    {
        Hold();
    }

    private void OnBecameEmpty()
    {
        StopHolding();
    }

    private void Hold()
    {
        if (!isEnemy)
        {
            animator.SetLayerWeight(1, 1f);
        }
    }


    private static class AnimationParams
    {
        public static readonly string Speed = nameof(Speed);
        public static readonly string Speedd = nameof(Speedd);
        public static readonly string GamePad = nameof(GamePad);
        public static readonly string Idle = nameof(Idle);
        public static readonly string Flying = nameof(Flying);
    }
}
