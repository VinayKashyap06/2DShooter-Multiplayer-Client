using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class LocalPlayerController : PlayerControllerBase
    {
        private string playerID;
        private IPlayerService playerService;
        private PlayerView thisPlayerView;
        private GameObject thisPlayer;

        public LocalPlayerController(string playerID, IPlayerService playerService)
        {
            this.playerID = playerID;
            this.playerService = playerService;
        }
        public override void SpawnView(PlayerView playerView, Vector3 position)
        {
            thisPlayer = GameObject.Instantiate(playerView.gameObject, position, Quaternion.identity);
            thisPlayerView = thisPlayer.GetComponent<PlayerView>();
            thisPlayerView.SetSignalBus(signalBus);
        }

        public override string GetID()
        {
            return playerID;
        }
    }
}
