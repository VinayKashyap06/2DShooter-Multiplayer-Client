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
        public Vector3 GetBulletPosition()
        {
            JSONObject positionData=data.GetField("position");
            Vector3 position = Vector3.zero;           
            positionData.GetField(ref position.x, "x");
            positionData.GetField(ref position.y, "y");
            position.z = 0;
            Debug.Log("<color=red>bullet position</color>" + position);
            return position;
        }
        public string GetPlayerID()
        {
            string id = "";
            data.GetField(ref id, "playerID");
            return id;
        }
        public float GetBulletSpeed()
        {
            float speed = 0;
            data.GetField(ref speed,"bulletSpeed");
            Debug.Log("<color=red>bullet speed</color>" + speed);
            return speed;
        }
    }
}