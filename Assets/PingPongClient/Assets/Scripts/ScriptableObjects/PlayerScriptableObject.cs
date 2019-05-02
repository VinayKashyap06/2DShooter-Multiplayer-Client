using UnityEngine;
using PlayerSystem;
using System.Collections;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Prefab", menuName = "Custom Objects/Player/Player Prefab", order = 0)]
    public class PlayerScriptableObject : ScriptableObject
    {
        public PlayerView playerView;
    }
}