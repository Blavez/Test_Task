using System.Collections.Generic;
using Tool;
using UnityEngine;

namespace Profile
{
    internal class ProfileBoard
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly BoardModel CurrentBoard;


        public ProfileBoard(int xSize, int ySize, Tile TileGO, List<Sprite> TileSprite)
        {
            CurrentBoard = new BoardModel(xSize, ySize, TileGO, TileSprite);
        }
    }
}
