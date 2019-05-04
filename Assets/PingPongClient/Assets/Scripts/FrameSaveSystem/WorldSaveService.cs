using UnityEngine;
using Zenject;
using System.Collections.Generic;

namespace FrameSaveSystem
{
    public class WorldSaveService : IWorldSaveService
    {

        private Dictionary<int, IWorldFrameDataController> frameDataDict = new Dictionary<int, IWorldFrameDataController>();      
        public async void ExecuteFrame(int frameCount)
        {
            Debug.Log("<color=blue>Executing frame for dictionary</color>"+frameCount);
        
            if (frameDataDict.ContainsKey(frameCount))
            {
                //execute if key present.
                frameDataDict[frameCount].Execute();
                frameDataDict.Remove(frameCount);
            }
        }

        public async void AddFrameData(int frameNo, JSONObject data)
        {
            
            if (frameDataDict.ContainsKey(frameNo))
            {
                frameDataDict[frameNo].MergeToPreviousData(data);
            }
            else
            {
                IWorldFrameDataController worldFrameDataController = new WorldFrameDataController();
                worldFrameDataController.SetupControllerData(data);
                Debug.Log("<color=green>Adding keys</color>" + frameNo);
                frameDataDict.Add(frameNo, worldFrameDataController);
            }
          //  Debug.Log("Setting up controllers for frame");
        }
    }
}
