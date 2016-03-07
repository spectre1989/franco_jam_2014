using UnityEngine;

namespace HideAndSeek
{
    public class FPSMovement : MonoBehaviour
    {
        public float m_run_speed;
        public float m_sprint_speed;
        public float m_jump_speed;
        public float m_air_control;

        private Vector3 m_velocity;

        private void Update()
        {
            CharacterController character_controller = this.GetComponent<CharacterController>();
            if (character_controller == null)
            {
                return;
            }

            Vector3 movement = new Vector3();

            if (Input.GetKey(KeyCode.W))
            {
                movement += transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement -= transform.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movement -= transform.right;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement += transform.right;
            }

            if (character_controller.isGrounded)
            {
                movement = movement.normalized * m_run_speed;

                m_velocity.x = movement.x;
                m_velocity.y = 0f;
                m_velocity.z = movement.z;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_velocity.y = m_jump_speed;
                }
            }
            else
            {
                m_velocity += movement.normalized * m_air_control * Time.deltaTime;

                Vector3 xz = new Vector3(m_velocity.x, 0f, m_velocity.z);
                if (xz.magnitude > m_run_speed)
                {
                    xz = xz.normalized * m_run_speed;
                    m_velocity.x = xz.x;
                    m_velocity.z = xz.z;
                }
            }

            m_velocity += Physics.gravity * Time.deltaTime;

            character_controller.Move(m_velocity * Time.deltaTime);
        }
    }
}