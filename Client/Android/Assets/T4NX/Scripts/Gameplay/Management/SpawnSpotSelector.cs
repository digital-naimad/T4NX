using System;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace T4NX
{
    public class SpawnSpotSelector : MonoSingleton<SpawnSpotSelector>
    {
        [SerializeField] private SpawnSpotOptionEntry[] _spawnSpotOptions;
        //[SerializeField] private List<SpawnSpotOptionEntry> _spawnSpotOptions = new List<SpawnSpotOptionEntry>();

        [SerializeField] private TextMeshProUGUI _menuOptionLabel;

        /// <summary>
        /// 
        /// </summary>
        public SpawnSpotOption CurrentlySelectedOption { get { return _spawnSpotOptions[_selectedIndex].SpotOption; } }

        //private SpawnSpotOption _currentlySelectedOption = SpawnSpotOption.Player_1;
        private byte _selectedIndex = 0;

        #region Embedded class
        [Serializable]
        public class SpawnSpotOptionEntry
        {
            [SerializeField] private SpawnSpotOption _spawnSpotOption;
            [SerializeField] private string _optionName;

            public SpawnSpotOption SpotOption { get { return _spawnSpotOption; } }
            public string OptionName { get { return _optionName; } }
        }
        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        #region Public methods

        /// <summary>
        /// 
        /// </summary>
        public void SwitchToNextOption()
        {
            //_currentlySelectedOption++;
            //_currentlySelectedOption = (SpawnSpotOption)((int)_currentlySelectedOption % _spawnSpotOptions.Count); // Length);
            _selectedIndex++;
            _selectedIndex %= (byte)_spawnSpotOptions.Length;
            ApplyOptionName();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SwitchToPreviousOption()
        {
            //_currentlySelectedOption += _spawnSpotOptions.Count - 1;
            //_currentlySelectedOption = (SpawnSpotOption)((int)_currentlySelectedOption % _spawnSpotOptions.Count); //.Length);
            _selectedIndex--;
            _selectedIndex %= (byte)_spawnSpotOptions.Length;
            ApplyOptionName();
        }

        #endregion

        #region Private methods

        private void ApplyOptionName()
        {
            _menuOptionLabel.text = _spawnSpotOptions[_selectedIndex].OptionName;
        }

        #endregion


    }
}
