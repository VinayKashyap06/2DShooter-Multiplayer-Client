using System;
using UnityEngine;
using System.Collections.Generic;
using MultiplayerSystem;
using Zenject;
using BulletSystem;
using ScriptableObjects;

namespace PlayerSystem
{
    public class PlayerService : IPlayerService
    {
        private SignalBus signalBus;
        private string localPlayerID;
        private IPlayerController localPlayerController;
        private List<IPlayerController> remotePlayerControllerList = new List<IPlayerController>();
        private PlayerScriptableObject playerScriptableObj;
        private OpponentScriptableObject opponentScriptableObj;
        private IBulletService bulletService;
        public PlayerService(IBulletService bulletService, SignalBus signalBus, PlayerScriptableObject playerScriptableObject, OpponentScriptableObject opponentScriptableObject)
        {
            this.bulletService = bulletService;
            this.signalBus = signalBus;
            this.playerScriptableObj = playerScriptableObject;
            opponentScriptableObj = opponentScriptableObject;
            signalBus.Subscribe<OnUserConnectedSignal>(OnLocalUserConnected);
            signalBus.Subscribe<OnUserDisconnectedSignal>(OnUserDisconnected);
            signalBus.Subscribe<OnOpponentConnectedSignal>(OnRemoteUserConnected);
            signalBus.Subscribe<OnMoveBackwardSignal>(OnMoveBackward);
            signalBus.Subscribe<OnMoveForwardSignal>(OnMoveForward);
            signalBus.Subscribe<OnBulletFireSignal>(OnBulletFired);
        }

        private void OnBulletFired(OnBulletFireSignal onBulletFireSignal)
        {
            Debug.Log("on bullet fired called");
          //  string id = onBulletFireSignal.GetPlayerID();
            Vector3 position = onBulletFireSignal.GetBulletPosition();
            float speed = onBulletFireSignal.GetBulletSpeed();
            bulletService.SpawnBullet(position,speed);        
        }

        private void OnUserDisconnected(OnUserDisconnectedSignal onUserDisconnectedSignal)
        {
            Debug.Log("Destroying player" + onUserDisconnectedSignal.GetPlayerID());
            if (onUserDisconnectedSignal.GetPlayerID() == localPlayerID)
            {
                localPlayerController.DestroyPlayer();
                localPlayerController = null;
            }
            else
            {
                int indexToRemove = GetRemotePlayerIndex(onUserDisconnectedSignal.GetPlayerID());
                remotePlayerControllerList[indexToRemove].DestroyPlayer();                
                remotePlayerControllerList.RemoveAt(indexToRemove);
            }
        }
        private void OnRemoteUserConnected(OnOpponentConnectedSignal onOpponentConnectedSignal)
        {
            IPlayerController remotePlayerController;
            remotePlayerController = new RemotePlayerController(onOpponentConnectedSignal.GetPlayerID(), this);
            remotePlayerController.SetSignalBus(signalBus);
            remotePlayerController.SpawnView(opponentScriptableObj.playerView, onOpponentConnectedSignal.GetSpawnPosition());
            remotePlayerControllerList.Add(remotePlayerController);
        }
        private void OnLocalUserConnected(OnUserConnectedSignal onUserConnectedSignal)
        {
            localPlayerID = onUserConnectedSignal.GetPlayerID();
            localPlayerController = new LocalPlayerController(localPlayerID, this);
            localPlayerController.SetSignalBus(signalBus);
            localPlayerController.SpawnView(playerScriptableObj.playerView, onUserConnectedSignal.GetSpawnPosition());
        }

        private void OnMoveForward(OnMoveForwardSignal onMoveForwardSignal)
        {
            if (onMoveForwardSignal.GetPlayerID() != localPlayerID)
            {
                remotePlayerControllerList[GetRemotePlayerIndex(onMoveForwardSignal.GetPlayerID())].MoveForward(onMoveForwardSignal.GetNewPosition());
            }
            else
            {
                localPlayerController.MoveForward(onMoveForwardSignal.GetNewPosition());
            }
        }
        private void OnMoveBackward(OnMoveBackwardSignal onMoveBackwardSignal)
        {
            if (onMoveBackwardSignal.GetPlayerID() != localPlayerID)
            {
                remotePlayerControllerList[GetRemotePlayerIndex(onMoveBackwardSignal.GetPlayerID())].MoveBackward(onMoveBackwardSignal.GetNewPosition());                
            }
            else
            {
                localPlayerController.MoveBackward(onMoveBackwardSignal.GetNewPosition());
            }
        }

        public int GetRemotePlayerIndex(string id)
        {
            for (int i = 0; i < remotePlayerControllerList.Count; i++)
            {
                if (remotePlayerControllerList[i].GetID() == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
