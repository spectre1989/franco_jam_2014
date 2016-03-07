using UnityEngine;

namespace HideAndSeek
{
    public class SeekerAttack : MonoBehaviour
    {
        public Transform m_hider;
        public float m_range;
        public TurnMiddle m_turn_to_win;

        private void Update()
        {
            if (m_hider == null)
            {
                return;
            }

            // Make sure hider is in front of seeker
            if (transform.InverseTransformPoint(m_hider.position).z < 0f)
            {
                return;
            }

            if (Vector3.Distance(transform.position, m_hider.position) <= m_range && m_turn_to_win != null)
            {
                if (m_turn_to_win != null)
                {
                    m_turn_to_win.win();
                }
            }
        }
    }
}