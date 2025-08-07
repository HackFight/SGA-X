using UnityEngine;
using System.Collections.Generic;

public class Cauldron : MonoBehaviour
{
    [SerializeField] List<Craft> crafts = new List<Craft>();
    List<int> ingredients = new List<int>();
    LevelManager levelManager;
    int currentLevel;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelManager>();
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
        currentLevel = levelManager.currentLevel;

        if (ingredients.Count >= 3)
        {
            Craft();
        }
    }

    void Craft()
    {
        if (ingredients.Contains(crafts[currentLevel].ingredient1) && ingredients.Contains(crafts[currentLevel].ingredient2) && ingredients.Contains(crafts[currentLevel].ingredient3))
        {
            Debug.Log("YOU WON!");
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
