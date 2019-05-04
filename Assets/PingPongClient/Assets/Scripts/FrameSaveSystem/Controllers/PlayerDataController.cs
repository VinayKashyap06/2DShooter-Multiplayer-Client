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
            Debug.Log("execute called for player data controller");
            SignalFactory.FireSignal(eventToExecute, dataToExecute);
        }

        public void SetupDataToExecute(JSONObject data)
        {
            dataToExecute = data;
            
            data.GetField(ref eventToExecute,"eventName");
        }

        public void MergeToPreviousData(JSONObject data)
        {
            dataToExecute.Merge(data);
            if(eventToExecute==""||eventToExecute==null)
                dataToExecute.GetField(ref eventToExecute, "eventName");
        }
    }
}