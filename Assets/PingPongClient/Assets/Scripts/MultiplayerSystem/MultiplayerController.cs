using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
using Zenject;

namespace MultiplayerSystem
{
    public class MultiplayerController : SocketIOComponent,IMultiplayerController
    {
        private SignalBus signalBus; 
        public override void Start()
        {
            base.Start();
            SetupEvents();
        }

        private void SetupEvents()
        {
            On(ServerEvents.ON_MOVE_FORWARD, OnMoveForward);
        }

        private void OnMoveForward(SocketIOEvent socketIOEvent)
        {
            signalBus.TryFire(new OnMoveForwardSignal(socketIOEvent));
        }

        public override void Update()
        {
            base.Update();
        }

        public void MoveForward()
        {
           
        }

        public void SetSignalBus(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        private void SendDataToServer(string eventName, JSONObject data)
        {
            Emit(eventName, data);
        }
    }
}