using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("Player"))
        {

            //inventory의 slots에서 비어있는 slot을 찾아서 아이템을 넣어 줌
            Inventory inven = collision.GetComponent<Inventory>();
            for (int i = 0; i < inven.slots.Count; i++) //반복문을 inventory.slots.count 만큼 돌리면서 isEmpty에서 빈 곳을 찾아줌
            {
                if (inven.slots[i].isEmpty)
                {
                    Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                    //Instantiate(생성할 오브젝트, 생성할 위치, False)
                    inven.slots[i].isEmpty = false; //슬롯이 채워졌으니까
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
