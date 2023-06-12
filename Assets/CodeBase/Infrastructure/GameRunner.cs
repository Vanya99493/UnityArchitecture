using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstraper bootstrapperPrefab;
        
        private void Awake()
        {
            GameBootstraper bootstrapper = FindObjectOfType<GameBootstraper>();
            if (bootstrapper == null)
            {
                Instantiate(bootstrapperPrefab);
            }
        }
    }
}