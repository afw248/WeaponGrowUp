using System;
using CJW._00.Scripts.Dagger.SO;
using CJW._00.Scripts.ForgeScripts.Presenters;
using CJW._00.Scripts.Utils;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CJW._00.Scripts.ForgeScripts.Views
{
    public class ForgeElementView : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public bool IsCanMove { get; private set; } = true;

        private DaggerDataSo _so;
        private ForgePresenter _presenter;

        private RectTransform _rect;
        private Canvas _canvas;
        private Image _image;
        public int Id => _so.daggerID;
        public event Action OnDragAction;
        
        public void Initialize(ForgePresenter presenter, DaggerDataSo so)
        {
            _presenter = presenter;
            _so = so;
            _rect = GetComponent<RectTransform>();
            _image = GetComponent<Image>();
            _canvas = GetComponentInParent<Canvas>();
            _image.sprite = _so.icon;
        }
        public void MoveAnim(Vector2 targetPos, bool isRotate)
        {
            _rect.DOAnchorPos(targetPos, 2f); 
            if(isRotate)
                _rect.DORotate(new Vector3(0, 0, 720), 2f, RotateMode.FastBeyond360);
        }
        public void Move(Vector2 pos)
        {
            _rect.anchoredPosition = pos;
        }
        public Vector2 GetPos()
        {
            return _rect.anchoredPosition;
        }
        public void OnDrag(PointerEventData eventData)
        {
            _rect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
            _image.raycastTarget = false;
            OnDragAction?.Invoke();
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            _image.raycastTarget = true;
            _presenter.TryMerge(this);
        }

        public void SetMovable(bool value)
        {
            IsCanMove = value;
        }
    }
}