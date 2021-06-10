using Dropecho;
using UnityEngine;

namespace Dropecho {
  public class Interactable : MonoBehaviour {
    [SerializeField] InteractionEvent onInteract;

    public void Interact(Interactor interactor) => onInteract?.Invoke(interactor, this);
    public bool CheckInteraction(Interactor interactor) => true;
  }
}