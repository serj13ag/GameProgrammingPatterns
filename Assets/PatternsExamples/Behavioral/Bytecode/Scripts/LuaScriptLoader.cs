using System.IO;
using UnityEngine;

namespace PatternsExamples.Behavioral.Bytecode.Scripts
{
    public static class LuaScriptLoader
    {
        private const string LuaScriptsFolderPath = "PatternsExamples/Behavioral/Bytecode/LuaScripts";

        public static string LoadScriptContents(string scriptName)
        {
            var path = Path.Combine(Application.dataPath, LuaScriptsFolderPath, scriptName + ".lua");
            if (File.Exists(path))
            {
                Debug.Log("Loaded LUA Script: " + scriptName);
                return File.ReadAllText(path);
            }

            Debug.LogError("Failed to find LUA script!");
            throw new FileNotFoundException();
        }
    }
}