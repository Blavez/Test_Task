using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board instance;

    private int xSize, ySize,rand,yellow=0,blue=0,red=0;
    private Tile tileGO;
    private List<Sprite> tileSprite = new List<Sprite>();
    


    private void Awake()
    {
        instance = this;
    }
    public Tile [,] SetValue(int xSize, int ySize, Tile tileGO, List<Sprite> tileSprite)
    {
        this.xSize = xSize;
        this.ySize = ySize;
        this.tileGO = tileGO;
        this.tileSprite = tileSprite;

        return CreateBoard();
    }

    private Tile[,] CreateBoard()
    {
        Tile[,] tileArray = new Tile[xSize, ySize];
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        Vector2 tileSize = tileGO.spriteRenderer.bounds.size;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Tile newTile = Instantiate(tileGO, transform.position, Quaternion.identity);
                if (x == 1 && y == 1 || x == 1 && y == 3 || x == 3 && y == 1 || x == 3 && y == 3)
                {
                    newTile.spriteRenderer.sprite = tileSprite[1];
                    newTile.transform.position = new Vector3(xPos + (tileSize.x * x), yPos + (tileSize.y * y), 0);
                    newTile.transform.parent = transform;
                    tileArray[x, y] = newTile;
                }
                else if(x == 1 && y == 0 || x == 3 && y == 0 || x == 3 && y == 2 || x == 1 && y == 2 || x == 3 && y == 4 || x == 1 && y == 4)
                {
                    newTile.spriteRenderer.sprite = tileSprite[0];
                    newTile.transform.position = new Vector3(xPos + (tileSize.x * x), yPos + (tileSize.y * y), 0);
                    newTile.transform.parent = transform;
                    tileArray[x, y] = newTile;
                }
                else if (y==5)
                {
                    newTile.spriteRenderer.sprite = null;
                        newTile.transform.position = new Vector3(xPos + (tileSize.x * x), yPos + (tileSize.y * y), 0);
                    newTile.transform.parent = transform;
                    tileArray[x, y] = newTile;
                }
                else if (y == 6)
                {
                    if (x == 0)
                    {
                        newTile.spriteRenderer.sprite = tileSprite[3];
                        newTile.transform.position = new Vector3(xPos + (tileSize.x * x), yPos + (tileSize.y * y), 0);
                        newTile.transform.parent = transform;
                        tileArray[x, y] = newTile;
                    }
                    if (x == 1 || x == 3)
                    {
                        newTile.spriteRenderer.sprite = null;
                        newTile.transform.position = new Vector3(xPos + (tileSize.x * x), yPos + (tileSize.y * y), 0);
                        newTile.transform.parent = transform;
                        tileArray[x, y] = newTile;
                    }
                    if (x == 2)
                    {
                        newTile.spriteRenderer.sprite = tileSprite[4];
                        newTile.transform.position = new Vector3(xPos + (tileSize.x * x), yPos + (tileSize.y * y), 0);
                        newTile.transform.parent = transform;
                        tileArray[x, y] = newTile;
                    }
                    if (x == 4)
                    {
                        newTile.spriteRenderer.sprite = tileSprite[2];
                        newTile.transform.position = new Vector3(xPos + (tileSize.x * x), yPos + (tileSize.y * y), 0);
                        newTile.transform.parent = transform;
                        tileArray[x, y] = newTile;
                    }
                }

                else
                {
                    newTile.transform.position = new Vector3(xPos + (tileSize.x * x), yPos + (tileSize.y * y), 0);
                    newTile.transform.parent = transform;
                    tileArray[x, y] = newTile;

                    List<Sprite> tempSprite = new List<Sprite>();
                    tempSprite.AddRange(tileSprite);
                    
                    rand = Random.Range(2, tempSprite.Count);
                    if (rand==2)
                    {
                        red++;
                        
                        if (red>5)
                        {
                            rand = Random.Range(3, tempSprite.Count);
                        }
                    }
                    
                    if (rand == 3)
                    {
                        yellow++;
                        if (yellow>5&&blue>5)
                        {
                            rand = 2;
                            red++;
                        }
                        else if (yellow > 5 && red > 5)
                        {
                            rand = 4;
                        }
                        else if (yellow > 5) 
                        {
                            rand = 4;
                        }
                    }

                    if (rand == 4)
                    {
                        blue++;
                        if (blue>5&&red>5)
                        {
                            rand = 3;
                            yellow++;
                        }
                        else if (blue > 5 && red < 5)
                        {
                            rand = 2;
                            red++;
                        }
                        else if (blue>5&&yellow>5)
                        {
                            rand = 2;
                            red++;
                        }
                        else if (blue>5&&yellow<5)
                        {
                            rand = 3;
                            yellow++;
                        }
                        else if (blue > 5)
                        {
                            rand = 2;
                            red++;
                        }
                    }

                    newTile.spriteRenderer.sprite = tempSprite[rand];
                }
            }

        }
        return tileArray;
    }
}
