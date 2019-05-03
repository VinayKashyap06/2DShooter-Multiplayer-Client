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
            Vector3 pos = Vector3.zero;
            JSONObject positionObj = data.GetField("newPosition");
            positionObj.GetField(ref pos.x, "x");
            positionObj.GetField(ref pos.y, "y");
            positionObj.GetField(ref pos.z, "z");
            return pos;
        }

        public string GetPlayerID()
        {
            string id = "";
            data.GetField(ref id, "playerID");
            return id;
        }
    }
}