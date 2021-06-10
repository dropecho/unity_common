using UnityEngine;

namespace Dropecho {
  public interface Interactor {
    public string name { get; }
    public Blackboard blackboard { get; }
  }

  [RequireComponent(typeof(Blackboard))]
  public class PlayerInteractor : MonoBehaviour, Interactor {
    public Blackboard blackboard => GetComponent<Blackboard>();
  }
}