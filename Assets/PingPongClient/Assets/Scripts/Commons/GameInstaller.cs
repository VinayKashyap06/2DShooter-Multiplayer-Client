using UnityEngine;
using System.Collections;
using Zenject;
using MultiplayerSystem;
using InputSystem;

namespace Commons
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            //Declare Signals
            Container.DeclareSignal<MoveForwardSignal>();
            Container.DeclareSignal<OnMoveForwardSignal>();


            //Bind Services
            Container.Bind(typeof(IMultiplayerService), typeof(IInitializable)).
                To<MultiplayerService>().
                AsSingle().
                NonLazy();

            Container.Bind(typeof(IInputService), typeof(ITickable)).
                To<InputService>().
                AsSingle().
                NonLazy();
        }
    }
}