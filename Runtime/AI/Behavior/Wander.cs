
using UnityEngine;
using UnityEngine.AI;

namespace Dropecho {
  public class Wander : MonoBehaviour {
    [SerializeField] float _fov = 360;
    [SerializeField] float _distance = 3;
    NavMeshAgent _agent;

    void Start() {
      _agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
      if (_agent.remainingDistance <= _agent.stoppingDistance + 1) {
        var angle = Random.Range(-_fov / 2, _fov / 2);
        var direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;
        _agent.destination = transform.position + (direction * _distance);
      }
    }
  }
}