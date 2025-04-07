using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI Price1, Price2, Price3;
    public GameObject Oh, Yes, Max;
    Player player;
    Inventory inventory;
    public int ShopingButten = 0;
    public int price1 = 1000, price2 = 1000, price3 = 1000;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        Price1.SetText("가격 : " + price1.ToString());
        Price2.SetText("가격 : " + price2.ToString());
        Price3.SetText("가격 : " + price3.ToString());
    }
    public void Click()
    {
        if (ShopingButten == 1)
        {
            if (player.money < price1)
            {
                if (price1 > 2000)
                {
                    Max.SetActive(true);
                }
                else
                    Oh.SetActive(true);
            }
            else
            {
                if(price1 <= 2000)
                {
                    Yes.SetActive(true);
                    player.money -= price1;
                    player.MonyUP();
                    inventory.maxSlot += 2;
                    inventory.S();
                    price1 += 1000;
                    Price1.SetText("가격 : " + price1.ToString());
                    if(price1 > 2000) Price1.SetText("Max".ToString());
                }
                else Max.SetActive(true);
            }
        }
        else if (ShopingButten == 2)
        {
            if (player.money < price2)
            {
                if (price2 > 3000)
                {
                    Max.SetActive(true);
                }
                else
                    Oh.SetActive(true);
            }
            else
            {
                if (price2 <= 3000)
                {
                    Yes.SetActive(true);
                    player.money -= price2;
                    player.MonyUP();
                    player.O2 += 100;
                    player.O2HPup();
                    price2 += 1000;
                    Price2.SetText("가격 : " + price2.ToString());
                    if (price2 > 3000) Price2.SetText("Max".ToString());
                }
                else Max.SetActive(true);
            }

        }
        else if (ShopingButten == 3)
        {
            if (player.money < price3)
            {
                if (price3 > 3000)
                {
                    Max.SetActive(true);
                }
                else
                    Oh.SetActive(true);
            }
            else
            {
                if (price3 <= 3000)
                {
                    Yes.SetActive(true);
                    player.money -= price3;
                    player.MonyUP();
                    player.HP += 50;
                    player.O2HPup();
                    price3 += 1000;
                    Price3.SetText("가격 : " + price3.ToString());
                    if (price3 > 3000) Price3.SetText("Max".ToString());
                }
                else Max.SetActive(true);
            }
        }
    }
}
