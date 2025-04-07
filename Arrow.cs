using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;  // ȭ���� �ӵ�
    public float lifetime = 5f;  // ȭ���� ������������ �ð�

    private void Start()
    {
        // ȭ���� ��ȯ�� �� ���� �ð��� ������ �ڵ����� ��������� ����
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // ȭ���� �������� ������ ���� �̵�
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
