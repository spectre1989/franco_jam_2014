using System;
using UnityEngine;

namespace HideAndSeek
{
    public class TurnWin : TurnStart
    {
        [Serializable]
        public class PlayerInfo
        {
            public Transform m_player;
            public Transform m_spawn;
        }

        public AudioSource m_on_enable_audio;
        public AudioSource m_on_disable_audio;
        public PlayerInfo[] m_players;

        private void OnEnable()
        {
            if (m_on_disable_audio != null)
            {
                m_on_disable_audio.Stop();
            }
            if (m_on_enable_audio != null)
            {
                m_on_enable_audio.Play();
            }
        }

        private void OnDisable()
        {
            if (m_on_disable_audio != null)
            {
                m_on_disable_audio.Play();
            }
            if (m_on_enable_audio != null)
            {
                m_on_enable_audio.Stop();
            }

            if (m_players != null)
            {
                foreach (PlayerInfo player_info in m_players)
                {
                    if (player_info != null && player_info.m_player != null && player_info.m_spawn != null)
                    {
                        player_info.m_player.position = player_info.m_spawn.position;
                        player_info.m_player.rotation = player_info.m_spawn.rotation;
                    }
                }
            }
        }
    }
}