using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Item/Create Items")]
public class Item : ScriptableObject
{
    public int id;
    public string NameItem;
    public int value;
    public Sprite icon;
}
