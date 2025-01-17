using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicRoomMgr : MonoBehaviour
{
    public GameObject[] m_Key;
    public GameObject[] m_WoodStock;

    public Button m_Hall2Btn = null;

    public Button m_PianoManBtn = null;

    public Image m_WoodStock2 = null;
    public Image m_Key2 = null;

    [Header("-------5Line-------")]
    public Image m_5LineBeforeImg = null;
    public Image m_5LineAfterImg = null;
    public Button m_5LineBtn = null;

    [Header("-------Gita-------")]
    public Button[] m_Gita;
    public Button m_GitaBeforeBtn = null;
    public Button m_GitaAfterBtn = null;

    [Header("-------SpeechBubble-------")]
    public Image m_Music_Speech1;
    public Image m_Music_Speech2;
    public static int KeyPressed = 1;

    void Start()
    {
        if (m_PianoManBtn != null)
            m_PianoManBtn.onClick.AddListener(() =>
            {
                m_Music_Speech1.gameObject.SetActive(false);

                SoundMgr.Instance.PlayPainoSound();

                m_5LineBeforeImg.gameObject.SetActive(false);
                m_5LineAfterImg.gameObject.SetActive(true);
                m_5LineBtn.gameObject.SetActive(true);

                m_GitaBeforeBtn.interactable = true; 
            });

        if (m_Hall2Btn != null)
            m_Hall2Btn.onClick.AddListener(() =>
            {
                SoundMgr.Instance.PlayMainSound();
                SceneManager.LoadScene("HallScene");
            });

        if (m_GitaBeforeBtn != null)
            m_GitaBeforeBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("MiniGameSc1");
            });


        for (int set_WoodStock = 0; set_WoodStock < GlobalValue.g_WoodStock.Length; set_WoodStock++)
        {
            if (0 < GlobalValue.g_WoodStock[set_WoodStock])
            {
                if (set_WoodStock < m_WoodStock.Length)
                {
                    m_WoodStock[set_WoodStock].SetActive(true);
                    m_WoodStock[0].SetActive(false);
                    m_WoodStock[2].SetActive(false);
                }
            }
        }

        for (int clear_Key = 0; clear_Key < GlobalValue.g_Key.Length; clear_Key++)
        {
            if (0 < GlobalValue.g_Key[clear_Key])
            {
                if (clear_Key < m_Key.Length)
                {
                    m_Key[clear_Key].SetActive(true);
                }
            }
        }

        for (int clear_Gita = 0; clear_Gita < GlobalValue.g_Gita.Length; clear_Gita++)
        {
            if (0 < GlobalValue.g_Gita[clear_Gita])
            {
                m_Gita[clear_Gita].gameObject.SetActive(true);
            }
        }
    }

    void Update()
    {
        if(m_GitaAfterBtn.gameObject.activeSelf == true)
        {
            m_Music_Speech1.gameObject.SetActive(false);
            m_Music_Speech2.gameObject.SetActive(true);
        }

        if (m_GitaAfterBtn != null)
        {
            m_GitaAfterBtn.onClick.AddListener(() =>
            {
                m_WoodStock2.gameObject.SetActive(true);
                GlobalValue.g_WoodStock[1] = 1;

                m_Key2.gameObject.SetActive(true);
                GlobalValue.g_Key[1] = 1;


                if(m_GitaAfterBtn.gameObject.activeSelf == true)
                {
                    SoundMgr.Instance.PlayGitaSound();
                }
            });
        }
    }
}
