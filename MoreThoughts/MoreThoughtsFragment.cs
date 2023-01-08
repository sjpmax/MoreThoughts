using System;
using System.Collections.Generic;
using System.Text;
using TimberApi.UiBuilderSystem;
using Timberborn.EntityPanelSystem;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Timberborn.CoreUI;
using static UnityEngine.UIElements.Length.Unit;
using Timberborn.Localization;
using Timberborn.SelectionSystem;

namespace MoreThoughts
{
    internal class MoreThoughtsFragment: IEntityPanelFragment
    {

        private readonly UIBuilder _builder;
        private VisualElement? _root;
        private readonly ILoc _loc;

        private readonly VisualElementLoader _visualElementLoader;

        public MoreThoughtsFragment(ILoc loc, VisualElementLoader visualElementLoader, UIBuilder builder)
        {           
            _loc = loc;
            _visualElementLoader = visualElementLoader;
            _builder = builder;
        }

        public VisualElement InitializeFragment()
        {
            Plugin.Log.LogInfo("In MoreThoughtsFragment");
            _root = _visualElementLoader.LoadVisualElement("Master/EntityPanel/BeaverBuildingsFragment");
            var rootBuilder = _builder.CreateComponentBuilder()
                                .CreateLabel()
                                .AddPreset(factory => factory.Labels()
                                                             .GameTextBig(name: "BeaverThoughtsLabel",
                                                                          locKey: "SJPMax.Beaver.thoughtContainer",
                                                                          builder: builder =>
                                                                             builder.SetStyle(style =>
                                                                                 style.alignSelf = Align.Center)))
                                .BuildAndInitialize();
            _root.Add(rootBuilder);
            return _root;

        }
        public void UpdateFragment() { _root.ToggleDisplayStyle(visible: true); }    
        public void OnDestroy() { }

        public void ShowFragment(GameObject entity)
        {
            _root.ToggleDisplayStyle(visible: true);
        }

        public void ClearFragment()
        {
            _root.ToggleDisplayStyle(visible: false);
        }
    }
}
