using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Commons;

namespace FrameSaveSystem
{
    public class PlayerDataController :IPlayerDataController
    {
        private JSONObject dataToExecute = new JSONObject();
        private string eventToExecute;
        public PlayerDataController()
        {

        }

        public void Execute()
        {
            SignalFactory.FireSignal(eventToExecute, dataToExecute);
        }

        public void SetupDataToExecute(JSONObject data)
        {
            dataToExecute = data;
            
            data.GetField(ref eventToExecute,"eventName");
        }
    }
}