using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class GameOverView : MonoBehaviour
    {
        [Header("Кнопки")]
        [SerializeField] private Button _buttonRestartGame;
        [SerializeField] private Button _buttonMainMenu;
        [SerializeField] private Button _buttonQuiGame;


        public void Init(UnityAction RestartGame, UnityAction mainMenu, UnityAction QuitGame)
        {
            _buttonRestartGame.onClick.AddListener(RestartGame);
            _buttonMainMenu.onClick.AddListener(mainMenu);
            _buttonQuiGame.onClick.AddListener(QuitGame);
        }


        public void OnDestroy()
        {
            _buttonRestartGame.onClick.RemoveAllListeners();
            _buttonMainMenu.onClick.RemoveAllListeners();
            _buttonQuiGame.onClick.RemoveAllListeners();
        }

    }
}
