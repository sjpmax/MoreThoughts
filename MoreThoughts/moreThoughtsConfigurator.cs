using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace MoreThoughts
{
    [Configurator(SceneEntrypoint.InGame)]
    public class MoreThoughtsInGameConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            Plugin.Log.LogWarning("More THOTS plugin loaded");
            containerDefinition.Bind<MoreThoughts>().AsSingleton();
            containerDefinition.Bind<TobbertCore>().AsSingleton();
        }
    }
}

