using UnityEngine;
using UnityEngine.Events;

namespace Dropecho {
  public class InteractionEventListener : MonoBehaviour {
    [SerializeField] protected InteractionEvent _gameEvent;
    [SerializeField] protected UnityEvent<InteractionEvent, Interactor, Interactable> _unityEvent;

    void Awake() => _gameEvent.Register(RaiseEvent);
    void OnDestroy() => _gameEvent.Deregister(RaiseEvent);
    public virtual void RaiseEvent(Interactor a, Interactable b) => _unityEvent.Invoke(_gameEvent, a, b);
  }
}