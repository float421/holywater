using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;  // ȭ�� ������
    public float spawnInterval = 2f;  // ȭ�� ��ȯ ����
    public Transform firePoint;  // ȭ���� �߻�� ��ġ

    private void Start()
    {
        // �ֱ������� ȭ���� ��ȯ
        InvokeRepeating("SpawnArrow", 0f, spawnInterval);
    }

    void SpawnArrow()
    {
        // ȭ���� ��ȯ�ϰ�, �߻� ������ firePoint�� ȸ������ ����
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        // firePoint�� ȸ�� ������ �״�� ȭ�쿡 ����
        arrow.transform.forward = firePoint.forward;
    }
}
