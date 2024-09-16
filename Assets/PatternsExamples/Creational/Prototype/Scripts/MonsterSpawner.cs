using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PatternsExamples.Creational.Prototype.Scripts
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;

        private void Start()
        {
            var monsters = new List<MonsterModel>()
            {
                _gameData.GetMonster("goblin"),
                _gameData.GetMonster("goblin_big"),
                _gameData.GetMonster("goblin_giant"),
                _gameData.GetMonster("elf"),
            };

            foreach (var monster in monsters)
            {
                PrintMonsterData(monster);
            }
        }

        private static void PrintMonsterData(MonsterModel monsterModel)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {monsterModel.Name}");
            sb.AppendLine($"Health: {monsterModel.MinHealth}...{monsterModel.MaxHealth}");

            sb.AppendLine("Resists:");
            foreach (var resist in monsterModel.Resists)
            {
                sb.AppendLine($"  - {resist}");
            }

            sb.AppendLine("Weaknesses:");
            foreach (var weakness in monsterModel.Weaknesses)
            {
                sb.AppendLine($"  - {weakness}");
            }

            Debug.Log(sb.ToString());
        }
    }
}