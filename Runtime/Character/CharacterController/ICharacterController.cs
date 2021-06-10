using UnityEngine;

namespace Dropecho {
  public interface ICharacterController {
    void ClampMovement(float modifier);
    void Move(Vector3 move);
    void Crouch();
  }
}