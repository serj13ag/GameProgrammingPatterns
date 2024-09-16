using System;

namespace PatternsExamples.Creational.Prototype.Scripts
{
    [Serializable]
    public class MonsterModel
    {
        public string Name;
        public int MinHealth;
        public int MaxHealth;
        public string[] Resists;
        public string[] Weaknesses;

        public string PrototypeName;

        public void CopyFromPrototype(MonsterModel prototype)
        {
            if (MinHealth == default)
            {
                MinHealth = prototype.MinHealth;
            }

            if (MaxHealth == default)
            {
                MaxHealth = prototype.MaxHealth;
            }

            Resists ??= prototype.Resists;
            Weaknesses ??= prototype.Weaknesses;
        }
    }
}