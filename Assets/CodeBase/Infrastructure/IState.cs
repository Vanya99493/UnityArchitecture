namespace Assets.CodeBase.Infrastructure
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}