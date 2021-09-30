using Profile;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class GameOverController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/GameOver");
        private readonly GameOverView _view;
        


        public GameOverController(Transform placeForUi)
        {
            _view = LoadView(placeForUi);
            _view.Init(RestartGame, MainMenu, QuitGame);
        }

        private GameOverView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            return objectView.GetComponent<GameOverView>();
        }

        private void RestartGame()
        {
            SceneLoader _sceneLoader = new SceneLoader("Game");
            _sceneLoader.SceneLoad();
        }

        private void MainMenu()
        {
            SceneLoader _sceneLoader = new SceneLoader("MainMenu");
            _sceneLoader.SceneLoad();
        }

        private void QuitGame()
        {
            Application.Quit();
        }

    }
}
