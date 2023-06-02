using UnityEngine;

namespace Assets.CodeBase.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        public float rotationAngleX;
        public float distance;
        public float offsetY;

        [SerializeField] private Transform _following;

        private void LateUpdate()
        {
            if (_following == null)
            {
                return;
            }

            Quaternion rotation = Quaternion.Euler(rotationAngleX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -distance) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(GameObject following)
        {
            _following = following.transform;
        }

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition.y += offsetY;
            return followingPosition;
        }
    }
}