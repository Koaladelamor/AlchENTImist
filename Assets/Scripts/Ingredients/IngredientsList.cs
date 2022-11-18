using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class IngredientsList : UserInterface
{
    [SerializeField] private GameObject slotPrefab;


    // Start is called before the first frame update
    void Start()
    {
        CreateIngredientsList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateIngredientsList() 
    { 
        List<Ingredient> ingredientsList = DBManager._DB_MANAGER.GetIngredientsList();

        for (int i = 0; i < 4; i++)
        {
            GameObject tempIngredient = Instantiate(slotPrefab, this.transform);
            tempIngredient.GetComponent<IngredientInfo>().SetID(ingredientsList[i].id_ingredient);
            tempIngredient.GetComponent<IngredientInfo>().SetIngredientName(ingredientsList[i].ingredient);
            tempIngredient.GetComponentInChildren<TextMeshProUGUI>().text = ingredientsList[i].ingredient;

        }
    }

}