using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public bool Shoping = false;
    public GameObject Shop;
    public void Clic()
    {
        Shop.SetActive(false);
        if(Shoping == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.Shoping = false;
        }
    }
}
