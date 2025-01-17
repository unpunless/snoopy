using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BedRoomMgr : MonoBehaviour
{
    public GameObject[] m_Key;
    public GameObject[] m_WoodStock;

    public Button m_HallBtn = null;
    public Button m_LampBtn = null;
    public Image m_WoodStock1 = null;

    public Image m_Key1Img = null;  // Ű �̹����� ����� UI ���

    public float m_FadeSpeed = 0.65f;
    private bool m_IsFading = false;

    // Start is called before the first frame update
    void Start()
    {
        // m_LampBtn Ŭ�� �̺�Ʈ ���
        m_LampBtn.onClick.AddListener(OnLampBtnClicked);

        if (m_HallBtn != null)
            m_HallBtn.onClick.AddListener(() =>
            {
                // Ű�� ������ ���� ���, ����
                SceneManager.LoadScene("HallScene");
            });

        for (int set_WoodStock = 0; set_WoodStock < GlobalValue.g_WoodStock.Length; set_WoodStock++)
        {
            if (0 < GlobalValue.g_WoodStock[set_WoodStock])
            {
                if (set_WoodStock < m_WoodStock.Length)
                {
                    m_WoodStock[set_WoodStock].SetActive(true);
                    m_WoodStock[1].SetActive(false);
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
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsFading)
        {
            // m_WDImg�� alpha ���� ������ �ø���
            Color color = m_WoodStock1.color;
            color.a += Time.deltaTime * m_FadeSpeed;
            m_WoodStock1.color = color;
            m_Key1Img.color = color;

            if (color.a >= 1.0f)
            {
                m_IsFading = false;
            }
        }  
    }

    void OnLampBtnClicked()
    {
        // m_WD1Img visible�� ����
        m_WoodStock1.gameObject.SetActive(true);
        GlobalValue.g_WoodStock[0] = 1;

        // m_WD1Img visible�� ����
        m_Key1Img.gameObject.SetActive(true);
        GlobalValue.g_Key[0] = 1;

        // m_LampBtn interactable false�� ����
        m_LampBtn.interactable = false; 

        // ������ ��Ÿ���� ȿ�� ����
        m_IsFading = true;
        Color color = m_WoodStock1.color;
        color.a = 0.0f;
        m_WoodStock1.color = color;
    }
}
