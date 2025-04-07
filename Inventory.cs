using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>(); //슬롯을 관리해주기 위한 리스트
    public int maxSlot = 3; //슬롯의 갯수를 정해줌
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
            GameObject slotPanel = GameObject.Find("Panel"); // slot의 부모로 만들어 논 Panel을 find로 가져와야 함. Slot을 프리팹화한 후에 Panel 아래에 maxSlot 만큼 생성
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            SlotData slot = go.GetComponent<SlotData>();
            slot.isEmpty = true;
            slot.slotObj = go;

            slots.Add(slot);
        }
    }
}
