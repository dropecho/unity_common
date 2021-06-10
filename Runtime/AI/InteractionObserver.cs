using UnityEngine;

namespace Dropecho {
  public class InteractionObserver : MonoBehaviour {
    [SerializeField] InteractionEvent _event;

    void Start() => InteractionSystem.RegisterObserver(_event, this);

    public virtual void Observe(Interactor interactor, Interactable interactable) {
      // Debug.Log($"{name} saw {interactor.name} pick up {interactable.name}");
    }
  }
}