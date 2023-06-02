using Assets.CodeBase.Services.Input;

namespace Assets.CodeBase.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;

        public GameStateMachine stateMachine;

        public Game()
        {
            stateMachine = new GameStateMachine();
        }
    }
}