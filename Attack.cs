using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float speed = 60f;      // 회전 속도 (degrees per second)
    public float minZ = 30f;       // 최소 Z 회전값
    public float maxZ = 210f;      // 최대 Z 회전값

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
            // 현재 회전 각도 가져오기
            Vector3 currentRotation = transform.rotation.eulerAngles;
            float initialX = currentRotation.x;
            float initialY = currentRotation.y;
            float currentZ = currentRotation.z;

            // Z 회전값을 30도에서 210도까지 증가
            float newZ = Mathf.MoveTowards(currentZ, maxZ, speed * Time.deltaTime);

            // 회전 적용
            transform.rotation = Quaternion.Euler(initialX, initialY, newZ);

            // Z값이 210도에 도달하면 Go를 false로 변경
            if (Mathf.Approximately(newZ, maxZ))
            {
                transform.rotation = Quaternion.Euler(initialX, initialY, 30f);
                Go = false;
            }
        }
    }

}
