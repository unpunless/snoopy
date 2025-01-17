using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LabRoomMgr : MonoBehaviour
{
    public GameObject[] m_Key;
    public GameObject[] m_WoodStock;

    public Button m_Hall3Btn = null;
    public Button m_Table = null;

    // Start is called before the first frame update
    void Start()
    {
        if (m_Hall3Btn != null)
            m_Hall3Btn.onClick.AddListener(() =>
            {
                // 키를 가지고 있을 경우, 저장
                SceneManager.LoadScene("HallScene");
            });

        if (m_Table != null)
            m_Table.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("MiniGameSc4");
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
                    for(int Set_key=0; Set_key<3; Set_key++)
                        m_Key[Set_key].SetActive(false);
                }
            }
        }

        for (int set_WoodStock = 0; set_WoodStock < GlobalValue.g_WoodStock.Length; set_WoodStock++)
        {
            if (0 < GlobalValue.g_WoodStock[set_WoodStock])
            {
                if (set_WoodStock < m_WoodStock.Length)
                {
                    m_WoodStock[set_WoodStock].SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
