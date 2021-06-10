using UnityEngine;
using UnityEngine.AI;

namespace Dropecho {
  [RequireComponent(typeof(NavMeshAgent))]
  public class AILocomotion : MonoBehaviour {
    private NavMeshAgent _agent;
    private ICharacterController _char;

    void Start() {
      _char = GetComponent<ICharacterController>();
      _agent = GetComponent<NavMeshAgent>();

      _agent.updatePosition = false;
    }

    void Update() {
      if (_agent.remainingDistance > _agent.stoppingDistance) {
        _char.Move(_agent.desiredVelocity);
      } else {
        _char.Move(Vector3.zero);
      }
    }
  }
}