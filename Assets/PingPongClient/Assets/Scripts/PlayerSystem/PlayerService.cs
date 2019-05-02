using System;
using UnityEngine;
using System.Collections.Generic;
using MultiplayerSystem;
using Zenject;
using ScriptableObjects;

namespace PlayerSystem
{
    public class PlayerService :IPlayerService
    {
        private SignalBus signalBus;
        private string localPlayerID;
        private IPlayerController localPlayerController;        
        private List<IPlayerController> remotePlayerControllerList = new List<IPlayerController>();
        private PlayerScriptableObject playerScriptableObj;
        private OpponentScriptableObject opponentScriptableObj;
        public PlayerService(SignalBus signalBus,PlayerScriptableObject playerScriptableObject,OpponentScriptableObject opponentScriptableObject)
        {
            this.signalBus = signalBus;
            signalBus.Subscribe<OnUserConnectedSignal>(OnLocalUserConnected);
            signalBus.Subscribe<OnOpponentConnectedSignal>(OnRemoteUserConnected);  
            this.playerScriptableObj = playerScriptableObject;
            opponentScriptableObj = opponentScriptableObject;
        }

        private void OnRemoteUserConnected(OnOpponentConnectedSignal onOpponentConnectedSignal)
        {
            IPlayerController remotePlayerController;
            remotePlayerController = new RemotePlayerController(onOpponentConnectedSignal.GetPlayerID(),this);
            remotePlayerController.SetSignalBus(signalBus);
            remotePlayerController.SpawnView(opponentScriptableObj.playerView, onOpponentConnectedSignal.GetSpawnPosition());
            remotePlayerControllerList.Add(remotePlayerController);
        }

        private void OnLocalUserConnected(OnUserConnectedSignal onUserConnectedSignal)
        {
            localPlayerID=onUserConnectedSignal.GetPlayerID();
            localPlayerController = new LocalPlayerController(localPlayerID, this);
            localPlayerController.SetSignalBus(signalBus);
            localPlayerController.SpawnView(playerScriptableObj.playerView, onUserConnectedSignal.GetSpawnPosition());
        }
    }
}
