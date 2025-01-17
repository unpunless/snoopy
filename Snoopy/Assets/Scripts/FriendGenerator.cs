using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendGenerator : MonoBehaviour
{
    public GameObject[] CloudPrefab;

    float m_SpDelta = 0.0f;         //스폰 주기 계산용 변수
    float m_DiffSpawn = 2.7f;       //스폰 주기

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_SpDelta -= Time.deltaTime;

        if(m_SpDelta < 0.0f)
        {
            GameObject Go = null;

            int sky = Random.Range(1, 11); // 1 ~ 10 랜덤값 발생
            if(sky < 3)
            {
                Go = Instantiate(CloudPrefab[0]) as GameObject;
            }
            else if (3 <= sky && sky <7)
            {
                Go = Instantiate(CloudPrefab[1]) as GameObject;
            }
            else
            {
                Go = Instantiate(CloudPrefab[2]) as GameObject;
            }

            float py = Random.Range(1.0f, 3.0f);
            Go.transform.position =
                        new Vector3(CameraResolution.m_ScreenWMax.x + 1.0f, py, 0.0f);

            m_SpDelta = m_DiffSpawn;
        }
    }
}
