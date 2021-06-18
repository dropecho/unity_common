using System;
using System.Collections.Generic;
using System.Linq;
using MLAPI.Messaging;
using UnityEngine;
using UnityEngine.Events;

namespace Dropecho {
  public class GameEventSystem<T, U> : MonoBehaviour where T : GenericGameEvent<T, U> {
    public List<T> RegisteredEvents;
    static Dictionary<T, HashSet<InteractionObserver>> _observers;
    static Dictionary<T, UnityAction<U>> _delegates;

    static GameEventSystem() => Init();
    [RuntimeInitializeOnLoadMethod]
    static void Init() {
      _observers = new Dictionary<T, HashSet<InteractionObserver>>();
      _delegates = new Dictionary<T, UnityAction<U>>();
    }

    void Awake() {
      var events = Resources.FindObjectsOfTypeAll<T>();
    }

    void OnDestroy() {
      var events = Resources.FindObjectsOfTypeAll<T>();
    }
  }
}