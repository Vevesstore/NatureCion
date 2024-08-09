using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tree_menu : MonoBehaviour
{
    [SerializeField] private tree_data[] _TreesData;
    [SerializeField] private tree _tree;

    private void Start()
    {
        //_tree.ChangeSeting(_TreesData[0].Color);
        _tree.gameObject.SetActive(false);
    }
}
