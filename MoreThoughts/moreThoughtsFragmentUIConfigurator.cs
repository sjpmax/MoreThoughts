using Bindito.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using Timberborn.EntityPanelSystem;

namespace MoreThoughts
{
    [Configurator(SceneEntrypoint.InGame)]
    public class moreThoughtsFragmentUIConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            Plugin.Log.LogInfo("In moreThoughtsFragmentUIConfigurator");
            containerDefinition.Bind<MoreThoughtsFragment>().AsSingleton();
            containerDefinition.MultiBind<EntityPanelModule>().ToProvider<EntityPanelModuleProvider>().AsSingleton();
        }

        private class EntityPanelModuleProvider : IProvider<EntityPanelModule>
        {
            private readonly MoreThoughtsFragment _moreThoughtsFragment;

            public EntityPanelModuleProvider(MoreThoughtsFragment moreThoughtsFragment)
            {
                _moreThoughtsFragment = moreThoughtsFragment;
            }

            public EntityPanelModule Get()
            {
                EntityPanelModule.Builder builder = new EntityPanelModule.Builder();
                builder.AddMiddleFragment(_moreThoughtsFragment);
                return builder.Build();
            }
        }
    }
}