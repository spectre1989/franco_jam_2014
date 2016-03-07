using UnityEngine;

namespace HideAndSeek
{
    public class MouseManager : MonoBehaviour
    {
        public float m_increment_size;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                change_sensetivity(m_increment_size);
            }

            if (Input.GetKeyDown(KeyCode.Minus))
            {
                change_sensetivity(-m_increment_size);
            }
        }

        private void change_sensetivity(float amount)
        {
            foreach (MouseLook mouse_look in FindObjectsOfType<MouseLook>())
            {
                mouse_look.sensitivityX += amount;
                if (mouse_look.sensitivityX < 0f)
                {
                    mouse_look.sensitivityX = 0f;
                }

                mouse_look.sensitivityY += amount;
                if (mouse_look.sensitivityY < 0f)
                {
                    mouse_look.sensitivityY = 0f;
                }
            }
        }
    }
}