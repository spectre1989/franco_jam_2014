using UnityEngine;

namespace HideAndSeek
{
    public class LightDritf : MonoBehaviour
    {
        public float m_drift_amount;

        private Vector3 m_original_local_rotation;

        private void Start()
        {
            m_original_local_rotation = transform.localEulerAngles;
        }

        private void Update()
        {
            transform.localEulerAngles = m_original_local_rotation + ( new Vector3( -Input.GetAxis("Mouse Y" ), Input.GetAxis("Mouse X"), 0f ) * m_drift_amount );
        }
    }
}