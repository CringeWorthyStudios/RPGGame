﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyBindScript : MonoBehaviour
{

    [SerializeField]
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    [System.Serializable]
    public struct KeyUISetup
    {
        public string keyName;
        public Text keyDisplayText;
        public string defaultKey;
    }

    public KeyUISetup[] baseSetup;
    public GameObject currentKey;
    public Color32 changedKey = new Color32(39, 171, 249, 255);
    public Color32 selectedKey = new Color32(239, 116, 36, 255);

    private void Start()
    {
        for(int i = 0; i < baseSetup.Length; i++)
        {
            keys.Add(baseSetup[i].keyName, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(baseSetup[i].keyName, baseSetup[i].defaultKey)));

            baseSetup[i].keyDisplayText.text = keys[baseSetup[i].keyName].ToString();
        }
    }

    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }

    public void ChangeKey(GameObject clickedKey)
    {
        currentKey = clickedKey;
        if(clickedKey != null)
        {
            currentKey.GetComponent<Image>().color = selectedKey;
        }
    }

    private void OnGUI()
    {
        string newKey = "";
        Event e = Event.current;
        if(currentKey != null)
        {
            if (e.isKey)
            {
                newKey = e.keyCode.ToString();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                newKey = "LeftShift";
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                newKey = "RightShift";
            }
            if (newKey != "")
            {
                keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);
                currentKey.GetComponentInChildren<Text>().text = newKey;
                currentKey.GetComponent<Image>().color = changedKey;
                currentKey = null;
            }
        }
    }
}