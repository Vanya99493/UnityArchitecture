using Assets.CodeBase.Logic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain curtain;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, curtain);
            _game.stateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}