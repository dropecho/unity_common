using System.Collections.Generic;
using UnityEngine;

namespace Dropecho {
  public class Blackboard : MonoBehaviour {
    public Dictionary<string, float> facts = new Dictionary<string, float>();

    public float Get(string key) {
      return facts.ContainsKey(key) ? facts[key] : 0;
    }

    public float Set(string key, float value = 1) {
      return facts[key] = value;
    }
  }
}