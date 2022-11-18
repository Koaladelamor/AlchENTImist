using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftManager : UserInterface
{

    [SerializeField] private GameObject[] slots; 

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<TextMeshProUGUI>().text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject FirstSlotAvailable() {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<TextMeshProUGUI>().text == "") { return slots[i]; }
        }
        return null;
    }
}
