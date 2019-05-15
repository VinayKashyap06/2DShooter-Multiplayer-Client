using UnityEngine;
using Zenject;
using ScriptableObjects;

namespace Commons
{
    [CreateAssetMenu(fileName = "Scriptable Settings", menuName = "Custom Objects/Installer/Scriptable Settings", order = 0)]
    public class ScriptableInstaller : ScriptableObjectInstaller
    {
        public PlayerScriptableObject playerScriptableObject;
        public OpponentScriptableObject opponentScriptableObject;
        public BulletScriptableObject bulletScriptableObject;
        public override void InstallBindings()
        {
            Container.BindInstances(playerScriptableObject);
            Container.BindInstances(opponentScriptableObject);
            Container.BindInstances(bulletScriptableObject);
        }
    }
}