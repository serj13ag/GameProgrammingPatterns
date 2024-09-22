using JetBrains.Annotations;
using UnityEngine;

namespace PatternsExamples.Behavioral.Bytecode.Scripts
{
    public class CharacterLuaProxy
    {
        private readonly Character _character;

        public CharacterLuaProxy(Character character)
        {
            _character = character;
        }

        [UsedImplicitly]
        public int GetCurrentHealth()
        {
            return _character.CurrentHealth;
        }

        [UsedImplicitly]
        public void SetCurrentHealth(int value)
        {
            Debug.Log($"Lua: Setting {_character.Name} current health to {value}");
            _character.SetCurrentHealth(value);
        }
    }
}