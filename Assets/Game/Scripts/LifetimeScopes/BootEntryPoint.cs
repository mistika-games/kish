using Game.Scripts.ScriptableObjects;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Game.Scripts.LifetimeScopes
{
    public class BootEntryPoint : IStartable
    {
        private readonly GameConfiguration _gameConfiguration;
        
        public BootEntryPoint (GameConfiguration gameConfiguration)
        {
            _gameConfiguration = gameConfiguration;
        }

        public void Start()
        {
            Addressables.LoadSceneAsync(_gameConfiguration.LevelNames.Level1, LoadSceneMode.Additive);
        }
    }
}