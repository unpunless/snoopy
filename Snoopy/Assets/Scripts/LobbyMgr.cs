using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMgr : MonoBehaviour
{
    [Header("Button")]
    public Button m_CfgBtn        = null;     //����â �̵� ��ư
    public Button m_StartBtn      = null;     //���� ���� ��ư

    // Start is called before the first frame update
    void Start()
    {
        GlobalValue.ClearGame();

        if (m_StartBtn != null)
            m_StartBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("HallScene");
            });

        if (m_CfgBtn != null)
            m_CfgBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("CfgScene");
            });
    }

    public void GoToCfgScene()
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("CfgScene");
    }
}
