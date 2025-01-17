using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGame3Mgr : MonoBehaviour
{
    public Image m_WoodStock3;
    public Image m_Key3;

    public GameObject[] m_Clock;

    GameObject[] SpeechBubble;
        
    [Header("--------Transform--------")]
    public RectTransform hourHandTransform;
    public RectTransform minuteHandTransform;

    [Header("-------Button-------")]
    public Button plusHourButton;
    public Button minusHourButton;
    public Button plusMinuteButton;
    public Button minusMinuteButton;

    public Button m_LivingRoom2Btn;

    [Header("-------Image-------")]
    public Image hourHandImage;  // ��ħ �̹���
    public Image minuteHandImage;  // ��ħ �̹���

    private float hourRotationAngle = 30f;  // 1�ð��� 30��
    private float minuteRotationAngle = 6f;  // 1�д� 6��

    private int targetHour = 2;  // ��ǥ �ð�: 2��
    private int targetMinute = 6;  // ��ǥ ��: 6��

    private float currentHourAngle;
    private float currentMinuteAngle;

    public Button Clock_Hint;
    public Text Clock_txt;
    void Start()
    {
        plusHourButton.onClick.AddListener(IncrementHour);
        minusHourButton.onClick.AddListener(DecrementHour);
        plusMinuteButton.onClick.AddListener(IncrementMinute);
        minusMinuteButton.onClick.AddListener(DecrementMinute);

        if (m_LivingRoom2Btn != null)
            m_LivingRoom2Btn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("LivingRoomScene");
            });

        if (Clock_Hint != null)
            Clock_Hint.onClick.AddListener(() =>
            {
                Clock_txt.gameObject.SetActive(true);
            });

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

        // ������ ���� �ð� ����
        SetRandomTime();
    }

    void Update()
    {
        CheckHour();
    }

    public void CheckHour()
    {
        // ���� Ŭ���� üũ
        if (GetCurrentHour() == targetHour && GetCurrentMinute() == targetMinute)
        {
            m_WoodStock3.gameObject.SetActive(true);
            GlobalValue.g_WoodStock[2] = 1;

            m_Key3.gameObject.SetActive(true);
            GlobalValue.g_Key[2] = 1;

            m_Clock[0].SetActive(false);
            GlobalValue.g_clock[0] = 1;
            m_Clock[1].SetActive(false);
            GlobalValue.g_clock[1] = 1;

            // ���� Ŭ���� �� LivingRoomScene���� ��ȯ
            Debug.Log("MiniGame3 Ŭ����");
            SceneManager.LoadScene("LivingRoomScene");
        }
    }

    public void SetRandomTime()
    {
        // ��ħ �̹��� ���� ����
        currentHourAngle = Random.Range(0, 360);
        hourHandTransform.rotation = Quaternion.Euler(0f, 0f, -currentHourAngle);

        // ��ħ �̹��� ���� ����
        currentMinuteAngle = Random.Range(0, 360);
        minuteHandTransform.rotation = Quaternion.Euler(0f, 0f, -currentMinuteAngle);
    }

    public void IncrementHour()
    {
        currentHourAngle = (currentHourAngle + hourRotationAngle) % 360;
        UpdateClockHands();
    }

    public void DecrementHour()
    {
        currentHourAngle = (currentHourAngle - hourRotationAngle + 360) % 360;
        UpdateClockHands();
    }

    public void IncrementMinute()
    {
        currentMinuteAngle = (currentMinuteAngle + minuteRotationAngle) % 360;
        UpdateClockHands();
    }

    public void DecrementMinute()
    {
        currentMinuteAngle = (currentMinuteAngle - minuteRotationAngle + 360) % 360;
        UpdateClockHands();
    }

    public void UpdateClockHands()
    {
        hourHandTransform.rotation = Quaternion.Euler(0f, 0f, -currentHourAngle);
        minuteHandTransform.rotation = Quaternion.Euler(0f, 0f, -currentMinuteAngle);
    }

    private int GetCurrentHour()
    {
        return Mathf.RoundToInt(currentHourAngle / hourRotationAngle) % 12;
    }

    private int GetCurrentMinute()
    {
        return Mathf.RoundToInt(currentMinuteAngle / minuteRotationAngle) % 60;
    }
}
