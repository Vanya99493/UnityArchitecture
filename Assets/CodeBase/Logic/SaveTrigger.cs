using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Logic
{
    public class SaveTrigger : MonoBehaviour
    {
        private ISavedLoadService _saveLoadService;

        public BoxCollider collider; 
        
        private void Awake()
        {
            _saveLoadService = AllServices.Container.Single<ISavedLoadService>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _saveLoadService.SaveProgress();
            
            Debug.Log("Progress saved.");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if (!collider)
            {
                return;
            }
            
            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position + collider.center, collider.size);
        }
    }
}