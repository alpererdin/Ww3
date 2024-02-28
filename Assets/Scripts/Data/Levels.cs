using UnityEngine;
using System.Collections.Generic;
using Data.ScriptableObjects;

namespace Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "UnitData/LevelData", order = 0)]
    public class Levels : ScriptableObject
    {
      //  public List<LevelData> LevelValues = new List<LevelData>();
      public int _LevelData;
    }
}