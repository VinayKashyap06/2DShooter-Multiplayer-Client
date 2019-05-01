using SocketIO;
using UnityEngine;

namespace MultiplayerSystem
{
    public class OnMoveForwardSignal
    {
        private SocketIOEvent socketIOEvent;

        public OnMoveForwardSignal(SocketIOEvent socketIOEvent)
        {
            this.socketIOEvent = socketIOEvent;
            Debug.Log("OnmoveforwardSignal called");
        }
    }
}