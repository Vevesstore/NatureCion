using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "tree_data", menuName = "Data/tree_data")]
public class tree_data : ScriptableObject
{
    public GameObject Prefab;
    public Color Color;
    [TextArea (10, 20)]
    public string Description;

}
