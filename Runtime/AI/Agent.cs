using UnityEngine;

namespace Dropecho {
  public class Agent : MonoBehaviour {
    Blackboard _blackboard;
    Wander _wander;
    AISenseVision _vision;
    AILocomotion _locomotion;

    void Start() {
      _locomotion = GetComponent<AILocomotion>();
      _wander = GetComponent<Wander>();
      _blackboard = GetComponent<Blackboard>();
      _vision = GetComponent<AISenseVision>();

    }
    void Update() {
      if (_blackboard.facts.TryGetValue("seen", out float seen)) {
        if (seen > 0) {
          _wander.enabled = false;
          // _locomotion.target = _vision.GetSeen().transform;
        } else {
          // _locomotion.target = null;
          _wander.enabled = true;
        }
      }
    }
  }
}