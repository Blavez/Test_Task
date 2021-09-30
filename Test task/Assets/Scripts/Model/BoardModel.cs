using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class BoardModel
{
    
        public int xSize { get; set; }

        public int ySize { get; set; }

        public Tile TileGO { get; set; }
        public List<Sprite> TileSprite { get; set; }


        public BoardModel(int xsize, int ysize, Tile tileGO, List<Sprite> tileSprite)
        {
            xSize = xsize;
            ySize = ysize;
            TileGO = tileGO;
            TileSprite = tileSprite;
        }
}