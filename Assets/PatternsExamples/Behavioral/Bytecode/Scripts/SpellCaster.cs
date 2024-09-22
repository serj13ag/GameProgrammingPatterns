using System.Collections.Generic;
using UnityEngine;
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

        private Dictionary<KeyCode, string> _spellLuaScripts;

        private LuaScriptRunner _luaScriptRunner;
        private SpellCasterLuaModule _spellCasterLuaModule;

        private void Awake()
        {
            _luaScriptRunner = new LuaScriptRunner();
            _spellCasterLuaModule = new SpellCasterLuaModule(this);

            _spellLuaScripts = new Dictionary<KeyCode, string>
            {
                { KeyCode.Q, LuaScriptLoader.LoadScriptContents(_qSpellScriptName) },
                { KeyCode.W, LuaScriptLoader.LoadScriptContents(_wSpellScriptName) },
                { KeyCode.E, LuaScriptLoader.LoadScriptContents(_eSpellScriptName) },
                { KeyCode.R, LuaScriptLoader.LoadScriptContents(_rSpellScriptName) },
            };
        }

        private void OnEnable()
        {
            _spellCasterLuaModule.SetupVariables(_luaScriptRunner.GetScript());
        }

        private void OnDisable()
        {
            _spellCasterLuaModule.CleanupVariables(_luaScriptRunner.GetScript());
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

        public Character GetPlayer()
        {
            return _player;
        }

        public Character GetRandomEnemy()
        {
            return _enemies[Random.Range(0, _enemies.Count)];
        }

        public List<Character> GetEnemies()
        {
            return _enemies;
        }

        private void ExecuteSpellScript(KeyCode keyCode)
        {
            _luaScriptRunner.RunScript(_spellLuaScripts[keyCode]);
        }
    }
}