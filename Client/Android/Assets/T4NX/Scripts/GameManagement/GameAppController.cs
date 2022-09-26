using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class GameAppController : MonoBehaviour
    {
        [SerializeField] private GameType _currentGameMode = GameType.Construction;
        [SerializeField] private List<GameModeOption> gameModes = new List<GameModeOption>();

        // Start is called before the first frame update
        void Start()
        {
            LaunchGame();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void LaunchGame()
        {

            Debug.Log(this.name + " >> LaunchGame() Option: " + (int)_currentGameMode + " Mode: " + _currentGameMode);

            IGamepadEventsListener listener = gameModes[(int)_currentGameMode].controller.GamepadEventsListener; // % (int)GameType.TwoPlayers

            SetupGamepadInputListeners(listener);

            switch (_currentGameMode)
            {
                case GameType.Construction:
                    
                    break;

            }
        }

        private void SetupGamepadInputListeners(IGamepadEventsListener listener)
        {
            GamepadEventsManager.SetupListeners(listener);
        }
    }

}
