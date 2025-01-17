using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;           //<--- PointerEventData 사용을 위한 네임스페이스 추가
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class LivingRoomMgr : MonoBehaviour
{
    [Header("-------GameObject-------")]
    public GameObject[] m_Key;
    public GameObject[] m_Tv;
    public GameObject[] m_WoodStock;

    [Header("-------Button-------")]
    public Button m_Hall4Btn = null;
    public Button m_RemoConBtn = null;  //Curtain onclick -> (invisible -> visible)
    public Button m_WindowCloseBtn = null;  //visible -> invisible

    [Header("-------Image-------")]
    public Image m_WindowImg = null;    //invisible -> visible
    public Image m_TvBefaorImg = null;
    public Button m_TvAfterBtn = null;
    public Image m_WoodStock3 = null;
    public Image m_Key3 = null;

    [Header("-------SpeechBubble-------")]
    public Image[] SpeechBubble;
    public static int KeyPressed = 1;

    [Header("-------ClockImg-------")]
    public Button m_ClockBtn = null;    //onclick -> minigamesc3
    public GameObject[] m_Clock;

    [Header("-------SpeechBubbleFade-------")]
    public float m_FadeSpeed = 4.5f;
    private bool m_IsFading = false;
    public float fadeTimer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InGameSc();

        //fadeTimer = 5.0f;
        m_IsFading = false;

        // m_WindowCloseBtn 클릭 이벤트 등록
        m_WindowCloseBtn.onClick.AddListener(OnCurtainClicked);

        m_TvAfterBtn.onClick.AddListener(CheckTvImage);

        if (m_Hall4Btn != null)
            m_Hall4Btn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("HallScene");
            });

        if (m_RemoConBtn != null)
            m_RemoConBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("MiniGameSc2");
            });

        if (m_ClockBtn != null)
            m_ClockBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("MiniGameSc3");
            });

        for (int set_WoodStock = 0; set_WoodStock < GlobalValue.g_WoodStock.Length; set_WoodStock++)
        {
            if (0 < GlobalValue.g_WoodStock[set_WoodStock])
            {
                if (set_WoodStock < m_WoodStock.Length)
                {
                    m_WoodStock[set_WoodStock].SetActive(true);
                    m_WoodStock[0].SetActive(false);
                    m_WoodStock[1].SetActive(false);
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

        for (int clear_Tv = 0; clear_Tv < GlobalValue.g_Tv.Length; clear_Tv++)
        {
            if (0 < GlobalValue.g_Tv[clear_Tv])
            {
                if (clear_Tv < m_Tv.Length)
                {
                    m_Tv[clear_Tv].gameObject.SetActive(true);

                }
            }
        }

        for (int ClockImg = 0; ClockImg < GlobalValue.g_clock.Length; ClockImg++)
        {
            if (0 < GlobalValue.g_clock[ClockImg])
            {
                if (ClockImg < m_Clock.Length)
                {
                    m_Clock[ClockImg].SetActive(true);
                }
            }
        }

        #region Wrong_Code
        //for (int set_Bubble = 0; set_Bubble < GlobalValue.g_SpeechBubble.Length; set_Bubble++)
        //{
        //    if (0 < GlobalValue.g_SpeechBubble[set_Bubble])
        //    {
        //        if (set_Bubble < SpeechBubble1.Length)
        //        {
        //            SpeechBubble1[set_Bubble].SetActive(true);
        //        }
        //    }
        //}
        #endregion
    }

    void OnCurtainClicked()
    {
        m_WindowCloseBtn.gameObject.SetActive(false);
        m_WindowImg.gameObject.SetActive(true);
        m_RemoConBtn.gameObject.SetActive(true);
    }

    void CheckTvImage()
    {
        if (m_TvBefaorImg == null)
        {
            m_Tv[0].gameObject.SetActive(false);

            m_Tv[1].gameObject.SetActive(true);
            GlobalValue.g_Tv[1] = 1;
        }
    }

    void Update()
    {
        if (fadeTimer > 0)
        {
            fadeTimer -= Time.deltaTime;
            if (fadeTimer <= 0)
            {
                m_IsFading = true;
                Color color = SpeechBubble[0].color;
                color.a = 0.0f;
                SpeechBubble[0].color = color;
            }
        }

        if (m_IsFading)
        {
            Color color = SpeechBubble[0].color;
            color.a += Time.deltaTime * m_FadeSpeed;
            SpeechBubble[0].color = color;

            if (color.a >= 1.0f)
            {
                m_IsFading = false;
            }
        }

        SpeechBubble_Check();

        if (m_Tv[1].gameObject.activeSelf == true)
        {
            m_ClockBtn.interactable = true;

            SpeechBubble[0].gameObject.SetActive(false);
            SpeechBubble[1].gameObject.SetActive(false);
            SpeechBubble[2].gameObject.SetActive(true);
        }
    }

    void InGameSc()
    {
        fadeTimer = 1.0f;
        m_IsFading = true;
        Color color = SpeechBubble[0].color;
        color.a = 0.0f;
        SpeechBubble[0].color = color;
    }

    void SpeechBubble_Check()
    {

        if (KeyPressed < 2)
        {
            //<-- UI가 아닌 부분을 클릭했을 때만 반응하도록...
            if (IsPointerOverUIObject() == false && Input.GetMouseButtonDown(0))
            {
                KeyPressed++;
            }
        }//if (KeyPressed < 2)

        if (KeyPressed == 1)
        {
            SpeechBubble[0].gameObject.SetActive(true);
            SpeechBubble[1].gameObject.SetActive(false);
            SpeechBubble[2].gameObject.SetActive(false);
        }
        else if (KeyPressed == 2)
        {
            SpeechBubble[0].gameObject.SetActive(false);
            SpeechBubble[1].gameObject.SetActive(true);
            SpeechBubble[2].gameObject.SetActive(false);
        }

        #region Wrong_Code
        //{
        //    //-----------------SpeechBubble------------------//
        //    if (Input.GetMouseButtonDown(0) && KeyPressed == 0)
        //    {
        //        Debug.Log("Pressed 0");
        //        SpeechBubble1[0].gameObject.SetActive(true);
        //        KeyPressed++;
        //        if (KeyPressed == 1)
        //            return;
        //    }
        //    else if (Input.GetMouseButtonDown(0) && KeyPressed == 1)
        //    {
        //        Debug.Log("Pressed 1");
        //        SpeechBubble1[0].gameObject.SetActive(false);
        //        SpeechBubble1[1].gameObject.SetActive(true);
        //        KeyPressed++;
        //        if (KeyPressed == 2)
        //            return;
        //        PlayerPrefs.GetInt("Pressed 1", KeyPressed);
        //    }
        //    else if (Input.GetMouseButtonDown(0) && KeyPressed == 2)
        //    {
        //        Debug.Log("Pressed 2");
        //        SpeechBubble1[0].gameObject.SetActive(false);
        //        SpeechBubble1[1].gameObject.SetActive(false);
        //        SpeechBubble1[2].gameObject.SetActive(true);
        //        KeyPressed++;
        //    }
        //}
        #endregion
    }

    public static bool IsPointerOverUIObject() //UGUI의 UI들이 먼저 피킹되는지 확인하는 함수
    {
        PointerEventData a_EDCurPos = new PointerEventData(EventSystem.current);

#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID)

			List<RaycastResult> results = new List<RaycastResult>();
			for (int i = 0; i < Input.touchCount; ++i)
			{
				a_EDCurPos.position = Input.GetTouch(i).position;  
				results.Clear();
				EventSystem.current.RaycastAll(a_EDCurPos, results);
                if (0 < results.Count)
                    return true;
			}

			return false;
#else
        a_EDCurPos.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(a_EDCurPos, results);
        return (0 < results.Count);
#endif
    }//public bool IsPointerOverUIObject()
}
