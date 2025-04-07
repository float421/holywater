using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Player player;

    public int item;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            if(item == 1)
            {
                player.currentHP += 10;         
                print("ȸ�� ������ ���");
            }
            else if(item == 2)
            {
                player.currentO2 += 20;
                print("��� ȸ�� ������ ���");
            }
            else if (item == 3)
            {
                player.SpeedUp1();
                print("���ǵ��(��) ���");
            }
            else if (item == 4)
            {
                player.SpeedUp2();
                print("���ǵ��(��) ���");
            }
            Destroy(this.gameObject);
        }
    }
}
