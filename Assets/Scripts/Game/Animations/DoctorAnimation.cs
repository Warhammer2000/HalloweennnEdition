using UnityEngine;

public class DoctorAnimation : MonoBehaviour
{
    [SerializeField] private StackPresenter _playerStack;
    public Animator animator;


    //public void ReturnInfo()
    //{
    //    AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
    //    string nameInfo = stateInfo.IsName("Speed") ? "?" : "&&&";
    //    Debug.Log(nameInfo);
    //}
    private void Awake()
    {
        OnAwake();
        animator = GameObject.Find("armature").GetComponent<Animator>();
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
        if (animator)
            animator.SetFloat(AnimationParams.Speed, normalizedSpeed);
    }
    public void SetWalking(bool walking)
    {
        if (animator) animator.SetBool("walking", walking);
    }
    public void SetGamePad(float speed)
    {
        animator.SetFloat(AnimationParams.GamePad, speed);
    }
    protected virtual void OnAwake() { }

    protected void SetFlying(bool value)
    {
        animator.SetBool(AnimationParams.Flying, value);
    }

    public void UpdateHolding()
    {
        if(_playerStack.Count == 0)
            StopHolding();
        else
            Hold();
    }

    public void StopHolding()
    {
        animator.SetLayerWeight(1, 0f);
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
        animator.SetLayerWeight(1, 1f);
    }


    private static class AnimationParams
    {
        public static readonly string Speed = nameof(Speed);
        public static readonly string GamePad = nameof(GamePad);
        public static readonly string Idle = nameof(Idle);
        public static readonly string Flying = nameof(Flying);
    }
}
