using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel_Mgr : MonoBehaviour
{
    [HideInInspector] public GameObject SplashObj;   //�ǳڿ�����Ʈ
    [HideInInspector] public Image Panal_Image;      //�ǳ� �̹���

    void Awake()
    {
        SplashObj = this.gameObject;                //��ũ��Ʈ ������ ������Ʈ

        Panal_Image = SplashObj.GetComponent<Image>();    //�ǳڿ�����Ʈ�� �̹��� ����
    }

    // Start is called before the first frame update
    void Start()
    {
        HallBtnListener();
    }

    public void HallBtnListener()
    {
        StartCoroutine("OutSplash");
    }

    void Hall()
    {
        StartCoroutine(InSplash("HallScene"));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OutSplash() //�����
    {
        float duration = 3.0f; // ������ ���� ���� 0�� �Ǵµ� �ɸ��� �ð�
        float elapsedTime = 0f; // ��� �ð��� �����ϴ� ������ �ʱ�ȭ�մϴ�.

        Color color = Panal_Image.color; // ���� �ǳ� �̹����� �÷� ������ �����ɴϴ�.

        while (elapsedTime < duration)
        {
            color.a -= Time.deltaTime / duration; // �ð��� ����Ͽ� ���� ���� ���ҽ�ŵ�ϴ�.

            Panal_Image.color = color; // ����� ���� ���� �ǳ� �̹����� �ݿ��մϴ�.

            elapsedTime += Time.deltaTime; // ��� �ð��� ������Ʈ�մϴ�.
            yield return null;
        }

        // �������� ���� ���� ��Ȯ�� �������ݴϴ�.
        color.a = 0f;
        Panal_Image.color = color;
    }

    IEnumerator InSplash(string a_RevScene) //��ο���
    {
        float duration = 3.0f; // ������ ���� ���� 0�� �Ǵµ� �ɸ��� �ð�
        float elapsedTime = 0f; // ��� �ð��� �����ϴ� ������ �ʱ�ȭ�մϴ�.

        Color color = Panal_Image.color; // ���� �ǳ� �̹����� �÷� ������ �����ɴϴ�.

        while (elapsedTime < duration)
        {
            color.a += Time.deltaTime / duration; // �ð��� ����Ͽ� ���� ���� ���ҽ�ŵ�ϴ�.

            Panal_Image.color = color; // ����� ���� �� ���� ���� �ǳ� �̹����� �ݿ��մϴ�.

            elapsedTime += Time.deltaTime; // ��� �ð��� ������Ʈ�մϴ�.
            yield return null; // ���� �������� ��ٸ��ϴ�.
        }

        // �������� ���� ���� ��Ȯ�� �������ݴϴ�.
        color.a = 1f;
        Panal_Image.color = color;

        if (a_RevScene != "")
            SceneManager.LoadScene(a_RevScene);
    }


}
