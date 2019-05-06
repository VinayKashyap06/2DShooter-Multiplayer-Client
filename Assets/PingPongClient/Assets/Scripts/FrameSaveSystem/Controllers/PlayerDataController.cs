using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Commons;
using System;

namespace FrameSaveSystem
{
    public class PlayerDataController :IPlayerDataController
    {
        private JSONObject dataToExecute = new JSONObject();
        private string eventToExecute="";
        public PlayerDataController()
        {

        }

        public void Execute()
        {
            Debug.Log("execute called for player data controller==> event to execute"+eventToExecute+ "date to execute"+dataToExecute);
            SignalFactory.FireSignal(eventToExecute, dataToExecute);
        }

        public void SetupDataToExecute(JSONObject data)
        {
            dataToExecute = data;
            
            data.GetField(ref eventToExecute,"eventName");
        }

        public void MergeToPreviousData(JSONObject data)
        {
            //Debug.Log("Merging data [player data controller]" );
            dataToExecute.Merge(data);
            Debug.Log("Merging data [player data controller]" + dataToExecute);

            if (eventToExecute == "" || eventToExecute == null)
            {
                dataToExecute.GetField("data").GetField(ref eventToExecute,"eventName");
                Debug.Log("event to execute set" + eventToExecute);
            }
        }
    }
}