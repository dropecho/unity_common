using UnityEngine;

namespace Dropecho {
  public class FooTrigger : MonoBehaviour {
    public FooEvent _event;

    void OnTriggerEnter() {
      _event.Invoke(8675309);
    }
  }
}