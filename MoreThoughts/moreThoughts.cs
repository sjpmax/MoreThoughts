using System;
using System.Collections.Generic;
using System.Text;
using Timberborn.InputSystem;
using Timberborn.StatusSystemUI;
using UnityEngine.InputSystem;

namespace MoreThoughts
{
    public class MoreThoughts : IInputProcessor
    {
        private readonly InputService _inputService;

        private static readonly Key hKey = Key.H;

        private KeyboardController _keyboardController = null!;

        public MoreThoughts(InputService inputService)
        {
            _inputService = inputService;
        }

        public void HasButtonBeenPressed()
        {
        }
        public bool ProcessInput()
        {
            if (_keyboardController.IsKeyDown(hKey)) { 
                Plugin.Log.LogWarning("H key was pressed!");
            }
            return true;
        }
    }
}

