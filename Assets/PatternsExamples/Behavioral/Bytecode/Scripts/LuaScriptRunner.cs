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
        }

        public Script GetScript()
        {
            return _luaScript;
        }
    }
}