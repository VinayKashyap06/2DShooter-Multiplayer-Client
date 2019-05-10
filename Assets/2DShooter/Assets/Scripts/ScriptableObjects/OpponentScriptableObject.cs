using UnityEngine;
using PlayerSystem;
using System.Collections;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Opponent Prefab", menuName = "Custom Objects/Player/Opponent Prefab", order = 0)]
    public class OpponentScriptableObject : ScriptableObject
    {
        public PlayerView playerView;
    }
}