using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dropecho {
  [CreateAssetMenu(menuName = "Dropecho/InteractionEvent", fileName = "New Game Event")]
  public class InteractionEvent : ScriptableObject {
    HashSet<UnityAction<Interactor, Interactable>> _listeners = new HashSet<UnityAction<Interactor, Interactable>>();

    public void Invoke(Interactor a, Interactable b) {
      foreach (var listener in _listeners) listener.Invoke(a, b);
    }
    public void Register(UnityAction<Interactor, Interactable> listener) => _listeners.Add(listener);
    public void Deregister(UnityAction<Interactor, Interactable> listener) => _listeners.Remove(listener);
  }
}