using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Friends
{
    LB_Cloud1,
    LB_Cloud2,
    LB_Cloud3
}


public class Friend_Ctrl : MonoBehaviour
{

    public Friends lb_Friend = Friends.LB_Cloud1;

    float m_Speed = 0.5f;   //이동속도
    Vector3 m_CurPos;       //위치 계산용 변수
    Vector3 m_SpawnPos;     //스폰 위치

    Vector3 m_DirVec;       //이동 방향 계산용 변수
    

    // Start is called before the first frame update
    void Start()
    {
        m_SpawnPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (lb_Friend == Friends.LB_Cloud1)
            Cloud1_AI_Update();
        else if (lb_Friend == Friends.LB_Cloud2)
            Cloud2_AI_Update();
        else if (lb_Friend == Friends.LB_Cloud3)
            Cloud3_AI_Update();

        if (this.transform.position.x < CameraResolution.m_ScreenWMin.x - 2.0f)
            Destroy(gameObject);
    }

    void Cloud1_AI_Update()
    {
        m_CurPos = transform.position;
        m_CurPos.x += (-1.0f * Time.deltaTime * m_Speed);

        m_DirVec.x = -2.5f;
        m_DirVec.y = 0.0f;
        m_DirVec.z = 0.0f;

        m_DirVec.Normalize();
        m_DirVec.x = -2.5f;
        m_DirVec.z = 0.0f;

        m_CurPos += (m_DirVec * Time.deltaTime * m_Speed);
        m_CurPos.y = m_SpawnPos.y;
        transform.position = m_CurPos;

    }
    void Cloud2_AI_Update()
    {
        m_CurPos = transform.position;

        m_DirVec.x = -4.5f;
        m_DirVec.y = 0.0f;
        m_DirVec.z = 0.0f;

        m_DirVec.Normalize();
        m_DirVec.x = -4.5f;
        m_DirVec.z = 0.0f;

        m_CurPos += (m_DirVec * Time.deltaTime * m_Speed);
        m_CurPos.y = m_SpawnPos.y;
        transform.position = m_CurPos;

    }
    void Cloud3_AI_Update()
    {
        m_CurPos = transform.position;

        m_DirVec.x = -3.5f;
        m_DirVec.y = 0.0f;
        m_DirVec.z = 0.0f;

        m_DirVec.Normalize();
        m_DirVec.x = -3.5f;
        m_DirVec.z = 0.0f;

        m_CurPos += (m_DirVec * Time.deltaTime * m_Speed);
        m_CurPos.y = m_SpawnPos.y;
        transform.position = m_CurPos;

    }

}
