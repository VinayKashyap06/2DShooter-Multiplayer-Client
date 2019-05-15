using MultiplayerSystem;
using UnityEngine;

namespace PlayerSystem
{
    public class RemotePlayerController : PlayerControllerBase
    {
        private string playerID;
        private IPlayerService playerService;
        private PlayerView thisPlayerView;
        private GameObject thisPlayer;

        public RemotePlayerController(string playerID,IPlayerService playerService)
        {
            this.playerID = playerID;
            this.playerService = playerService;
        }
        public override void SpawnView(PlayerView playerView, Vector3 position)
        {
            thisPlayer = GameObject.Instantiate(playerView.gameObject, position, Quaternion.identity);
            thisPlayerView = thisPlayer.GetComponent<PlayerView>();
            Debug.Log("thisplayerView", thisPlayerView.gameObject);
        }
        public override string GetID()
        {
            return playerID;
        }
        public override void MoveBackward(Vector3 position)
        {
            Debug.Log("remote move back");
            thisPlayerView.OnMoveBackward(position);
        }
        public override void MoveForward(Vector3 position)
        {
            Debug.Log("remote move forward");
            thisPlayerView.OnMoveForward(position);
        }
        public override void DestroyPlayer()
        {
            thisPlayerView.DestroySelf();
        }
        public override void SpawnBullet(Vector3 velocity)
        {
            thisPlayerView.SpawnBullet(velocity);
        }
    }
}
