using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Actor.Item.UI
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIElement : Item
    {
        protected RectTransform _rectTransform;

        #region Init

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        #endregion

        #region Public Methods

        public virtual void SetPosition(Vector2 min, Vector2 max)
        {
            SetAnchors(min, max);
            ClearOffset();
        }

        #endregion

        #region Private Methods

        private void SetAnchors(Vector2 min, Vector2 max)
        {
            _rectTransform.anchorMin = min;
            _rectTransform.anchorMax = max;
        }

        private void ClearOffset()
        {
            _rectTransform.offsetMin = Vector2.zero;
            _rectTransform.offsetMax = Vector2.zero;
        }

        #endregion
    }
}
