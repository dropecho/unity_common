using UnityEngine;

namespace Dropecho {
  [AddComponentMenu("Dropecho/Interactions/Interactor")]
  [RequireComponent(typeof(Blackboard))]
  public class Interactor : MonoBehaviour, IInteractor {
    public Blackboard blackboard => GetComponent<Blackboard>();
  }
}