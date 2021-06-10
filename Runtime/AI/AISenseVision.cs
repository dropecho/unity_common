using UnityEditor;
using UnityEngine;

namespace Dropecho {
  public class AISenseVision : MonoBehaviour {
    [SerializeField] LayerMask _mask;
    [SerializeField] float _radius = 10.0f;
    [SerializeField] float _fov = 90.0f;

    int seen = 0;
    Collider[] _results = new Collider[4];
    float _fovHalf;

    Blackboard _blackboard;

    void Start() {
      _fovHalf = _fov / 2.0f;
      _blackboard = GetComponent<Blackboard>();
    }

    void Update() {
      seen = Physics.OverlapSphereNonAlloc(transform.position, _radius, _results, _mask);

      if (seen > 0) {
        foreach (var c in _results) {
          if (c == null) break;
          var toTargetPlanar = Vector3.ProjectOnPlane(c.transform.position - transform.position, Vector3.up);
          if (Vector3.Angle(transform.forward, toTargetPlanar) < _fovHalf) {
            Debug.Log(c.name);
          } else {
            seen--;
          }
        }
      }

      _blackboard.facts["seen"] = seen;
    }

    public GameObject GetSeen() {
      return _results[0]?.gameObject;
    }

#if UNITY_EDITOR
  static Color visionColor = new Color(0, 1, 0, 0.1f);
  static Color visionColorWithTargets = new Color(1, 0, 0, 0.1f);

  void OnValidate() {
    _fovHalf = _fov / 2.0f;
  }

  //   void OnDrawGizmosSelected() {
  void OnDrawGizmos() {
    Handles.color = seen > 0 ? visionColorWithTargets : visionColor;
    var left = Quaternion.Euler(0, -_fovHalf, 0) * transform.forward;
    Handles.DrawSolidArc(transform.position, Vector3.up, left * _radius, _fov, _radius);
  }
#endif
  }
}