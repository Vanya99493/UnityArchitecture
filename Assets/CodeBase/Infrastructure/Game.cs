using Assets.CodeBase.Logic;
using Assets.CodeBase.Services.Input;

namespace Assets.CodeBase.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;

        public GameStateMachine stateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain);
        }
    }
}