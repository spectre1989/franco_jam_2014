using UnityEngine;

namespace HideAndSeek
{
    public class LightDrift : MonoBehaviour
    {
        public Vector3 m_position_drift;
        public Vector2 m_rotation_drift;
        public float m_position_easing;
        public float m_rotation_easing;

        private Vector3 m_last_position;
        private Vector3 m_target_local_position;
        private Vector3 m_target_local_rotation;

        private void OnStart()
        {
            m_last_position = transform.parent.position;
            m_target_local_position = transform.localPosition;
            m_target_local_rotation = transform.localEulerAngles;
        }

        private void Update()
        {
            // Position
            Vector3 position_delta = transform.InverseTransformDirection( transform.parent.position - m_last_position );
            
            transform.localPosition = transform.localPosition - (position_delta.multiply(m_position_drift));
            if (m_position_easing != 0f)
            {
                transform.localPosition += (m_target_local_position - transform.localPosition) * m_position_easing * Time.deltaTime;
            }

            m_last_position = transform.parent.position;

            // Rotation
            Vector3 new_local_euler_angles = transform.localEulerAngles - (new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f).multiply(m_rotation_drift));
            if (m_rotation_easing != 0f)
            {
                Vector3 current_to_target_rotation = (m_target_local_rotation - new_local_euler_angles);
                Utils.normalise_angle(ref current_to_target_rotation);
                new_local_euler_angles += current_to_target_rotation * m_rotation_easing * Time.deltaTime;
            }
            transform.localEulerAngles = new_local_euler_angles;
        }
    }
}