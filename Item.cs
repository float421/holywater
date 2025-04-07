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
                print("회복 아이템 사용");
            }
            else if(item == 2)
            {
                player.currentO2 += 20;
                print("산소 회복 아이템 사용");
            }
            else if (item == 3)
            {
                player.SpeedUp1();
                print("스피드업(소) 사용");
            }
            else if (item == 4)
            {
                player.SpeedUp2();
                print("스피드업(대) 사용");
            }
            Destroy(this.gameObject);
        }
    }
}
