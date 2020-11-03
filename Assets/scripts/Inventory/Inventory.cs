using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> inventory = new List<Item>();
    [SerializeField] private Item selectedItem;

    [SerializeField] private bool showInventory = false;
    private Vector2 scr;
    private Vector2 scrollPosition;
    private string sortType = "";

    public GUIStyle[] Styles;

    private void Display()
    {
        if (sortType == "")
        {
            scrollPosition = GUI.BeginScrollView(new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y), scrollPosition, new Rect(0, 0, 0, inventory.Count * .25f * scr.y), false, true);
            for (int i = 0; i < inventory.Count; i++)
            {
                if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inventory[i].Name))
                {
                    selectedItem = inventory[i];
                }
            }
            GUI.EndScrollView();
        }
        else
        {
            itemType type = (itemType)Enum.Parse(typeof(itemType), sortType);
            int slotCount = 0;

            for (int i = 0; i < inventory.Count; i++)
            {
                if(inventory[i].Type == type)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + slotCount * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inventory[i].Name))
                    {
                        selectedItem = inventory[i];
                    }
                    slotCount++;
                }
            }
        }
    }

    private void UseItem()
    {
        GUI.Box(new Rect(4.25f * scr.x, 0.5f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Icon);
        GUI.Box(new Rect(4.55f * scr.x, 3.5f * scr.y, 2.5f * scr.x, 0.5f * scr.y), selectedItem.Name);
        GUI.Box(new Rect(4.25f * scr.x, 4 * scr.y, 3 * scr.x, 3 * scr.y),
                         selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);
        //style

        switch (selectedItem.Type)
        {
            case itemType.Food:
                break;
            case itemType.Weapon:
                break;
            case itemType.Apparel:
                break;
            case itemType.Crafting:
                break;
            case itemType.Ingredients:
                break;
            case itemType.Potions:
                break;
            case itemType.Scrolls:
                break;
            case itemType.Quest:
                break;
            case itemType.Money:
                break;
            case itemType.Armour:
                break;
            default:
                break;
        }
    }

    private void OnGUI()
    {


        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;

        if (showInventory)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");

            string[] ItemTypes = Enum.GetNames(typeof(itemType));
            int CountOfItemTypes = Enum.GetNames(typeof(itemType)).Length;

            for(int i = 0; i < CountOfItemTypes; i++)
            {
                if (GUI.Button(new Rect(4 * scr.x + i * scr.x, 0, scr.x, 0.25f * scr.y), ItemTypes[i]))
                {
                    sortType = ItemTypes[i];
                }
            }
            Display();
            if(selectedItem != null)
            {
                UseItem();
            }
        }
    }
}
