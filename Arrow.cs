using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;  // 화살의 속도
    public float lifetime = 5f;  // 화살이 사라지기까지의 시간

    private void Start()
    {
        // 화살이 소환된 후 일정 시간이 지나면 자동으로 사라지도록 설정
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // 화살을 직선으로 날리기 위해 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
