using Game.Scripts.Controllers;
using Game.Scripts.Models;
using Game.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.LifetimeScopes
{
    public class DependenciesInjector : LifetimeScope
    {
        [SerializeField] private Catalog _catalog;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_catalog.Player, Lifetime.Scoped);
            builder.RegisterComponentInNewPrefab(_catalog.InputManager, Lifetime.Scoped);
            builder.RegisterInstance(_catalog.GameConfiguration.CharacterSettings);
            builder.Register<ICharacterModel, CharacterModel>(Lifetime.Transient);
            builder.Register<ICharacterPhysicsController, CharacterPhysicsController>(Lifetime.Transient);
        }
    }

    public class LoaderEntryPoint : IStartable
    {
        public void Start()
        {
            Addressables.LoadSceneAsync("level_1", LoadSceneMode.Additive);
        }
    }
}