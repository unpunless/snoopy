using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel_Mgr : MonoBehaviour
{
    [HideInInspector] public GameObject SplashObj;   //판넬오브젝트
    [HideInInspector] public Image Panal_Image;      //판넬 이미지

    void Awake()
    {
        SplashObj = this.gameObject;                //스크립트 참조된 오브젝트

        Panal_Image = SplashObj.GetComponent<Image>();    //판넬오브젝트에 이미지 참조
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

    IEnumerator OutSplash() //밝아짐
    {
        float duration = 3.0f; // 서서히 알파 값이 0이 되는데 걸리는 시간
        float elapsedTime = 0f; // 경과 시간을 저장하는 변수를 초기화합니다.

        Color color = Panal_Image.color; // 현재 판넬 이미지의 컬러 정보를 가져옵니다.

        while (elapsedTime < duration)
        {
            color.a -= Time.deltaTime / duration; // 시간에 비례하여 알파 값을 감소시킵니다.

            Panal_Image.color = color; // 변경된 알파 값을 판넬 이미지에 반영합니다.

            elapsedTime += Time.deltaTime; // 경과 시간을 업데이트합니다.
            yield return null;
        }

        // 마지막에 알파 값을 정확히 설정해줍니다.
        color.a = 0f;
        Panal_Image.color = color;
    }

    IEnumerator InSplash(string a_RevScene) //어두워짐
    {
        float duration = 3.0f; // 서서히 알파 값이 0이 되는데 걸리는 시간
        float elapsedTime = 0f; // 경과 시간을 저장하는 변수를 초기화합니다.

        Color color = Panal_Image.color; // 현재 판넬 이미지의 컬러 정보를 가져옵니다.

        while (elapsedTime < duration)
        {
            color.a += Time.deltaTime / duration; // 시간에 비례하여 알파 값을 감소시킵니다.

            Panal_Image.color = color; // 변경된 알파 및 색상 값을 판넬 이미지에 반영합니다.

            elapsedTime += Time.deltaTime; // 경과 시간을 업데이트합니다.
            yield return null; // 다음 프레임을 기다립니다.
        }

        // 마지막에 알파 값을 정확히 설정해줍니다.
        color.a = 1f;
        Panal_Image.color = color;

        if (a_RevScene != "")
            SceneManager.LoadScene(a_RevScene);
    }


}
