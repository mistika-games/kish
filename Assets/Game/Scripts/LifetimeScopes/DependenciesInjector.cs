using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Controllers.PhysicsControllers;
using Game.Scripts.Models;
using Game.Scripts.ScriptableObjects;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.LifetimeScopes
{
    public class DependenciesInjector : LifetimeScope
    {
        [SerializeField] private Catalog _catalog;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_catalog._playerBehaviour, Lifetime.Scoped);
            builder.RegisterComponentInNewPrefab(_catalog.InputManager, Lifetime.Scoped);
            builder.RegisterComponentInNewPrefab(_catalog.FollowCamera, Lifetime.Scoped);
            builder.RegisterInstance(_catalog.GameConfiguration);
            builder.Register<ICharacterModel, CharacterModel>(Lifetime.Transient);
            builder.Register<ICharacterPhysicsController, CharacterPhysicsController>(Lifetime.Transient);
            builder.Register<ICharacterAttackPhysicsController, CharacterAttackPhysicsController>(Lifetime.Transient);
            builder.Register<ICharacterMovementPhysicsController, CharacterMovementPhysicsController>(Lifetime.Transient);
        }
    }
}