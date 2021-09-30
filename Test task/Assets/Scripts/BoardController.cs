//using Profile;
//using System.Collections;
using System.Collections.Generic;
using Ui;
using UnityEngine;

internal class BoardController : MonoBehaviour
{
    //private readonly ProfilePlayer _profilePlayer;
    public static BoardController instance;
    [SerializeField] private Transform _placeForUi;
    private bool yellow = false, blue = false, red = false;
    private List<Sprite> tileSprite = new List<Sprite>();
    private Tile[,] tileArray;
    //private Tile tileGO;
    private GameOverController _gameOver;

    private Tile oldSelectTile;
    private Vector2[] dirRay = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };


    //public BoardController(//ProfilePlayer profilePlayer,
    //    int XSize, int YSize, List<Sprite> TileSprite)
    //{
    //    //_profilePlayer = profilePlayer;
    //    //SetValue(_profilePlayer);
    //    xSize = XSize;
    //    ySize = YSize;
    //    tileSprite = TileSprite;
    //}
    public void SetValue(Tile[,] tileArray, List<Sprite> tileSprite)
    {
        this.tileArray = tileArray;
        this.tileSprite = tileSprite;

        //xSize = _profilePlayer.CurrentBoard.xSize;
        //ySize = _profilePlayer.CurrentBoard.ySize;
        //tileSprite = _profilePlayer.CurrentBoard.TileSprite;
        //tileGO = _profilePlayer.CurrentBoard.TileGO;
        //tileArray = Board.instance.SetValue(xSize, ySize, tileGO, tileSprite);
    }
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (ray != false)
            {
                CheckSelectTile(ray.collider.gameObject.GetComponent<Tile>());
            }
        }
    }

    private void SelectTile(Tile tile)
    {
        tile.isSelected = true;
        tile.spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
        oldSelectTile = tile;
    }
    private void DeselectTile(Tile tile)
    {
        tile.isSelected = false;
        tile.spriteRenderer.color = new Color(1, 1, 1);
        oldSelectTile = null;
    }
    private void CheckSelectTile(Tile tile)
    {
       
        if (tile.isEmpty)
        {
            return;
        }
        if (tile.spriteRenderer.sprite== tileSprite[0])
        {
            return;
        }
        if (tile.isSelected)
        {
            DeselectTile(tile);
        }
        else
        {
            if (!tile.isSelected && oldSelectTile == null)
            {
                SelectTile(tile);
            }
            else
            {
                if (AdjacentTiles().Contains(tile))
                {
                    SwapTwoTiles(tile);
                    FindAllMatch(tile);
                    DeselectTile(oldSelectTile);
                }
                else
                {
                    DeselectTile(oldSelectTile);
                    SelectTile(tile);
                }
            }
        }
    }


    private void ÑheckSpritesForWin(Tile tile, Vector2[] dirArray)
    {
        List<Tile> cashFindSprite = new List<Tile>();
        for (int i = 0; i < dirArray.Length; i++)
        {
            cashFindSprite.AddRange(FindMatch(tile, dirArray[i]));
        }

        for (int i = 0; i < 5; i++)
        {
            if (tileArray[0, i].spriteRenderer.sprite == tileArray[0, 6].spriteRenderer.sprite)
            {
                yellow = true;
            }
            else
            {
                yellow = false;
                break;
            }

            if (tileArray[2, i].spriteRenderer.sprite == tileArray[2, 6].spriteRenderer.sprite)
            {
                blue = true;
            }
            else
            {
                blue = false;
                break;
            }

            if (tileArray[4, i].spriteRenderer.sprite == tileArray[4, 6].spriteRenderer.sprite)
            {
                red = true;
            }
            else
            {
                red = false;
                break;
            }
        }
        if (red && blue && yellow && cashFindSprite.Count >= 4)
        {
            Destroy(gameObject);
            _gameOver = new GameOverController(_placeForUi);
        }


    }

    private void FindAllMatch(Tile tile)
    {
        if (tile.isEmpty)
        {
            return;
        }
        ÑheckSpritesForWin(tile, new Vector2[2] { Vector2.up, Vector2.down });
        ÑheckSpritesForWin(tile, new Vector2[2] { Vector2.left, Vector2.right });
    }

    private List<Tile> FindMatch(Tile tile, Vector2 dir)
    {
        List<Tile> cashFindTiles = new List<Tile>();
        RaycastHit2D hit = Physics2D.Raycast(tile.transform.position, dir);
        while(hit.collider!=null && hit.collider.gameObject.GetComponent<Tile>().spriteRenderer.sprite == tile.spriteRenderer.sprite)
        {
            cashFindTiles.Add(hit.collider.gameObject.GetComponent<Tile>());
            hit= Physics2D.Raycast(hit.collider.gameObject.transform.position, dir);
        }
        return cashFindTiles;
    }



    private void SwapTwoTiles(Tile tile)
    {
        if (oldSelectTile.spriteRenderer.sprite==tile.spriteRenderer.sprite)
        {
            return;
        }
        if (tile.spriteRenderer.sprite == tileSprite[1])
        {
            Sprite cashSprite = oldSelectTile.spriteRenderer.sprite;
            oldSelectTile.spriteRenderer.sprite = tile.spriteRenderer.sprite;
            tile.spriteRenderer.sprite = cashSprite;
        }
        else
        {
            return;
        }
    }

    private List<Tile> AdjacentTiles()
    {

        List<Tile> cashTiles = new List<Tile>();
        Tile cashTile;
        for (int i = 0; i < dirRay.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(oldSelectTile.transform.position, dirRay[i]);
            
            if (hit.collider != null )
            {
                cashTile = hit.collider.gameObject.GetComponent<Tile>();
                cashTiles.AddRange(SearchFreeTiles(cashTile,i, cashTiles));
                //cashTiles.Add(hit.collider.gameObject.GetComponent<Tile>());
            }
        }
        return cashTiles;
    }

    private List<Tile> SearchFreeTiles(Tile cashTile, int i, List<Tile> cashTiles)
    {

        if (cashTile.spriteRenderer.sprite == tileSprite[1])
        {
            cashTiles.Add(cashTile);
            RaycastHit2D hit = Physics2D.Raycast(cashTile.transform.position, dirRay[i]);
            if (hit.collider != null)
            {
                cashTile = hit.collider.gameObject.GetComponent<Tile>();
                SearchFreeTiles(cashTile, i, cashTiles);
            }
        }
        return cashTiles;
    }


}
