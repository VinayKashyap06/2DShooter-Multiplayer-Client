using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
using FrameSaveSystem;
using PlayerSystem;
using Zenject;

namespace MultiplayerSystem
{
    public class MultiplayerController : SocketIOComponent,IMultiplayerController
    {
        private SignalBus signalBus;
        private IWorldSaveService worldSaveService;
        private IFrameService frameService;
        public override void Start()
        {
            base.Start();
            SetupEvents();
        }

        private void SetupEvents()
        {        
            On(ServerEvents.ON_USER_CONNECTED, OnUserConnected);
            On(ServerEvents.ON_OPPONENT_CONNECTED, OnOpponentConnected);
            On(ServerEvents.ON_USER_DISCONNECTED, OnUserDisconnected);
            On(ServerEvents.ON_ADD_FRAME_DATA, OnAddFrameData);
        }

        private void OnUserDisconnected(SocketIOEvent socketIOEvent)=> signalBus.TryFire(new OnUserDisconnectedSignal(socketIOEvent.data));

        private void OnAddFrameData(SocketIOEvent socketIOEvent)
        {
           // Debug.Log("incoming data" + socketIOEvent.data);
            int frameNo = 0;
            socketIOEvent.data.GetField(ref frameNo,"frameNo");
//            Debug.Log("frame no received" +frameNo);
            worldSaveService.AddFrameData(frameNo, socketIOEvent.data);
        }

        private void OnUserConnected(SocketIOEvent socketIOEvent)=>    signalBus.TryFire(new OnUserConnectedSignal(socketIOEvent.data));        
        private void OnOpponentConnected(SocketIOEvent socketIOEvent)=> signalBus.TryFire(new OnOpponentConnectedSignal(socketIOEvent.data));
        //private void OnMoveBackward(SocketIOEvent socketIOEvent)=> signalBus.TryFire(new OnMoveBackwardSignal(socketIOEvent));
        //private void OnMoveForward(SocketIOEvent socketIOEvent) =>   signalBus.TryFire(new OnMoveForwardSignal(socketIOEvent));  
        
        public void SetSignalBus(SignalBus signalBus)
        {
            this.signalBus = signalBus;
            signalBus.Subscribe<MoveForwardSignal>(MoveForward);
            signalBus.Subscribe<MoveBackwardSignal>(()=> SendDataToServer(ServerEvents.MOVE_BACKWARD, new JSONObject()));
        }
        public void SetupServices(IWorldSaveService worldSaveService, IFrameService frameService)
        {
            this.worldSaveService = worldSaveService;
            this.frameService = frameService;
        }

        private void SendDataToServer(string eventName, JSONObject data)
        {
            Emit(eventName, data);
        }       
        private void MoveForward()
        {
            JSONObject dataToSend = new JSONObject();
            dataToSend.AddField("frameNo",frameService.GetFrameCount());
          //  Debug.Log("sending data "+ dataToSend);
            SendDataToServer(ServerEvents.MOVE_FORWARD, dataToSend);
        }
    }
}