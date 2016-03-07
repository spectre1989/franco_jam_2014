using UnityEngine;

namespace HideAndSeek
{
    public class TurnStart : Turn
    {
        public string m_message;
        public GUIStyleHolder m_gui_style;

        private void Start()
        {
            m_message = m_message.Replace("\\n", "\n");
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            {
                end_turn();
            }
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), this.m_message, this.m_gui_style.m_gui_style);
        }
    }
}