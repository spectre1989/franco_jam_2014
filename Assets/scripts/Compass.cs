using UnityEngine;

namespace HideAndSeek
{
    public class Compass : MonoBehaviour
    {
        public Camera m_camera;
        public Transform[] m_end_points;

        private void OnGUI()
        {
            if (m_end_points != null && m_camera != null)
            {
                foreach (Transform end_point in m_end_points)
                {
                    Vector3 screen_point = m_camera.WorldToScreenPoint(end_point.position);

                    // -ve z means it's behind the camera, so only draw when +ve
                    if (screen_point.z > 0f)
                    {
                        GUI.Box(new Rect(screen_point.x - 40, Screen.height - screen_point.y - 10, 80, 20), "End Zone");
                    }
                }
            }
        }
    }
}