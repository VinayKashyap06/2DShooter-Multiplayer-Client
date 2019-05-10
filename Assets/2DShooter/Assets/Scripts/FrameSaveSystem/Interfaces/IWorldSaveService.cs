namespace FrameSaveSystem
{
    public interface IWorldSaveService
    {       
        void ExecuteFrame(int frameCount);
        void AddFrameData(int frameNo, JSONObject data);
    }
}