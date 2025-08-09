using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public List<serializableGameobjectList> itemLists = new List<serializableGameobjectList>();

    public void DisableList(int i)
    {
        for (int j = 0; j < itemLists[i].list.Count; j++)
        {
            itemLists[i].list[j].SetActive(!itemLists[i].list[j].activeSelf);
        }
    }
}

[System.Serializable]
public struct serializableGameobjectList
{
    public List<GameObject> list;
}