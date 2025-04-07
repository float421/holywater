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

            //inventory�� slots���� ����ִ� slot�� ã�Ƽ� �������� �־� ��
            Inventory inven = collision.GetComponent<Inventory>();
            for (int i = 0; i < inven.slots.Count; i++) //�ݺ����� inventory.slots.count ��ŭ �����鼭 isEmpty���� �� ���� ã����
            {
                if (inven.slots[i].isEmpty)
                {
                    Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                    //Instantiate(������ ������Ʈ, ������ ��ġ, False)
                    inven.slots[i].isEmpty = false; //������ ä�������ϱ�
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
