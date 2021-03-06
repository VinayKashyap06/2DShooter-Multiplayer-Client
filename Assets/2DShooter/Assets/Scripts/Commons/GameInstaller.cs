﻿using UnityEngine;
using System.Collections;
using Zenject;
using MultiplayerSystem;
using InputSystem;
using PlayerSystem;
using FrameSaveSystem;
using BulletSystem;

namespace Commons
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            //Declare Signals
            Container.DeclareSignal<MoveForwardSignal>();
            Container.DeclareSignal<MoveBackwardSignal>();
            Container.DeclareSignal<OnMoveForwardSignal>();
            Container.DeclareSignal<OnMoveBackwardSignal>();
            Container.DeclareSignal<OnOpponentConnectedSignal>();
            Container.DeclareSignal<OnUserConnectedSignal>();
            Container.DeclareSignal<OnUserDisconnectedSignal>();
            Container.DeclareSignal<OnBulletFireSignal>();
            Container.DeclareSignal<FireSignal>();


            //Bind Services
            Container.Bind(typeof(IMultiplayerService), typeof(IInitializable)).
                To<MultiplayerService>().
                AsSingle().
                NonLazy();

            Container.Bind(typeof(IInputService), typeof(ITickable)).
                To<InputService>().
                AsSingle().
                NonLazy();

            Container.Bind(typeof(IFrameService), typeof(IFixedTickable)).
                To<FrameService>().
                AsSingle().
                NonLazy();

            Container.Bind<IPlayerService>().
                To<PlayerService>().
                AsSingle().
                NonLazy();

            Container.Bind<IWorldSaveService>().
                To<WorldSaveService>().
                AsSingle().
                NonLazy();

            Container.Bind<IBulletService>().
                To<BulletService>().
                AsSingle().
                NonLazy();

        }
    }
}