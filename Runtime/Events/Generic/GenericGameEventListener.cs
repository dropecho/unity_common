using UnityEngine;
using UnityEngine.Events;

namespace Dropecho {
  public class GenericGameEventListener<T, U> : MonoBehaviour where T : GenericGameEvent<T, U> {
    [SerializeField] protected T _gameEvent;
    [SerializeField] protected UnityEvent<U> _unityEvent;

    void Awake() => _gameEvent.Register(this);
    void OnDestroy() => _gameEvent.Deregister(this);
    public virtual void RaiseEvent(U eventData) => _unityEvent.Invoke(eventData);
  }
}