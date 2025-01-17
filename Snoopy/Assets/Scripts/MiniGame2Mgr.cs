using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Shape_order
{
    Circle = 1,
    Heart = 2,
    Square = 3,
    Triangle = 4
}

public class MiniGame2Mgr : MonoBehaviour
{
    public GameObject[] m_Tv;

    public Button m_Triangle = null;
    public Button m_Square = null;
    public Button m_Circle = null;
    public Button m_Heart = null;

    public Button Remocon_Hint;
    public Text Remocon_txt;

    private int shape_order_index = 0;
    private Shape_order[] required_shape_order = new Shape_order[4]
    {
        Shape_order.Square,
        Shape_order.Circle,
        Shape_order.Heart,
        Shape_order.Triangle
    };

    public Button m_LivingRoom1Btn = null;

    void Start()
    {
        if (m_LivingRoom1Btn != null)
            m_LivingRoom1Btn.onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt("ShapeOrderIndex", shape_order_index);
                SceneManager.LoadScene("LivingRoomScene");
            });

        if (m_Square != null)
            m_Square.onClick.AddListener(() => ButtonClicked(Shape_order.Square));

        if (m_Circle != null)
            m_Circle.onClick.AddListener(() => ButtonClicked(Shape_order.Circle));

        if (m_Heart != null)
            m_Heart.onClick.AddListener(() => ButtonClicked(Shape_order.Heart));

        if (m_Triangle != null)
            m_Triangle.onClick.AddListener(() => ButtonClicked(Shape_order.Triangle));

        for (int clear_Tv = 0; clear_Tv < GlobalValue.g_Tv.Length; clear_Tv++)
        {
            if (0 < GlobalValue.g_Tv[clear_Tv])
            {
                if (clear_Tv < m_Tv.Length)
                {
                    m_Tv[clear_Tv].SetActive(true);
                }
            }
        }

        if(Remocon_Hint != null)
            Remocon_Hint.onClick.AddListener(() =>
            {
                Remocon_txt.gameObject.SetActive(true);
            });

    }

    void ButtonClicked(Shape_order shape_order)
    {
        if (shape_order == required_shape_order[shape_order_index])
        {
            shape_order_index++;

            if (shape_order_index >= required_shape_order.Length)
            {
                m_Tv[0].SetActive(false);
                GlobalValue.g_Tv[0] = 1;
                m_Tv[1].SetActive(true);
                GlobalValue.g_Tv[1] = 1;

                Debug.Log("LivingRoomScene으로 이동");
                PlayerPrefs.SetInt("MiniGame2ClearStatus", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene("LivingRoomScene", LoadSceneMode.Single); 
            
            }
        }
        else
        {
            Debug.Log("클릭 순서가 올바르지 않습니다!");
            shape_order_index = 0;
        }
    }
}
