using SocketIO;
using UnityEngine;

namespace MultiplayerSystem
{
    public class OnUserConnectedSignal
    {
        private SocketIOEvent socketIOEvent;

        public OnUserConnectedSignal(SocketIOEvent socketIOEvent)
        {
            this.socketIOEvent = socketIOEvent;
            Debug.Log("OnUserConnectedSignal called");
        }
        public string GetPlayerID()
        {
            string id = "";
            socketIOEvent.data.GetField(ref id, "playerID");
            return id;
        }
        public Vector3 GetSpawnPosition()
        {
            Vector3 pos = Vector3.zero;
            return pos;
        }
    }
}