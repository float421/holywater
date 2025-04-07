using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;  // 화살 프리팹
    public float spawnInterval = 2f;  // 화살 소환 간격
    public Transform firePoint;  // 화살이 발사될 위치

    private void Start()
    {
        // 주기적으로 화살을 소환
        InvokeRepeating("SpawnArrow", 0f, spawnInterval);
    }

    void SpawnArrow()
    {
        // 화살을 소환하고, 발사 방향을 firePoint의 회전으로 설정
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        // firePoint의 회전 방향을 그대로 화살에 적용
        arrow.transform.forward = firePoint.forward;
    }
}
