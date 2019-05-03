using System;
using System.Collections.Generic;
using System.Linq;


namespace FrameSaveSystem
{
    public interface IPlayerDataController
    {
        void Execute();
        void SetupDataToExecute(JSONObject data);
    }
}
