using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update()
    {
       if(Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            player.currentHP += 10;
            Debug.Log("ȸ�� ������ ���");
            Destroy(this.gameObject);
        }
    }
}
