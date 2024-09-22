using MoonSharp.Interpreter;
using UnityEngine;

namespace PatternsExamples.Behavioral.Bytecode.Scripts
{
    public class LuaScriptRunner
    {
        private readonly Script _luaScript = new();

        public LuaScriptRunner()
        {
            Script.DefaultOptions.DebugPrint = Debug.Log;

            UserData.RegisterProxyType<CharacterLuaProxy, Character>(r => new CharacterLuaProxy(r));
        }

        public Script GetScript()
        {
            return _luaScript;
        }

        public void RunScript(string script)
        {
            _luaScript.DoString(script);
        }
    }
}