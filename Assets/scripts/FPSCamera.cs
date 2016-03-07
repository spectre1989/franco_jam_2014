using UnityEngine;

namespace HideAndSeek
{
    public class FPSCamera : MonoBehaviour
    {
        public float m_mouse_sensitivity;
        public Transform m_x_axis;
        public Transform m_y_axis;
        public Vector2 m_x_min_max;

        private void Start()
        {
            Screen.lockCursor = true;
        }

        private void OnDestroy()
        {
            Screen.lockCursor = false;
        }

        private void Update()
        {
            // Only x axis has clamping
            Vector3 euler = m_x_axis.localEulerAngles;

            // Normalise between -180f to 180f, so clamping won't get confused
            Utils.normalise_angle(ref euler.x);

            // Add rotation
            euler.x += -Input.GetAxis("Mouse Y") * m_mouse_sensitivity;

            // Clamp
            euler.x = Mathf.Clamp(euler.x, m_x_min_max.x, m_x_min_max.y);

            // Write
            m_x_axis.localEulerAngles = euler;

            // Y axis is easier
            euler = m_y_axis.localEulerAngles;
            euler.y += Input.GetAxis("Mouse X") * m_mouse_sensitivity;
            m_y_axis.localEulerAngles = euler;
        }
    }
}