using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HallMgr : MonoBehaviour
{
    public GameObject[] m_Key;

    public Button m_LivingRoomBtn;
    public Button m_BedRoomBtn;
    public Button m_MusicRoomBtn;
    public Button m_LabRoomBtn;
    public Button m_ExitDoorBtn;
    public Button m_CfgBtn;


    //  public Image m_Key = null;

    // Start is called before the first frame update
    void Start()
    {

        if (m_LivingRoomBtn != null)
            m_LivingRoomBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("LivingRoomScene");
            });
        if (m_BedRoomBtn != null)
            m_BedRoomBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("BedRoomScene");
            });
        if (m_MusicRoomBtn != null)
            m_MusicRoomBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("MusicRoomScene");
            });
        if (m_LabRoomBtn != null)
            m_LabRoomBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("LabRoomScene");
            });
        if (m_ExitDoorBtn != null)
            m_ExitDoorBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("EndScene");
            });
        if (m_CfgBtn != null)
            m_CfgBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("CfgScene");
            });

        for (int clear_Key = 0; clear_Key < GlobalValue.g_Key.Length; clear_Key++)
        {
            if (0 < GlobalValue.g_Key[clear_Key])
            {
                if (clear_Key < m_Key.Length)
                {
                    m_Key[clear_Key].SetActive(true);
                }

                if (GlobalValue.g_Key[3] == 1)
                {
                    for (int Set_key = 0; Set_key < 3; Set_key++)
                        m_Key[Set_key].SetActive(false);
                }
            }

            Debug.Log(GlobalValue.g_Key[clear_Key]);

        }

        if (GlobalValue.g_Key.Length > 3 && GlobalValue.g_Key[0] > 0 && GlobalValue.g_Key[1] > 0 && GlobalValue.g_Key[2] > 0)
        {
            m_LabRoomBtn.interactable = true;
        }

        if (GlobalValue.g_Key.Length > 3 && GlobalValue.g_Key[3]>0)
        {
            m_ExitDoorBtn.gameObject.SetActive(true);
            m_ExitDoorBtn.interactable = true;
            Debug.Log("¹® ¿­¸² " + m_ExitDoorBtn.gameObject.activeSelf);
        }
    }

    public void GoToCfgScene()
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("CfgScene");
    }

}
