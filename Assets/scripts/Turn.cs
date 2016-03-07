using UnityEngine;
using System.Collections;

namespace HideAndSeek
{
    public class Turn : MonoBehaviour
    {
        public GameObject m_next_turn;

        protected void end_turn(GameObject next_turn = null)
        {
            if (next_turn == null)
            {
                next_turn = m_next_turn;
            }

            if (next_turn != null)
            {
                next_turn.SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }
}