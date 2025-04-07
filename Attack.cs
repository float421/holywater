using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float speed = 60f;      // ȸ�� �ӵ� (degrees per second)
    public float minZ = 30f;       // �ּ� Z ȸ����
    public float maxZ = 210f;      // �ִ� Z ȸ����

    private float initialX;
    private float initialY;

    bool Go = false;
    public void A()
    {
        Go = true;
    }

    void Update()
    {
        if(Go == true)
        {
            // ���� ȸ�� ���� ��������
            Vector3 currentRotation = transform.rotation.eulerAngles;
            float initialX = currentRotation.x;
            float initialY = currentRotation.y;
            float currentZ = currentRotation.z;

            // Z ȸ������ 30������ 210������ ����
            float newZ = Mathf.MoveTowards(currentZ, maxZ, speed * Time.deltaTime);

            // ȸ�� ����
            transform.rotation = Quaternion.Euler(initialX, initialY, newZ);

            // Z���� 210���� �����ϸ� Go�� false�� ����
            if (Mathf.Approximately(newZ, maxZ))
            {
                transform.rotation = Quaternion.Euler(initialX, initialY, 30f);
                Go = false;
            }
        }
    }

}
