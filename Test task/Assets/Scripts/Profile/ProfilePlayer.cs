using System.Collections.Generic;
using Tool;
using UnityEngine;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        //public readonly BoardModel CurrentBoard;


        //public ProfilePlayer(GameState initialState, int xSize, int ysize, Tile tileGo, List<Sprite> tileSprite )
        //{
        //    CurrentState = new SubscriptionProperty<GameState>(initialState);
        //    CurrentBoard = new BoardModel(xSize, ysize, tileGo, tileSprite);
        //}

        public ProfilePlayer(GameState initialState)
        {
            CurrentState = new SubscriptionProperty<GameState>(initialState);
        }
    }
}
