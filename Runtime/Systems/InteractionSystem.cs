using System;
using System.Collections.Generic;
using System.Linq;
using MLAPI.Messaging;
using UnityEngine;
using UnityEngine.Events;

namespace Dropecho {
  public class InteractionSystem : MonoBehaviour {
    static Dictionary<InteractionEvent, HashSet<InteractionObserver>> _observers;
    static Dictionary<InteractionEvent, UnityAction<Interactor, Interactable>> _delegates;

    static InteractionSystem() => Init();
    [RuntimeInitializeOnLoadMethod]
    static void Init() {
      _observers = new Dictionary<InteractionEvent, HashSet<InteractionObserver>>();
      _delegates = new Dictionary<InteractionEvent, UnityAction<Interactor, Interactable>>();
    }

    void Awake() {
      var events = Resources.FindObjectsOfTypeAll<InteractionEvent>();
      foreach (var ev in events) {
        var evName = $"On{ev.name}";
        var methodInfo = GetType().GetMethod(evName);
        if (methodInfo == null) {
          Debug.LogWarning($"No method {evName} for event type {ev.name} registered.");
          continue;
        }
        var paramTypes = methodInfo.GetParameters().Select(x => x.ParameterType).ToArray();
        var delegateType = typeof(UnityAction<,>).MakeGenericType(paramTypes);
        var del = Delegate.CreateDelegate(delegateType, null, methodInfo) as UnityAction<Interactor, Interactable>;

        _delegates[ev] = del;
        ev.Register(_delegates[ev]);
      }
    }

    void OnDestroy() {
      var events = Resources.FindObjectsOfTypeAll<InteractionEvent>();

      foreach (var ev in events) {
        if (_observers.ContainsKey(ev)) {
          foreach (var obs in _observers[ev]) {
            ev.Deregister(obs.Observe);
          }
        }
        if (_delegates.ContainsKey(ev)) {
          ev.Deregister(_delegates[ev]);
        }
      }
    }

    public static void RegisterObserver(InteractionEvent ev, InteractionObserver observer) {
      if (!_observers.ContainsKey(ev)) {
        _observers[ev] = new HashSet<InteractionObserver>();
        ev.Register(observer.Observe);
      }

      _observers[ev].Add(observer);
    }

    [ServerRpc]
    public static void OnPickup(Interactor actor, Interactable interactable) {
      Debug.Log($"{actor.name} picked up {interactable.name}");
      Destroy(interactable.gameObject, 0);
    }

    [ServerRpc]
    public static void OnAttack(Interactor actor, Interactable interactable) {
      Debug.Log($"{actor.name} attacked {interactable.name}");
      Destroy(interactable.gameObject, 0);
    }
  }
}