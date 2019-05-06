using System;
using SocketIO;
using UnityEngine;

namespace MultiplayerSystem
{
    public class OnMoveForwardSignal
    {
        private JSONObject data;

        public OnMoveForwardSignal(JSONObject data)
        {
            this.data = data;
            Debug.Log("OnmoveforwardSignal called"+data);
        }
        public Vector3 GetNewPosition()
        {
            JSONObject dataObj = data.GetField("data");
            Vector3 pos = Vector3.zero;
            JSONObject positionObj = dataObj.GetField("data").GetField("newPosition");
            positionObj.GetField(ref pos.x, "x");
            positionObj.GetField(ref pos.y, "y");
            positionObj.GetField(ref pos.z, "z");
            return pos;
        }

        public string GetPlayerID()
        {
            JSONObject dataObj = data.GetField("data");
            
            string id = "";
            dataObj.GetField("data").GetField(ref id, "playerID");
            return id;
        }
    }
}