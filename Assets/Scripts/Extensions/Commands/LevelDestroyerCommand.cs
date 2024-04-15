using Managers;
using Interfaces;
using UnityEngine;

namespace Commands
{
    public class LevelDestroyerCommand : ICommand
    {
        private readonly LevelManager _levelManager;
        private readonly Transform _levelHolder;

        public LevelDestroyerCommand(ref Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }

        public void Execute()
        {
            Object.Destroy(_levelHolder.GetChild(0).gameObject);
        }
    }
}