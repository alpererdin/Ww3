using System;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Commands
{
    public class LevelLoaderCommand : ICommand
    {
        private readonly Transform _levelHolder;

        public LevelLoaderCommand(ref Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }

        public void Execute(int parameter)
        {
            var resourceRequest = Resources.LoadAsync<GameObject>($"Prefabs/LevelPrefabs/level {parameter}") ??
                                  throw new ArgumentNullException("There is not such level with that value\")");
            resourceRequest.completed += operation =>
            {
                var newLevel = Object.Instantiate(resourceRequest.asset.GameObject(),
                    Vector3.zero, Quaternion.identity);
                if (newLevel != null) newLevel.transform.SetParent(_levelHolder.transform);
            };
        }
    }
}