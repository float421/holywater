using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public float swingSpeed = 2f; // 도끼의 회전 속도
    public float swingAngle = 45f; // 도끼의 최대 회전 각도
    public float x, y;

    private float initialRotationZ;

    void Start()
    {
        // 도끼의 초기 회전값을 저장합니다.
        initialRotationZ = transform.eulerAngles.z;
    }

    void Update()
    {
        // 시간이 지남에 따라 도끼의 회전 값을 변경합니다.
        float rotationZ = Mathf.Sin(Time.time * swingSpeed) * swingAngle;

        // 도끼의 회전 값 설정 (Z 축 기준 회전)
        transform.rotation = Quaternion.Euler(x, y, initialRotationZ + rotationZ);
    }
}
