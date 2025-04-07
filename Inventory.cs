using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>(); //������ �������ֱ� ���� ����Ʈ
    public int maxSlot = 3; //������ ������ ������
    private int i = 0;
    public GameObject slotPrefab;

    private void Start()
    {
        S();
    }
    public void S()
    {
        for (; i < maxSlot; i++)
        {
            GameObject slotPanel = GameObject.Find("Panel"); // slot�� �θ�� ����� �� Panel�� find�� �����;� ��. Slot�� ������ȭ�� �Ŀ� Panel �Ʒ��� maxSlot ��ŭ ����
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            SlotData slot = go.GetComponent<SlotData>();
            slot.isEmpty = true;
            slot.slotObj = go;

            slots.Add(slot);
        }
    }
}
