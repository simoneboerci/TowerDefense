using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class HighlightingSystem : MonoBehaviour
{
    #region Public Variables

    public Color hoverColor;

    #endregion

    #region Private Variables

    [SerializeField]
    private MeshRenderer _rend;
    private Color _startColor;

    #endregion

    #region Init

    private void Awake()
    {
        _startColor = _rend.material.color;
    }

    #endregion

    #region Private Variables

    private void OnMouseEnter()
    {
        _rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }

    #endregion
}
