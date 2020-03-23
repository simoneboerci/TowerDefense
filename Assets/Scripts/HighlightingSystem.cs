using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTS.Manager.SelectionManager;
using BTS.Manager.BuildManager;

[RequireComponent(typeof(MeshRenderer))]
public class HighlightingSystem : MonoBehaviour
{
    #region Public Variables

    public Color hoverColor;
    public bool isBuildable;

    #endregion

    #region Private Variables

    [SerializeField]
    private MeshRenderer _rend;
    private Color _startColor;
    private bool isActive = true;

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
        if (isActive)
        {
            _rend.material.color = hoverColor;
        }
    }

    private void OnMouseOver()
    {
        if (isActive && isBuildable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isActive = false;
                ResetColor();
                SelectionManager.Instance.SetPositionToBuild(this.transform);
            }
        } else if (!isBuildable)
        {
            if (Input.GetMouseButtonDown(1))
            {
                transform.parent.GetComponent<HighlightingSystem>().isActive = true;
                BuildManager.Instance.Demolish(this.gameObject);
            }
        }
    }

    private void OnMouseExit()
    {
        if (isActive)
        {
            ResetColor();
        }
    }

    private void ResetColor()
    {
        _rend.material.color = _startColor;
    }

    #endregion
}
