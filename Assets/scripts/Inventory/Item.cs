﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType
{
    Food,
    Weapon,
    Apparel,
    Crafting,
    Ingredients,
    Potions,
    Scrolls,
    Quest,
    Money,
    Armour
}

[System.Serializable]
public class Item
{
    #region Private Variables
    private int id;
    [SerializeField] private string name;
    private string description;
    private int value;
    private int amount;
    private Texture2D icon;
    private GameObject mesh;
    [SerializeField] private itemType type;
    private int damage;
    private int armour;
    private int heal;
    #endregion


    #region Public Properties
    public int ID
    {
        get { return id; }
        set { id = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public int Value
    {
        get { return value; }
        set { this.value = value; }
    }
    public int Amount
    {
        get { return amount; }
        set { amount = value; }
    }
    public Texture2D Icon
    {
        get { return icon; }
        set { icon = value; }
    }
    public GameObject Mesh
    {
        get { return mesh; }
        set { mesh = value; }
    }
    public itemType Type
    {
        get { return type; }
        set { type = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public int Armour
    {
        get { return armour; }
        set { armour = value; }
    }
    public int Heal
    {
        get { return heal; }
        set { heal = value; }
    }

    #endregion


}
