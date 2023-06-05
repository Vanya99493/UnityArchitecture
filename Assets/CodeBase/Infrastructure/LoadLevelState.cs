using Assets.CodeBase.CameraLogic;
using Assets.CodeBase.Logic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPoint = "InitialPoint";
        private const string HeroPath = "Hero/Player";
        private const string HudPath = "Hud/Hud";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            GameObject initialPoint = GameObject.FindWithTag(InitialPoint);
            GameObject hero = Instantiate(HeroPath, initialPoint.transform.position);
            Instantiate(HudPath);

            CameraFollow(hero);

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject hero) =>
            Camera.main.GetComponent<CameraFollow>().Follow(hero);

        private GameObject Instantiate(string path)
        {
            var heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab);
        }

        private GameObject Instantiate(string path, Vector3 at)
        {
            var heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab, at, Quaternion.identity );
        }
    }
}