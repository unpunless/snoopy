using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveKey : MonoBehaviour
{
    float time = 0;
    public float _size = 2;             //크기
    public float _upSizeTime = 0.4f;    //지속시간
    public GameObject target;
    Vector3 vel = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        if (GlobalValue.g_Key[3] == 1)
        {
            Debug.Log("확인");
        }
    }

    // Update is called once per frame
    void Update()
    {
        BounceKey();

        MoveUpLeftKey();
    }

    void BounceKey()
    {
        if (time <= _upSizeTime)
        {
            transform.localScale = Vector3.one * (1 + _size * time);
        }
        else if (time <= _upSizeTime * 2)
        {
            transform.localScale = Vector3.one * (2 * _size * _upSizeTime + 1 - time * _size);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
        time += Time.deltaTime;
    }

    
    void MoveUpLeftKey()
    {
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, target.transform.position, ref vel, 0.4f);
    }
}
