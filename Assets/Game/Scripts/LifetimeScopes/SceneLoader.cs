using Game.Scripts.ScriptableObjects;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.LifetimeScopes
{
    public class SceneLoader : LifetimeScope
    {
        [SerializeField] private GameConfiguration _gameConfiguration; 
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BootEntryPoint>().WithParameter(_gameConfiguration);
        }
    }
}