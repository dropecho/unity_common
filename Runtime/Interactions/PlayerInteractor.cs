using UnityEngine;

namespace Dropecho {
  [RequireComponent(typeof(Blackboard))]
  public class PlayerInteractor : MonoBehaviour, Interactor {
    public Blackboard blackboard => GetComponent<Blackboard>();
  }
}