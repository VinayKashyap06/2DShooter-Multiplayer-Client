using SocketIO;
using UnityEngine;

namespace MultiplayerSystem
{
    public class OnOpponentConnectedSignal
    {
        private JSONObject data;

        public OnOpponentConnectedSignal(JSONObject data)
        {
            this.data = data;
            Debug.Log("OnUserConnectedSignal called");
        }
        public string GetPlayerID()
        {
            string id = "";
            data.GetField(ref id, "opponentID");
            return id;
        }
        public Vector3 GetSpawnPosition()
        {
            Vector3 pos = Vector3.zero;
            JSONObject positionObj = data.GetField("opponentPosition");
            positionObj.GetField(ref pos.x, "x");
            positionObj.GetField(ref pos.y, "y");
            positionObj.GetField(ref pos.z, "z");
            return pos;
        }
    }
}