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
            Debug.Log("OnmoveforwardSignal called"+socketIOEvent.data);
        }
        public Vector3 GetNewPosition()
        {
            Vector3 pos = Vector3.zero;
            JSONObject positionObj = socketIOEvent.data.GetField("newPosition");
            positionObj.GetField(ref pos.x, "x");
            positionObj.GetField(ref pos.y, "y");
            positionObj.GetField(ref pos.z, "z");
            return pos;
        }

    }
}