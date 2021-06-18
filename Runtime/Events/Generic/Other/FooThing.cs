using UnityEngine;

namespace Dropecho {
  public class FooThing : MonoBehaviour {
    public void SomethingTakingAnInt(int bar) {
      Debug.Log("You called me with: " + bar);
    }
  }
}