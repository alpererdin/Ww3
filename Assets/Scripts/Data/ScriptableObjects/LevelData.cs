using System.Collections.Generic;
using System;
using UnityEngine;
namespace Data.ScriptableObjects
{

    [Serializable]
    public struct LevelData
    {
        public int _Value;
    }
    
   /* public struct LevelData
    {
        public List<PoolData> PoolList;

        public LevelData(List<PoolData> datas)
        {
            PoolList = datas;
        }
    }

    [Serializable]
    public struct PoolData
    {
        public byte RequiredObjectCount;
    }*/
}