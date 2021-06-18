using System.Collections.Generic;
using UnityEngine;

namespace Dropecho {
 [CreateAssetMenu(menuName = "Dropecho/GameEvent", fileName = "New Game Event")]
  public class GameEvent : ScriptableObject {
    HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

    public void Invoke() { foreach (var listener in _listeners) listener.RaiseEvent(); }
    public void Register(GameEventListener listener) => _listeners.Add(listener);
    public void Deregister(GameEventListener listener) => _listeners.Remove(listener);
  }
}