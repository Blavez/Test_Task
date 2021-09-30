using System.Collections.Generic;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = nameof(BoardConfig), menuName = "Configs/" + nameof(BoardConfig))]
    internal class BoardConfig : ScriptableObject
    {
        [field: SerializeField] public int xSize;
        [field: SerializeField] public int ySize;
        [field: SerializeField] public Tile tileGO { get; set; }
        [field: SerializeField] public List<Sprite> tileSprite { get;  set; }
    }
}
