using SocketIO;
using UnityEngine;

namespace MultiplayerSystem
{
    public class OnUserConnectedSignal
    {
        private JSONObject data;

        public OnUserConnectedSignal(JSONObject data)
        {
            this.data = data;
            Debug.Log("OnUserConnectedSignal called" +data);
        }
        public string GetPlayerID()
        {
            string id = "";
            data.GetField(ref id, "playerID");
            return id;
        }
        public Vector3 GetSpawnPosition()
        {
            Vector3 pos = Vector3.zero;
            JSONObject positionObj=data.GetField("playerPosition");
            positionObj.GetField(ref pos.x, "x");
            positionObj.GetField(ref pos.y, "y");
            positionObj.GetField(ref pos.z, "z");
            return pos; 
        }
        public int GetFrameNo()
        {
            int frameNo = 0;
            data.GetField(ref frameNo, "startFrame");
            return frameNo;
        }
    }
}