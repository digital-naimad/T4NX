using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class OptionSelector : MonoSingleton<SpawnSpotSelector>
    {
        private byte _selectedIndex = 0;

        /// <summary>
        /// 
        /// </summary>
        public void SwitchToNextOption()
        {
            //_currentlySelectedOption++;
            //_currentlySelectedOption = (SpawnSpotOption)((int)_currentlySelectedOption % _spawnSpotOptions.Count); // Length);
            _selectedIndex++;
            //_selectedIndex %= (byte)_spawnSpotOptions.Length;
            //ApplyOptionName();
        }


    }
}
