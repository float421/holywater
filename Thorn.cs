using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{
    public float moveSpeed = 3f; // 가시 함정의 이동 속도
    public float moveRange = 5f; // 가시 함정의 이동 범위 (위아래)
    public float damage = 10f; // 가시 함정의 대미지

    private Vector3 initialPosition; // 시작 위치 저장
    private bool movingUp = true; // 위로 움직이는지 여부

    private void Start()
    {
        initialPosition = transform.position; // 시작 위치 설정
    }

    private void Update()
    {
        MoveTrap(); // 함정 움직임 처리
    }

    private void MoveTrap()
    {
        float moveDirection = movingUp ? 1f : -1f; // 위로 움직일지 아래로 움직일지 결정

        // 함정의 위치를 위아래로 이동
        transform.position = new Vector3(transform.position.x, initialPosition.y + Mathf.PingPong(Time.time * moveSpeed, moveRange), transform.position.z);

        // 이동 후 방향을 반전
        if (transform.position.y >= initialPosition.y + moveRange || transform.position.y <= initialPosition.y)
        {
            movingUp = !movingUp;
        }
    }
}
