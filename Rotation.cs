using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // ȸ�� �ӵ��� ������ �� �ִ� ����
    public float rotationSpeed = 30f; // �ʴ� ȸ�� �ӵ�

    // Update�� �� �����Ӹ��� ȣ���
    void Update()
    {
        // �߽����� �������� ȸ�� (y���� �������� ȸ��)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
