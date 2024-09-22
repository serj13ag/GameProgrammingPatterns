using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using MoonSharp.Interpreter;
using Random = UnityEngine.Random;

namespace PatternsExamples.Behavioral.Bytecode.Scripts
{
    public class SpellCaster : MonoBehaviour
    {
        [SerializeField] private Character _player;
        [SerializeField] private List<Character> _enemies;

        [SerializeField] private string _qSpellScriptName;
        [SerializeField] private string _wSpellScriptName;
        [SerializeField] private string _eSpellScriptName;
        [SerializeField] private string _rSpellScriptName;

        private LuaScriptRunner _luaScriptRunner;
        private Dictionary<KeyCode, string> _spellScripts;

        private void Awake()
        {
            _luaScriptRunner = new LuaScriptRunner();

            _spellScripts = new Dictionary<KeyCode, string>
            {
                { KeyCode.Q, LoadScriptContents(_qSpellScriptName) },
                { KeyCode.W, LoadScriptContents(_wSpellScriptName) },
                { KeyCode.E, LoadScriptContents(_eSpellScriptName) },
                { KeyCode.R, LoadScriptContents(_rSpellScriptName) },
            };

            SetupLuaVariables();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ExecuteSpellScript(KeyCode.Q);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                ExecuteSpellScript(KeyCode.W);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                ExecuteSpellScript(KeyCode.E);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                ExecuteSpellScript(KeyCode.R);
            }
        }

        private static string LoadScriptContents(string scriptName)
        {
            var path = Path.Combine(Application.dataPath, "PatternsExamples", "Behavioral", "Bytecode", scriptName + ".lua");
            if (File.Exists(path))
            {
                Debug.Log("Loaded LUA Script: " + scriptName);
                return File.ReadAllText(path);
            }

            Debug.LogError("Failed to find LUA script!");
            throw new FileNotFoundException();
        }

        private void SetupLuaVariables()
        {
            var script = _luaScriptRunner.GetScript();

            UserData.RegisterProxyType<CharacterLuaProxy, Character>(r => new CharacterLuaProxy(r));

            script.Globals["GetPlayer"] = (Func<Character>)GetPlayer;
            script.Globals["GetRandomEnemy"] = (Func<Character>)GetRandomEnemy;
            script.Globals["GetEnemies"] = (Func<List<Character>>)GetEnemies;
        }

        private void ExecuteSpellScript(KeyCode keyCode)
        {
            _luaScriptRunner.GetScript().DoString(_spellScripts[keyCode]);
        }

        private List<Character> GetEnemies()
        {
            return _enemies;
        }

        private Character GetPlayer()
        {
            return _player;
        }

        private Character GetRandomEnemy()
        {
            return _enemies[Random.Range(0, _enemies.Count)];
        }
    }
}