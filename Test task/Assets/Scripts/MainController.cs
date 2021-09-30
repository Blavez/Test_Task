using Ui;
using Profile;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

internal class MainController : BaseController
{
    private MainMenuController _mainMenuController;
    //private BoardController _boardController;
    private SettingsController _settingsController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private SceneLoader sceneLoader = new SceneLoader("Game");
    //private GameController _gameController;


    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _settingsController?.Dispose();
                break;
            case GameState.Game:
                sceneLoader.SceneLoad();
                _mainMenuController?.Dispose();
                break;
            case GameState.Settings:
                _settingsController = new SettingsController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                break;
        }
    }
}
