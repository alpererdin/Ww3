using UnityEngine;

namespace Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameData", menuName = "UnitData/GameData", order = 0)]
    public class GameData : ScriptableObject
    {
        public float musicValue ;
        public float effectValue ;
        
    }
}