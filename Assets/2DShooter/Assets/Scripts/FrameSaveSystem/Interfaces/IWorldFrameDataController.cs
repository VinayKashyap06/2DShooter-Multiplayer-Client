namespace FrameSaveSystem
{
    public interface IWorldFrameDataController
    {
        void Execute();     
        void SetupControllerData(JSONObject data);
        void MergeToPreviousData(JSONObject data);
    }
}