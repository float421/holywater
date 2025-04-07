using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public int HP = 10;
    public float moveSpeed = 2.0f; // 이동 속도
    private Transform player;
    private bool isPlayerDetected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            isPlayerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerDetected = false;
            player = null;
        }
    }

    private void Update()
    {
        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }
        if (isPlayerDetected && player != null)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // 레이캐스트로 벽 감지
            if (Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hit, distanceToPlayer))
            {
                if (hit.collider.CompareTag("Wall"))
                {
                    // 벽이 감지되면 이동 중지
                    return;
                }
            }
            // 벽이 없으면 플레이어 방향으로 이동
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }
    }
}
