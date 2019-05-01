using UnityEngine;
using System.Collections;
using Zenject;
using MultiplayerSystem;

namespace Commons
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            //Declare Signals
            Container.DeclareSignal<OnMoveForwardSignal>();


            //Bind Services
            Container.Bind(typeof(IMultiplayerService), typeof(IInitializable)).
                To<MultiplayerService>().
                AsSingle().
                NonLazy();
        }
    }
}