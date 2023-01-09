using Bindito.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Timberborn.BeaversUI;
using Timberborn.BlockSystem;
using Timberborn.Characters;
using Timberborn.EntityPanelSystem;
using Timberborn.InputSystem;
using Timberborn.Localization;
using Timberborn.RecoveredGoodSystem;
using Timberborn.SingletonSystem;
using Timberborn.StockpilesUI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MoreThoughts
{
    public class MoreThoughts : ILoadableSingleton,  IInputProcessor
    {
        private readonly InputService _inputService;
        private readonly EventBus _eventBus;
        private static readonly Key hKey = Key.H;
        private KeyboardController _keyboardController = null!;
        private readonly StockpileOverlay _stockpileOverlay;
        private StockpileOverlayToggle _stockpileOverlayToggle;
        private CharacterPopulation _character;
        private TobbertCore _tobbertCore;

        private static readonly string BeaverThoughtPoolLocKey = "Beaver.thoughtPool";
        private readonly ILoc _loc;


        public MoreThoughts(EventBus eventBus, InputService inputService, KeyboardController keyboardController,  StockpileOverlay stockpileOverlay, CharacterPopulation characterPopulation, TobbertCore tobbertCore)
        {
            _eventBus = eventBus;
            _inputService = inputService;
            _keyboardController = keyboardController;         
            _stockpileOverlay = stockpileOverlay;
            _character = characterPopulation;
            _tobbertCore = tobbertCore;
        }

        public void Load()
        {
            _inputService.AddInputProcessor(this);
            _eventBus.Register(this);
        }
        [Inject]
        public void InjectDependencies(TobbertCore tobbertCore)
        {
            _tobbertCore = tobbertCore;
        }

        private void Update()
        {
        }

        public void toggleThoughts()
        {

            //    using (StreamReader r = new StreamReader(_loc.T(BeaverThoughtPoolLocKey)+".json"))
            //using (StreamReader r = new StreamReader("E:\\Games\\steamapps\\common\\Timberborn\\BepInEx\\plugins\\MoreThoughts\\lang\\enUS_thoughts.json"))
            //{
            //    string json = r.ReadToEnd();
            //    List<beaverThoughts> beaverThoughts = JsonConvert.DeserializeObject<List<beaverThoughts>>(json);
            //    var random = new System.Random();
            //    int index = random.Next(beaverThoughts.Count);
            //    Plugin.Log.LogInfo("I say: " + beaverThoughts[index].Thought.ToString());
            //}



            //Vector3 worldCenter = _blockObjectCenter.WorldCenter;
            //Vector3 worldCenterGrounded = _blockObjectCenter.WorldCenterGrounded;
            //float y = (worldCenter.y + worldCenterGrounded.y) * 0.5f;
            //Vector3 anchor = new Vector3(worldCenter.x, y, worldCenter.z);

            ////Plugin.Log.LogWarning("World Center is " + anchor.ToString());

            //_tobbertCore.InvokePrivateMethod(_stockpileOverlay, "UpdatePosition", new object[] { });
            // _recoveredGoodStackSpawner.AddAwaitingGoods(Vector3Int.RoundToInt(wrongPosition), GetCarriedGoods());
            // _chooChooCore.InvokePublicMethod(_recoveredGoodStackSpawner, "AddAwaitingGoods", new object[] { Vector3Int.RoundToInt(wrongPosition), GetAllGoods() });

            //foreach (Timberborn.Characters.Character beavChar in _character.Characters)
            //{
            //   // Plugin.Log.LogInfo("Beaver Name: " + beavChar.FirstName + " age: " + beavChar.Age);

            //    Plugin.Log.LogInfo("Beaver Name: " + beavChar.FirstName + " he's at" + beavChar.transform.position);
            //}
            //Plugin.Log.LogWarning("Population is " + _character.NumberOfCharacters);

            //StockpileOverlay stockpileOverlay = _stockpileOverlayToggle.EnableOverlay();
        }
        public bool ProcessInput()
        {
            if (_keyboardController.IsKeyDown(hKey))
            {
                PostProcessInput();
                return true;
            }
            return false;
        }
        public virtual void PostProcessInput()
        {
            if (_keyboardController.IsKeyDown(Key.H))
            {
                Plugin.Log.LogWarning("H key was pressed!");
                toggleThoughts();

            }
        }

    }
}

