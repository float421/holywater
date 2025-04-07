using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{
    public float moveSpeed = 3f; // ���� ������ �̵� �ӵ�
    public float moveRange = 5f; // ���� ������ �̵� ���� (���Ʒ�)
    public float damage = 10f; // ���� ������ �����

    private Vector3 initialPosition; // ���� ��ġ ����
    private bool movingUp = true; // ���� �����̴��� ����

    private void Start()
    {
        initialPosition = transform.position; // ���� ��ġ ����
    }

    private void Update()
    {
        MoveTrap(); // ���� ������ ó��
    }

    private void MoveTrap()
    {
        float moveDirection = movingUp ? 1f : -1f; // ���� �������� �Ʒ��� �������� ����

        // ������ ��ġ�� ���Ʒ��� �̵�
        transform.position = new Vector3(transform.position.x, initialPosition.y + Mathf.PingPong(Time.time * moveSpeed, moveRange), transform.position.z);

        // �̵� �� ������ ����
        if (transform.position.y >= initialPosition.y + moveRange || transform.position.y <= initialPosition.y)
        {
            movingUp = !movingUp;
        }
    }
}
