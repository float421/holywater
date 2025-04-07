using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // 회전 속도를 조절할 수 있는 변수
    public float rotationSpeed = 30f; // 초당 회전 속도

    // Update는 매 프레임마다 호출됨
    void Update()
    {
        // 중심축을 기준으로 회전 (y축을 기준으로 회전)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
