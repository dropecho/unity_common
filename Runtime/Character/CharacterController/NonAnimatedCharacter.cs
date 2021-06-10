using MLAPI;
using UnityEngine;

namespace Dropecho {
  public class NonAnimatedCharacter : NetworkBehaviour, ICharacterController {
    [SerializeField] float _moveSpeed = 3;
    [SerializeField] float _turnSpeed = 90;

    public void Crouch() { }
    public void ClampMovement(float modifier) { }

    public void Move(Vector3 move) {
      // if (!IsClient) {
      //   return;
      // }
      move = move.sqrMagnitude > 1 ? move.normalized : move;
      move = transform.InverseTransformDirection(move);
      move = Vector3.ProjectOnPlane(move, Vector3.up);
      var turnAmount = Mathf.Atan2(move.x, Mathf.Abs(move.z));
      var forwardAmount = move.z;

      transform.position += transform.forward * forwardAmount * Time.deltaTime * _moveSpeed;
      transform.rotation *= Quaternion.AngleAxis(turnAmount * Time.deltaTime * _turnSpeed, Vector3.up);
    }
  }
}