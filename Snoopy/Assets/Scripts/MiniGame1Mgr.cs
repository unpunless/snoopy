using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MiniGame1Mgr : MonoBehaviour
{
    public GameObject[] m_Gita;
    public Button m_MusicRoomBtn = null;
    public Button m_5_line_Btn = null;

    void Start()
    {
        if (m_MusicRoomBtn != null)
            m_MusicRoomBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("MusicRoomScene");
            });

        for (int clear_Gita = 0; clear_Gita < GlobalValue.g_Gita.Length; clear_Gita++)
        {
            if (0 < GlobalValue.g_Gita[clear_Gita])
            {
                if (clear_Gita < m_Gita.Length)
                {
                    m_Gita[clear_Gita].SetActive(true);
                }
            }
        }
    }
    void Update()
    {
        if (m_5_line_Btn != null)
            m_5_line_Btn.onClick.AddListener(() =>
            {
                m_Gita[0].SetActive(false);
                GlobalValue.g_Gita[0] = 1;
                m_Gita[1].SetActive(true);
                GlobalValue.g_Gita[1] = 1;
            });
    }
}
