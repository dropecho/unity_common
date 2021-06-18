using MLAPI;
using UnityEngine;

namespace Dropecho {
  [RequireComponent(typeof(CharacterController))]
  [RequireComponent(typeof(Animator))]
  public class AnimatorDrivenCharacterController : NetworkBehaviour, ICharacterController {
    [SerializeField] float _movingTurnSpeed = 360;
    [SerializeField] float _stationaryTurnSpeed = 180;
    [SerializeField] float _moveSpeedMultiplier = 1f;
    [SerializeField] float _animSpeedMultiplier = 1f;

    // used for changing between walk and run.
    float _movementModifier = 2f;

    Animator _animator;
    CharacterController _controller;
    float _turnAmount;
    float _forwardAmount;
    Vector3 _groundNormal = Vector3.up;

    float _timeSinceLastInput = 0;

    void Start() {
      _animator = GetComponent<Animator>();
      _controller = GetComponent<CharacterController>();
    }

    void Update() {
      if (!IsLocalPlayer) {
        return;
      }
      if (_timeSinceLastInput > Time.deltaTime * 3) {
        Move(Vector3.zero);
      }
      _timeSinceLastInput += Time.deltaTime;
    }

    public void Move(Vector3 move) {
      _timeSinceLastInput = 0;
      move = transform.InverseTransformDirection(move);
      move = Vector3.ProjectOnPlane(move, _groundNormal);
      move = Vector3.ClampMagnitude(move, _movementModifier);
      _turnAmount = Mathf.Atan2(move.x, move.z);
      _forwardAmount = move.z;

      ApplyExtraTurnRotation();

      // send input and other state parameters to the animator
      UpdateAnimator(move);
    }

    void UpdateAnimator(Vector3 move) {
      // update the animator parameters
      _animator.SetFloat("Forward", _forwardAmount, 0.05f, Time.deltaTime);
      _animator.SetFloat("Turn", _turnAmount, 0.05f, Time.deltaTime);

      // the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
      // which affects the movement speed because of the root motion.
      if (move.magnitude > 0) {
        _animator.speed = _animSpeedMultiplier;
      }
    }

    void ApplyExtraTurnRotation() {
      // help the character turn faster (this is in addition to root rotation in the animation)
      float turnSpeed = Mathf.Lerp(_stationaryTurnSpeed, _movingTurnSpeed, _forwardAmount);
      transform.Rotate(0, _turnAmount * turnSpeed * Time.deltaTime, 0);
    }

    public void OnAnimatorMove() {
      // we implement this function to override the default root motion.
      // this allows us to modify the positional speed before it's applied.
      if (Time.deltaTime > 0) {
        var delta = _animator.deltaPosition * _moveSpeedMultiplier;
        if (_controller.isGrounded == false) {
          delta += Vector3.down * 9.8f * Time.deltaTime;
        }
        _controller.Move(delta);
      }
    }

    public void Crouch() {
      _animator.SetBool("Crouch", !_animator.GetBool("Crouch"));
    }

    public void ClampMovement(float modifier) {
      _movementModifier = modifier;
    }
  }
}