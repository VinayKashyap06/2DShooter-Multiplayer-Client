using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
using InputSystem;
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
            On(ServerEvents.ON_USER_CONNECTED, OnUserConnected);
            On(ServerEvents.ON_OPPONENT_CONNECTED, OnOpponentConnected);
        }

        private void OnOpponentConnected(SocketIOEvent socketIOEvent)=> signalBus.TryFire(new OnOpponentConnectedSignal(socketIOEvent));
        private void OnUserConnected(SocketIOEvent socketIOEvent)=>    signalBus.TryFire(new OnUserConnectedSignal(socketIOEvent));        
        private void OnMoveForward(SocketIOEvent socketIOEvent) =>   signalBus.TryFire(new OnMoveForwardSignal(socketIOEvent));        

        public override void Update()
        {
            base.Update();
        }

        private void MoveForward()
        {
            JSONObject dataToSend = new JSONObject();
            SendDataToServer(ServerEvents.MOVE_FORWARD, dataToSend);
        }

        public void SetSignalBus(SignalBus signalBus)
        {
            this.signalBus = signalBus;
            signalBus.Subscribe<MoveForwardSignal>(MoveForward);
        }

        private void SendDataToServer(string eventName, JSONObject data)
        {
            Emit(eventName, data);
        }
       
    }
}