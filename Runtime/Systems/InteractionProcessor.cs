// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Reflection;

// public class InteractionType { }
// public class Interaction {
//   public InteractionType interactionType;
// }

// public class InteractionProcessor {
//   private static Dictionary<InteractionType, Interaction> _interactions = new Dictionary<InteractionType, Interaction>();
//   public static bool _initialized = false;

//   private static void Initialize() {
//     _interactions.Clear();

//     var allInteractionTypes = Assembly.GetAssembly(typeof(Interaction)).GetTypes()
//       .Where(t => typeof(Interaction).IsAssignableFrom(t) && t.IsAbstract == false);

//     foreach (var i in allInteractionTypes) {
//       var interaction = Activator.CreateInstance(i) as Interaction;
//       _interactions.Add(interaction.interactionType, interaction);
//     }
//     _initialized = true;
//   }

//   public void Interact(Interactor actor, Interactable interactable, InteractionType type) {

//   }
// }