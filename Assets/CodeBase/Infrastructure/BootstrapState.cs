using Assets.CodeBase.Services.Input;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string Main = "Main";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }

        public void Exit()
        {

        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadLevelState, string>(Main);

        private void RegisterServices()
        {
            Game.InputService = RegisterInputService();
        }

        private static IInputService RegisterInputService()
        {
            if (Application.isEditor)
            {
                return new StandalonInputService();
            }
            else
            {
                return new MobileInputService();
            }
        }
    }
}