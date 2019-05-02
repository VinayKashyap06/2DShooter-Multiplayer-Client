using SocketIO;
using UnityEngine;

namespace MultiplayerSystem
{
    public class OnOpponentConnectedSignal
    {
        private SocketIOEvent socketIOEvent;

        public OnOpponentConnectedSignal(SocketIOEvent socketIOEvent)
        {
            this.socketIOEvent = socketIOEvent;
            Debug.Log("OnUserConnectedSignal called");
        }
        public string GetPlayerID()
        {
            string id = "";
            socketIOEvent.data.GetField(ref id, "opponentID");
            return id;
        }
        public Vector3 GetSpawnPosition()
        {
            Vector3 pos = new Vector3(2,0,0);
            return pos;
        }
    }
}