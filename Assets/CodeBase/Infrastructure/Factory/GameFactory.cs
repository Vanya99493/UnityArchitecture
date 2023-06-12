using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject initialPoint)
        {
            return InstantiateRegistered(AssetPath.HeroPath, initialPoint.transform.position);
        }

        public void CreateHud()
        {
            InstantiateRegistered(AssetPath.HudPath);
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 position)
        {
            GameObject hero = _assets.Instantiate(prefabPath, position);
            RegisterProgressWatchers(hero);
            return hero;
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject hero = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(hero);
            return hero;
        }

        private void RegisterProgressWatchers(GameObject hero)
        {
            foreach (ISavedProgressReader progressReader in hero.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
            {
                ProgressWriters.Add(progressWriter);
            }
            ProgressReaders.Add(progressReader);
        }
    }
}