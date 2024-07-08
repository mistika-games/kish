using VContainer;
using VContainer.Unity;

namespace Game.Scripts.LifetimeScopes
{
    public class SceneLoader : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LoaderEntryPoint>();
        }
    }
}