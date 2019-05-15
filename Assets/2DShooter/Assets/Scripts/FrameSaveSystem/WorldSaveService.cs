using UnityEngine;
using Zenject;
using System;
using System.Collections.Generic;

namespace FrameSaveSystem
{
    public class WorldSaveService : IWorldSaveService
    {

        private Dictionary<int, IWorldFrameDataController> frameDataDict = new Dictionary<int, IWorldFrameDataController>();
        private DateTime dateTime = DateTime.UtcNow;
        
        
        public void ExecuteFrame(int frameCount)
        {
            //Debug.Log("<color=blue>Executing frame </color>" + frameCount);

            if (frameDataDict.ContainsKey(frameCount))
            {
                //execute if key present.
                frameDataDict[frameCount].Execute();
                frameDataDict.Remove(frameCount);
            }
        }

        public void AddFrameData(int frameNo, JSONObject data)
        {            
            if (frameDataDict.ContainsKey(frameNo))
            {
                frameDataDict[frameNo].MergeToPreviousData(data);
            }
            else
            {
                //Debug.Log("<color=green>Adding keys</color>" + frameNo);
                IWorldFrameDataController worldFrameDataController = new WorldFrameDataController();
                worldFrameDataController.SetupControllerData(data);
                frameDataDict.Add(frameNo, worldFrameDataController);
            }          
        }
    }
}
