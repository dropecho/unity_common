using Dropecho;
using UnityEngine;
using UnityEngine.Events;

namespace Dropecho {
  [AddComponentMenu("Dropecho/Interactions/Interactable")]
  public class Interactable : MonoBehaviour {
    // [SerializeField] UnityEvent onInteractionValid;
    // [SerializeField] UnityEvent onInteractionInvalid;
    // [SerializeField] UnityEvent onInteractionDefocus;
    [SerializeField] InteractionEvent onInteract;

    public void Interact(Interactor interactor) => onInteract?.Invoke(interactor, this);
    public bool CheckInteraction(Interactor interactor) {
      return true;
    }

    // public void Focus(Interactor interactor) {
    //   if (CheckInteraction(interactor)) {
    //     onInteractionValid?.Invoke();
    //   } else {
    //     onInteractionInvalid?.Invoke();
    //   }
    // }

    // public void DeFocus() {
    //   onInteractionDefocus?.Invoke();
    // }
  }
}