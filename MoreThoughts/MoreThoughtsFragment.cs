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
using Timberborn.BeaversUI;
using Timberborn.WorkSystem;
using Timberborn.DwellingSystem;
using Newtonsoft.Json;
using System.IO;

namespace MoreThoughts
{
    internal class MoreThoughtsFragment: IEntityPanelFragment
    {

        private readonly UIBuilder _builder;
        private VisualElement? _root;
        private readonly ILoc _loc;

        private readonly BeaverBuildingViewFactory _beaverBuildingViewFactory;
        private readonly VisualElementLoader _visualElementLoader;

        private BeaverBuildingView _home;

        private BeaverBuildingView _workplace;
        private Label _beaverThoughtLabel;

        public MoreThoughtsFragment(ILoc loc, VisualElementLoader visualElementLoader, UIBuilder builder, BeaverBuildingViewFactory beaverBuildingViewFactory)
        {           
            _loc = loc;
            _visualElementLoader = visualElementLoader;
            _builder = builder;
            _beaverBuildingViewFactory = beaverBuildingViewFactory;
        }

        public VisualElement InitializeFragment()
        {
            Plugin.Log.LogInfo("In MoreThoughtsFragment");
            _root = _visualElementLoader.LoadVisualElement("Master/EntityPanel/BeaverBuildingsFragment");
            var rootBuilder = _builder.CreateComponentBuilder()
                                .CreateLabel()
                                .AddPreset(factory => factory.Labels()
                                .GameTextBig(name: "BeaverThoughtsLabel",
                                            builder: builder =>
                                                builder.SetStyle(style =>
                                                    style.alignSelf = Align.Center)))
                                .BuildAndInitialize();
            _root.Add(rootBuilder);
            _home = _beaverBuildingViewFactory.Create(_root.Q<Button>("Home"));
            _workplace = _beaverBuildingViewFactory.Create(_root.Q<Button>("Workplace"));
            _beaverThoughtLabel = _root.Q<Label>("BeaverThoughtsLabel");
            return _root;

        }
        public void UpdateFragment() {
            //_root.Clear();
         _root.ToggleDisplayStyle(visible: true); 
        
        }    
        public void OnDestroy() { }

        public void ShowFragment(GameObject entity)
        {
            _home.Root.ToggleDisplayStyle(false);
            _workplace.Root.ToggleDisplayStyle(false);
            string beaverThoughtText = "";
            using (StreamReader r = new StreamReader("E:\\Games\\steamapps\\common\\Timberborn\\BepInEx\\plugins\\MoreThoughts\\lang\\enUS_thoughts.json"))
            {
                string json = r.ReadToEnd();
                List<beaverThoughts> beaverThoughts = JsonConvert.DeserializeObject<List<beaverThoughts>>(json);
                var random = new System.Random();
                int index = random.Next(beaverThoughts.Count);
                Plugin.Log.LogInfo("show fragment: " + beaverThoughts[index].Thought.ToString());

                beaverThoughtText = "\"" + beaverThoughts[index].Thought.ToString() +"\"";
            }
            _beaverThoughtLabel.text = beaverThoughtText;
            _root.ToggleDisplayStyle(visible: true);
        }

        public void ClearFragment()
        {
            _root.ToggleDisplayStyle(visible: false);
        }
    }
}
