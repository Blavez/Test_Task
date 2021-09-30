using Profile;
using System.Collections.Generic;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = nameof(PlayerProfile), menuName = "Configs/" + nameof(PlayerProfile))]
    internal class PlayerProfile : ScriptableObject
    {
       [field: SerializeField] public GameState GameState { get; private set; }
    }
}
