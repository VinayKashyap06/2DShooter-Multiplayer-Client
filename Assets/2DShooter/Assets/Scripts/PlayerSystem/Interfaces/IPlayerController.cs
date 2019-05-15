using UnityEngine;
using Zenject;
namespace PlayerSystem
{
    public interface IPlayerController
    {
        void MoveForward(Vector3 position);
        void MoveBackward(Vector3 position);
        void SpawnView(PlayerView playerView, Vector3 position);
        string GetID();
        void SetSignalBus(SignalBus signalBus);
        void DestroyPlayer();
        void SpawnBullet(Vector3 velocity);
        Vector3 GetCurrentPosition();
    }
}