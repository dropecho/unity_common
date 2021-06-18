using System.Collections.Generic;
using UnityEngine;

namespace Dropecho {
  //  [CreateAssetMenu(menuName = "Dropecho/GameEvent", fileName = "New Game Event")]
  public class GenericGameEvent<T, U> : ScriptableObject where T : GenericGameEvent<T, U> {
    HashSet<GenericGameEventListener<T, U>> _listeners = new HashSet<GenericGameEventListener<T, U>>();

    public void Invoke(U eventData) { foreach (var listener in _listeners) listener.RaiseEvent(eventData); }
    public void Register(GenericGameEventListener<T, U> listener) => _listeners.Add(listener);
    public void Deregister(GenericGameEventListener<T, U> listener) => _listeners.Remove(listener);
  }
}