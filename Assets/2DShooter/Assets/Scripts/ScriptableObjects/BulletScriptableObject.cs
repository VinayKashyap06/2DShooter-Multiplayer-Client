using UnityEngine;
using BulletSystem;
using System.Collections;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Bullet Prefab", menuName = "Custom Objects/Bullet/Bullet Prefab", order = 0)]
    public class BulletScriptableObject : ScriptableObject
    {
        public BulletView bulletView;
    }
}