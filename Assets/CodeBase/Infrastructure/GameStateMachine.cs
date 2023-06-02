using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Infrastructure
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this)
            };
        }

        public void Enter<T>() where T : IState
        {
            _activeState?.Exit();
            IState state = _states[typeof(T)];
            _activeState = state;
            state.Enter();
        }
    }
}