using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGame4Mgr : MonoBehaviour
{
    public GameObject[] m_Key;

    [Header("Key1")]
    public Button Key1Btn = null;
    public Image Key1Img = null;

    [Header("Key2")]
    public Button Key2Btn = null;
    public Image Key2Img = null;

    [Header("Key3")]
    public Button Key3Btn = null;
    public Image Key3Img = null;

    public Button m_LabRoomBtn = null;

    int keysPressed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // m_LabRoomBtn 대한 클릭 이벤트 핸들러 등록
        if (m_LabRoomBtn != null)
            m_LabRoomBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("LabRoomScene");
            });

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

        if (Key1Btn != null)
            Key1Btn.onClick.AddListener(() =>
            {
                m_Key[0].gameObject.SetActive(false);
                Key1Img.gameObject.SetActive(true);
                keysPressed++;
                CheckAllKeysPressed();
            });
        if (Key2Btn != null)
            Key2Btn.onClick.AddListener(() =>
            {
                m_Key[1].gameObject.SetActive(false);
                Key2Img.gameObject.SetActive(true);
                keysPressed++;
                CheckAllKeysPressed();
            });
        if (Key3Btn != null)
            Key3Btn.onClick.AddListener(() =>
            {
                m_Key[2].gameObject.SetActive(false);
                Key3Img.gameObject.SetActive(true);
                keysPressed++;
                CheckAllKeysPressed();
            });

    }
    

    // Check if all keys are pressed and activate m_Key[3] if true
    private void CheckAllKeysPressed()
    {
        if (keysPressed >= 3)
        {
            Debug.Log("마지막 키를 획득");
            GlobalValue.g_Key[3] = 1;
            m_Key[3].gameObject.SetActive(true);

            m_Key[GlobalValue.g_Key.Length - 2].gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
