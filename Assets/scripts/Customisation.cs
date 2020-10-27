using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;

public class Customisation : MonoBehaviour
{
    [SerializeField]
    private string TextureLocation = "Character/";
    public enum CustomiseParts { Skin, Hair, Mouth, Eyes, Clothes, Armour };


    public Renderer characterRenderer;



    public List<Texture2D>[] partsTexture = new List<Texture2D>[Enum.GetNames(typeof(CustomiseParts)).Length];
    private int[] currentPartsTextureIndex = new int[Enum.GetNames(typeof(CustomiseParts)).Length];

    private void Start()
    {
        int partCount = 0;
        foreach(string part in Enum.GetNames(typeof(CustomiseParts)))
        {
            int textureCount = 0;
            Texture2D tempTexture;

            partsTexture[partCount] = new List<Texture2D>();
            do
            {
                tempTexture = (Texture2D)Resources.Load(TextureLocation + part + "_" + textureCount);
                if (tempTexture != null)
                {
                    partsTexture[partCount].Add(tempTexture);
                }
                textureCount++;
            } while (tempTexture != null);
            partCount++;
        }
    }

    void SetTexture(CustomiseParts part, int direction)
    {
        int partIndex = (int)part;

        int max = partsTexture[partIndex].Count;

        int currentTexture = currentPartsTextureIndex[partIndex];
        currentTexture += direction;
        if (currentTexture < 0)
        {
            currentTexture = max - 1;
        }
        else if (currentTexture > max - 1)
        {
            currentTexture = 0;
        }
        currentPartsTextureIndex[partIndex] = currentTexture;

        Material[] mats = characterRenderer.materials;
        mats[partIndex].mainTexture = partsTexture[partIndex][currentTexture];
        characterRenderer.materials = mats;
    }

    void SetTexture(string type, int direction)
    {
        int partIndex = 0;

        switch(type)
        {
            case "Skin":
                partIndex = 0;
                break;
            case "Hair":
                partIndex = 1;
                break;
            case "Mouth":
                partIndex = 2;
                break;
            case "Eyes":
                partIndex = 3;
                break;
            case "Clothes":
                partIndex = 4;
                break;
            case "Armor":
                partIndex = 5;
                break;
            default:
                Debug.LogError("Invalid Set Texture Type.");
                break;
        }

        int max = partsTexture[partIndex].Count;
        
        int currentTexture = currentPartsTextureIndex[partIndex];
        currentTexture += direction;
        if(currentTexture < 0)
        {
            currentTexture = max - 1;
        }
        else if(currentTexture > max - 1)
        {
            currentTexture = 0;
        }
        currentPartsTextureIndex[partIndex] = currentTexture;
        
        Material[] mats = characterRenderer.materials;
        mats[partIndex].mainTexture = partsTexture[partIndex][currentTexture];
        characterRenderer.materials = mats;
    }

    public void TextureButtonLeft(string name)
    {
        SetTexture(name, -1);
        Debug.Log("Set Texture Left");
    }

    public void TextureButtonRight(string name)
    {
        SetTexture(name, 1);
        Debug.Log("Set Texture Right");
    }

}
