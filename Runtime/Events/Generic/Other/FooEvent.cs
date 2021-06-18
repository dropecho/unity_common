using System.Collections.Generic;
using UnityEngine;

namespace Dropecho {
  [CreateAssetMenu(menuName = "Dropecho/Foo Event", fileName = "New Game Event")]
  public class FooEvent : GenericGameEvent<FooEvent, int> {

  }
}
