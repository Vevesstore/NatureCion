using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tree : MonoBehaviour
{
    [SerializeField] private MeshRenderer _MeshRenderer;

    public void ChangeSeting(Color Color)
    {
        _MeshRenderer.material.color = Color;
    }
}
