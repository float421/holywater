using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//클래스를 직렬화 하기 위함
public class SlotData : MonoBehaviour
{
    public bool isEmpty;//아이템이 비어있는지 확인
    public GameObject slotObj; //슬롯 오브젝트를 담음
}
