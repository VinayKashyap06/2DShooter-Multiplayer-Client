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
            Vector3 pos = Vector3.zero;
            JSONObject positionObj = socketIOEvent.data.GetField("opponentPosition");
            positionObj.GetField(ref pos.x, "x");
            positionObj.GetField(ref pos.y, "y");
            positionObj.GetField(ref pos.z, "z");
            return pos;
        }
    }
}