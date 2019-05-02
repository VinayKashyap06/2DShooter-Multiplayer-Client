using UnityEngine;

namespace PlayerSystem
{
    public interface IPlayerController
    {
        void MoveForward();
        void MoveBackward();
        void SpawnView(PlayerView playerView, Vector3 position);
        string GetID();
    }
}