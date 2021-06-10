using MLAPI;
using UnityEngine;

namespace Dropecho {
  public class PlayerLocomotionMP : NetworkBehaviour {
    private ICharacterController _char;

    void Start() {
      _char = GetComponent<ICharacterController>();
    }

    void Update() {
      if (!IsLocalPlayer) {
        return;
      }

      var forward = Input.GetAxis("Vertical");
      var sideways = Input.GetAxis("Horizontal");
      // var movement = new Vector3(sideways, 0, forward);
      var movement = transform.TransformDirection(new Vector3(sideways, 0, forward));
      _char.Move(movement);
    }
  }
}