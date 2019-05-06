using System;
using UnityEngine;

namespace MultiplayerSystem
{
    public class OnUserDisconnectedSignal
    {
        private JSONObject data;

        public OnUserDisconnectedSignal(JSONObject data)
        {
            this.data = data;
            Debug.Log("Destroy this player"+data);
        }

        public string GetPlayerID()
        {
            string pid = "";
            data.GetField(ref pid, "playerID");
            return pid;
        }
    }
}