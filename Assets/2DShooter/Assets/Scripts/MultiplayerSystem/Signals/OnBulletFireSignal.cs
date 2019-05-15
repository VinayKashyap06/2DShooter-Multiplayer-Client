using UnityEngine;

namespace MultiplayerSystem
{
    public class OnBulletFireSignal
    {
        private JSONObject data;

        public OnBulletFireSignal(JSONObject data)
        {
            Debug.Log("data recived" + data);
            this.data = data.GetField("data").GetField("data");
            Debug.Log("data in data" + this.data);
        }
        public Vector3 GetVelocity()
        {
            JSONObject velocityData=data.GetField("velocity");
            Vector3 velocity = Vector3.zero;
            Debug.Log("velocitydata" + velocityData);
            velocityData.GetField(ref velocity.x, "x");
            velocity.y = 0;
            velocityData.GetField(ref velocity.z, "y");
            Debug.Log("Velocity of bullet spawned "+velocity);
            return velocity;
        }
        public string GetPlayerID()
        {
            string id = "";
            data.GetField(ref id, "playerID");
            return id;
        }
    }
}