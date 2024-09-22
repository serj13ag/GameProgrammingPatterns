using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;

namespace PatternsExamples.Behavioral.Bytecode.Scripts
{
    public class SpellCasterLuaModule
    {
        private const string GetPlayerKey = "GetPlayer";
        private const string GetRandomEnemyKey = "GetRandomEnemy";
        private const string GetEnemiesKey = "GetEnemies";

        private readonly SpellCaster _spellCaster;

        public SpellCasterLuaModule(SpellCaster spellCaster)
        {
            _spellCaster = spellCaster;
        }

        public void SetupVariables(Script script)
        {
            script.Globals[GetPlayerKey] = (Func<Character>)_spellCaster.GetPlayer;
            script.Globals[GetRandomEnemyKey] = (Func<Character>)_spellCaster.GetRandomEnemy;
            script.Globals[GetEnemiesKey] = (Func<List<Character>>)_spellCaster.GetEnemies;
        }

        public void CleanupVariables(Script script)
        {
            script.Globals.Remove(GetPlayerKey);
            script.Globals.Remove(GetRandomEnemyKey);
            script.Globals.Remove(GetEnemiesKey);
        }
    }
}