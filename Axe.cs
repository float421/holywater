using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public float swingSpeed = 2f; // ������ ȸ�� �ӵ�
    public float swingAngle = 45f; // ������ �ִ� ȸ�� ����
    public float x, y;

    private float initialRotationZ;

    void Start()
    {
        // ������ �ʱ� ȸ������ �����մϴ�.
        initialRotationZ = transform.eulerAngles.z;
    }

    void Update()
    {
        // �ð��� ������ ���� ������ ȸ�� ���� �����մϴ�.
        float rotationZ = Mathf.Sin(Time.time * swingSpeed) * swingAngle;

        // ������ ȸ�� �� ���� (Z �� ���� ȸ��)
        transform.rotation = Quaternion.Euler(x, y, initialRotationZ + rotationZ);
    }
}
