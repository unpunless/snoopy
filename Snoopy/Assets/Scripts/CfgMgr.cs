using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CfgMgr : MonoBehaviour
{
    public Button m_LobbyBtn;
    public Renderer Renderer;
    public Button m_GoBackBtn;

    private string previousSceneName;

    void Start()
    {
        previousSceneName = PlayerPrefs.GetString("PreviousScene");

        if (m_LobbyBtn != null) m_LobbyBtn.onClick.AddListener(() 
            => SceneManager.LoadScene("LobbyScene"));
    }

    public void GoBack()
    {
        SceneManager.LoadScene(previousSceneName);
    }
}
