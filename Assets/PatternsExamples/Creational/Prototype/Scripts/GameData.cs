using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PatternsExamples.Creational.Prototype.Scripts
{
    public class GameData : MonoBehaviour
    {
        [SerializeField] private TextAsset _monstersDataJson;

        private Dictionary<string, MonsterModel> _monsters;

        private void Awake()
        {
            var monstersData = JsonUtility.FromJson<MonstersData>(_monstersDataJson.text);

            _monsters = monstersData.MonsterModels.ToDictionary(key => key.Name, val => val);

            foreach (var monsterModel in _monsters.Values)
            {
                if (!string.IsNullOrEmpty(monsterModel.PrototypeName))
                {
                    var prototype = _monsters[monsterModel.PrototypeName];
                    monsterModel.CopyFromPrototype(prototype);
                }
            }
        }

        public MonsterModel GetMonster(string monsterName)
        {
            return _monsters[monsterName];
        }
    }
}