using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MenuItem1", menuName = "AddFood/Food")]
public class MenuItem : ScriptableObject
{
    public float price;
    public string foodName;
    public bool veg = true;
    public Sprite foodImage;
    public GameObject food3D;
}
