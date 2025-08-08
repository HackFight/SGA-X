using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    [SerializeField] List<Craft> crafts = new List<Craft>();
    List<int> ingredients = new List<int>();
    LevelManager levelManager;
    ItemManager itemManager;
    float timeSinceCraftStart;
    [SerializeField] float craftCooldown;
    public bool cantCraft;

    //UI
    [SerializeField] RawImage ingredient1;
    [SerializeField] RawImage ingredient2;
    [SerializeField] RawImage ingredient3;
    [SerializeField] List<Recipe> recipes = new List<Recipe>();

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelManager>();
        itemManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ItemManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Item>())
        {
            ingredients.Add(collision.gameObject.GetComponent<Item>().ID);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Item>())
        {
            ingredients.Remove(collision.gameObject.GetComponent<Item>().ID);
        }
    }

    void Update()
    {
        //Update recipe book
        ingredient1.texture = recipes[levelManager.currentLevel].ingredient1;
        ingredient2.texture = recipes[levelManager.currentLevel].ingredient2;
        ingredient3.texture = recipes[levelManager.currentLevel].ingredient3;

        if (ingredients.Count == 3 && timeSinceCraftStart + craftCooldown < Time.time)
        {
            timeSinceCraftStart = Time.time;
            Craft();
        }
    }

    void Craft()
    {
        if (!cantCraft)
        {
            if (ingredients.Contains(crafts[levelManager.currentLevel].ingredient1) && ingredients.Contains(crafts[levelManager.currentLevel].ingredient2) && ingredients.Contains(crafts[levelManager.currentLevel].ingredient3))
            {
                levelManager.EndLevel(true);
                itemManager.ReloadList(levelManager.currentLevel - 1);
            }
            else
            {
                cantCraft = true;
                levelManager.EndLevel(false);
            }
        }
    }
}

[System.Serializable]
public struct Craft
{
    public int ingredient1;
    public int ingredient2;
    public int ingredient3;
}

[System.Serializable]
public struct Recipe
{
    public Texture2D ingredient1;
    public Texture2D ingredient2;
    public Texture2D ingredient3;
}
