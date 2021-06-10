using MLAPI;
using UnityEngine;
using UnityEngine.AI;

namespace Dropecho {
  [RequireComponent(typeof(NavMeshAgent))]
  [RequireComponent(typeof(SimpleThirdPersonCharacter))]
  public class AILocomotionNetwork : NetworkBehaviour {
    public Transform target;
    private NavMeshAgent _agent;
    private SimpleThirdPersonCharacter _char;

    void Start() {
      _char = GetComponent<SimpleThirdPersonCharacter>();
      _agent = GetComponent<NavMeshAgent>();
      _agent.updateRotation = false;
      _agent.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
    }

    void Update() {
      if (!IsHost && !IsServer) {
        return;
      }

      if (_agent.destination != target.position) {
        _agent.SetDestination(target.position);
      }

      if (_agent.remainingDistance > _agent.stoppingDistance) {
        _char.Move(_agent.desiredVelocity);
      } else {
        _char.Move(Vector3.zero);
      }
    }
  }
}