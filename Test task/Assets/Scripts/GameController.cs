using Config;
using Profile;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [Header("Configs")]
    [SerializeField] private BoardConfig _initialBoardProfileConfig;

    void Start()
    {
        BoardController.instance.SetValue(Board.instance.SetValue(_initialBoardProfileConfig.xSize, _initialBoardProfileConfig.ySize, _initialBoardProfileConfig.tileGO,
            _initialBoardProfileConfig.tileSprite),
            _initialBoardProfileConfig.tileSprite);
        //var profileBoard = CreateBoardProfile(_initialBoardProfileConfig);
        //int x = _initialBoardProfileConfig.xSize;
    }
    //private ProfileBoard CreateBoardProfile(BoardConfig boardProfileConfig) =>
    //    new ProfileBoard
    //    (
    //        boardProfileConfig.xSize,
    //        boardProfileConfig.ySize,
    //        boardProfileConfig.tileGO,
    //        boardProfileConfig.tileSprite
    //    );
}
