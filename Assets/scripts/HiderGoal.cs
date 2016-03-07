using UnityEngine;

namespace HideAndSeek
{
    public class HiderGoal : MonoBehaviour
    {
        public TurnMiddle m_turn_to_win;

        private void OnTriggerEnter(Collider collider)
        {
            Transform root = collider.transform.root;
            if (root.name == "hider")
            {
                if (m_turn_to_win != null)
                {
                    m_turn_to_win.win();
                }
            }
        }
    }
}