using MLAPI;
using UnityEngine;
using UnityEngine.AI;

namespace Dropecho {
  [RequireComponent(typeof(NavMeshAgent))]
  public class AILocomotionSimpleNetwork : NetworkBehaviour {
    public Transform target;
    private NavMeshAgent _agent;

    void Start() {
      _agent = GetComponent<NavMeshAgent>();
      _agent.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
    }

    void Update() {
      if (!IsHost && !IsServer) {
        return;
      }

      if (_agent.destination != target.position) {
        _agent.SetDestination(target.position);
      }
    }
  }
}
