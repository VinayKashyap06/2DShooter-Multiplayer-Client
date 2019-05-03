using UnityEngine;
using Zenject;
using System.Collections.Generic;

namespace FrameSaveSystem
{
    public class WorldSaveService : IWorldSaveService
    {

        private Dictionary<int, IWorldFrameDataController> frameDataDict = new Dictionary<int, IWorldFrameDataController>();      
        public void ExecuteFrame(int frameCount)
        {
            if (frameDataDict.ContainsKey(frameCount))
            {
                frameDataDict[frameCount].Execute();
            }
        }

        public void AddFrameData(int frameNo, JSONObject data)
        {
            IWorldFrameDataController worldFrameDataController = new WorldFrameDataController();            
            worldFrameDataController.SetupControllerData(data);
            frameDataDict.Add(frameNo, worldFrameDataController);
        }
    }
}
