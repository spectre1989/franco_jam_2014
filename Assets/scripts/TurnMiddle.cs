using UnityEngine;

namespace HideAndSeek
{
    public class TurnMiddle : Turn
    {
        public GameObject m_player;
        public GameObject m_dummy_camera;
        public float m_duration;
        public float m_range;
        public GUIStyleHolder m_gui_style;
        public GameObject m_next_turn_on_win;

        private float m_time_remaining;
        private Vector3 m_position_at_start;
        private float m_current_distance;

        private void OnEnable()
        {
            if (m_player != null)
            {
                set_player_active(m_player, true);
            }

            if (m_dummy_camera != null)
            {
                m_dummy_camera.SetActive(false);
            }

            m_time_remaining = m_duration;

            if (m_player != null)
            {
                m_position_at_start = m_player.transform.position;
                m_position_at_start.y = 0f;
            }
        }

        private void OnDisable()
        {
            if (m_player != null)
            {
                set_player_active(m_player, false);
            }

            if (m_dummy_camera != null)
            {
                m_dummy_camera.SetActive(true);
            }
        }

        private void Update()
        {
            // Duration > 0 means time based, otherwise range based
            if (m_duration > 0f)
            {
                if (m_time_remaining <= 0f)
                {
                    end_turn();
                }

                m_time_remaining -= Time.deltaTime;
            }
            else if( can_end_turn() && Input.GetKeyDown(KeyCode.Return) )
            {
                end_turn();
            }
        }

        private void OnGUI()
        {
            string msg = "";

            if (m_duration > 0f)
            {
                msg = m_time_remaining.ToString("0.00") + "s Remaining";
            }
            else
            {
                msg = "Distance " + m_current_distance.ToString("0.0") + "m/" + m_range.ToString("0.0") + "m, press [Enter] to end turn";
            }

            GUI.Label(new Rect(0, 0, Screen.width, 50), msg, m_gui_style.m_gui_style);
        }

        private void set_player_active(GameObject player, bool active)
        {
            FPSCamera fps_camera = player.GetComponent<FPSCamera>();
            if (fps_camera != null)
            {
                fps_camera.enabled = active;
            }

            FPSMovement fps_movement = player.GetComponent<FPSMovement>();
            if (fps_movement)
            {
                fps_movement.enabled = active;
            }

            player.transform.FindChild("camera").gameObject.SetActive(active);

            SeekerAttack seeker_attack = player.GetComponent<SeekerAttack>();
            if (seeker_attack != null)
            {
                seeker_attack.enabled = active;
            }

            MouseLook mouse_look = player.GetComponent<MouseLook>();
            if (mouse_look != null)
            {
                mouse_look.enabled = active;
            }

            CharacterMotor character_motor = player.GetComponent<CharacterMotor>();
            if (character_motor != null)
            {
                character_motor.enabled = active;
            }

            FPSInputController fps_input_controller = player.GetComponent<FPSInputController>();
            if (fps_input_controller != null)
            {
                fps_input_controller.enabled = active;
            }
        }

        public void win()
        {
            // check they aren't cheating on hider turn where distance is only limit
            if (!can_end_turn())
            {
                return;
            }

            end_turn(m_next_turn_on_win);
        }

        private bool can_end_turn()
        {
            if( m_duration > 0f )
            {
                return true;
            }


            if (m_player != null)
            {
                Vector3 pos = m_player.transform.position;
                pos.y = 0f;
                m_current_distance = Vector3.Distance(pos, m_position_at_start);

                if (m_current_distance > m_range)
                {
                    return false;
                }
            }

            return true;
        }
    }
}