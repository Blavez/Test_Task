using Config;
using Profile;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Параметры доски")]
   

    [Header("Configs")]
    [SerializeField] private PlayerProfile _initialPlayerProfileConfig;

    [Header("Components")]
    [SerializeField] private Transform _placeForUi;

    private MainController _mainController;

    void Start()
    {
        var profilePlayer = CreatePlayerProfile(_initialPlayerProfileConfig);
        _mainController = new MainController(_placeForUi, profilePlayer);
    }
    private ProfilePlayer CreatePlayerProfile(PlayerProfile playerProfileConfig) =>
        new ProfilePlayer
        (
            playerProfileConfig.GameState
        );

}
