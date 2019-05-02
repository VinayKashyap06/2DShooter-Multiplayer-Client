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
            Debug.Log("OnUserConnectedSignal called" +socketIOEvent.data);
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
            JSONObject positionObj=socketIOEvent.data.GetField("playerPosition");
            positionObj.GetField(ref pos.x, "x");
            positionObj.GetField(ref pos.y, "y");
            positionObj.GetField(ref pos.z, "z");
            return pos; 
        }
    }
}