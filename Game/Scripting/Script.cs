using System.Collections.Generic;

namespace cse210_05.Game.Scripting
{
    public class Script
    {
        private Dictionary<string, List<Action>> actions = new Dictionary<string, List<Action>>();

        public Script()
        {
        }

        public void AddAction(string group, Action action)
        {
            if (!actions.ContainsKey(group))
            {
                actions[group] = new List<Action>();
            }

            if (!actions[group].Contains(action))
            {
                actions[group].Add(action);
            }
        }

        public List<Action> GetActions(string group)
        {
            List<Action> results = new List<Action>();
            if (actions.ContainsKey(group))
            {
                results.AddRange(actions[group]);
            }
            return results;
        }

        public void RemoveActor(string group, Action action)
        {
            if (actions.ContainsKey(group))
            {
                actions[group].Remove(action);
            }
        }
    }
}
