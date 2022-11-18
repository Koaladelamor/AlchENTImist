using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DBManager : MonoBehaviour
{
    #region Variables

    public static DBManager _DB_MANAGER;

    private List<PotionType> potionTypes = new List<PotionType>();
    private List<Potion> potions = new List<Potion>();
    private List<Ingredient> ingredients = new List<Ingredient>();

    #endregion

    #region Main Methods
    private void Awake()
    {
        if (_DB_MANAGER != null && _DB_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else {
            _DB_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Abriendo BD");
        OpenDatabase();
        GetPotionTypes();
        GetPotions();
        GetIngredients();
        /*for (int i = 0; i < potionTypes.Count; i++)
        {
            Debug.Log(potionTypes[i].type);
        }*/
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    #endregion

    #region DB Connection

    IDbConnection dbConnection;

    private void OpenDatabase()
    {
        string dbUri = "URI=file:alchentimistDB.db";
        dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();
    }

    #endregion

    #region DB Read
    public void GetPotionTypes()
    {
        string query = "SELECT * FROM potion_types";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            PotionType newPotionType = new PotionType();
            newPotionType.id_potion_type = dataReader.GetInt32(0);
            //Debug.Log(newPotionType.id_potion_type);
            newPotionType.type = dataReader.GetString(1);
            //Debug.Log(newPotionType.type);
            newPotionType.icon = dataReader.GetString(2);
            //Debug.Log(newPotionType.icon);
            potionTypes.Add(newPotionType);
        }

    }

    public void GetPotions()
    {
        string query = "SELECT * FROM potions";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            Potion newPotion = new Potion();
            newPotion.id_potion = dataReader.GetInt32(0);
            //Debug.Log(newPotion.id_potion);
            newPotion.potion = dataReader.GetString(1);
            //Debug.Log(newPotion.potion);
            newPotion.cost = dataReader.GetFloat(2);
            //Debug.Log(newPotion.cost);
            newPotion.icon = dataReader.GetString(3);
            //Debug.Log(newPotion.icon);
            newPotion.description = dataReader.GetString(4);
            //Debug.Log(newPotion.description);
            newPotion.id_potion_type = dataReader.GetInt32(5);
            //Debug.Log(newPotion.id_potion_type);
            potions.Add(newPotion);
        }

    }
    public void GetIngredients()
    {
        string query = "SELECT * FROM ingredients";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();

        while (dataReader.Read())
        {
            Ingredient newIngredient = new Ingredient();
            newIngredient.id_ingredient = dataReader.GetInt32(0);
            Debug.Log(newIngredient.id_ingredient);
            newIngredient.ingredient = dataReader.GetString(1);
            //Debug.Log(newIngredient.ingredient);
            newIngredient.cost = dataReader.GetFloat(2);
            //Debug.Log(newIngredient.cost);
            newIngredient.icon = dataReader.GetString(3);
            //Debug.Log(newIngredient.icon);
            newIngredient.description = dataReader.GetString(4);
            //Debug.Log(newIngredient.description);

            ingredients.Add(newIngredient);
        }
    }

    #endregion

    public List<Ingredient> GetIngredientsList() { return ingredients; }
}
