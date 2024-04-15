
using Commands;
using Enums;
using Extensions;
using Signals;
using Tests;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        [Header("Holder")] [SerializeField] private Transform levelHolder;
        [Space] [SerializeField] private int totalLevelCount;
        
        private LevelLoaderCommand _levelLoader;
        private LevelDestroyerCommand _levelDestroyer;
        //private GameData _gameData;
        

        private  int currentLvl = 0;

         public void LoadLevelOnBtn(int i)
         {
           /*  if (levelHolder.childCount>0)
             {
                 _levelDestroyer.Execute();
             
             }*/
            // LevelSignals.Instance.LoadThatScene?.Invoke(i+1);
             LevelTests.Instance.i = i+1;
             //Debug.Log("from level manager"+ i);
           //  _levelLoader.Execute(i+1);
             
         }
        private void Awake()
        {
            Init();
            AssignSaveData();
        }

        private void Init()
        {
            _levelLoader = new LevelLoaderCommand(ref levelHolder);
            _levelDestroyer = new LevelDestroyerCommand(ref levelHolder);
            
        }

        private void Update()
        {
            /*if (Input.GetKeyDown(KeyCode.M))
            {
                OnNextLevel();
            }*/
        }
        private void AssignSaveData()
        {
          //  _gameData = SaveDistributorManager.GetSaveData();
        }

        private void OnEnable()
        {
            SubscribeEvents();

          //  _gameData.Level = OnGetLevelID();
          //  CoreGameSignals.Instance.onLevelInitialize?.Invoke(_gameData.Level);
        
        }
        private void SubscribeEvents()
        {
            LevelSignals.Instance.OnLevelInitialize += _levelLoader.Execute;
            LevelSignals.Instance.OnClearActiveLevel += _levelDestroyer.Execute;
            LevelSignals.Instance.OnGetLevelID += OnGetLevelID;
            LevelSignals.Instance.OnNextLevel += OnNextLevel;
            LevelSignals.Instance.OnRestartLevel += OnRestartLevel;
            
            
        }

        private int OnGetLevelID()
        {
          //  return _gameData.Level % totalLevelCount;
            return currentLvl % totalLevelCount;
        }

        private void OnNextLevel()
        {
           //_gameData.Level++;
             currentLvl++;
           //SaveDistributorManager.SaveData();
            LevelSignals.Instance.OnClearActiveLevel?.Invoke();
           //DOVirtual.DelayedCall(.1f, () => CoreGameSignals.Instance.onLevelInitialize?.Invoke(OnGetLevelID()));
           Invoke("Test",0.1f); 
           //CoreUISignals.Instance.onCloseAllPanels?.Invoke();
           //CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 0);
        }

        private void Test()
        {
            LevelSignals.Instance.OnLevelInitialize?.Invoke(OnGetLevelID());
        }

        private void OnRestartLevel()
        {
           //CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
           LevelSignals.Instance.OnClearActiveLevel?.Invoke();
           //DOVirtual.DelayedCall(.1f, () => CoreGameSignals.Instance.onLevelInitialize?.Invoke(OnGetLevelID()));
          Invoke("Test",0.1f); 
           //CoreUISignals.Instance.onCloseAllPanels?.Invoke();
           //CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 0);
           //SaveDistributorManager.SaveData();
        }

        private void UnsubscribeEvents()
        {
            LevelSignals.Instance.OnLevelInitialize -= _levelLoader.Execute;
            LevelSignals.Instance.OnClearActiveLevel -= _levelDestroyer.Execute;
            LevelSignals.Instance.OnGetLevelID -= OnGetLevelID;
            LevelSignals.Instance.OnNextLevel -= OnNextLevel;
            LevelSignals.Instance.OnRestartLevel -= OnRestartLevel;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
    }
}