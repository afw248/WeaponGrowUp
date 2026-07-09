using System;
using CJW._00.Scripts.ForgeScripts.Presenters;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CJW._00.Scripts.ForgeScripts.Views
{
    public class EquipSlotView : MonoBehaviour, IDropHandler
    {
        private RectTransform _rect;
        private ForgePresenter _presenter;
        private ForgeElementView _element;
        [SerializeField] private int index;
        
        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
        }
        public void OnDrop(PointerEventData eventData)
        {
            var element = eventData.pointerDrag?.GetComponent<ForgeElementView>();
            if(element == null) return;
            
            Equip(element);
        }

        public void Equip(ForgeElementView view)
        {
            _element = view;
            _presenter.TryEquip(index, view);
            _element.OnDragAction += Unequip;
        }

        private void Unequip()
        {
            _presenter.Unequip(index, _element);
            _element.OnDragAction -= Unequip;
        }

        public void Initialize(ForgePresenter presenter)
        {
            _presenter = presenter;
        }
        public Vector3 GetWorldPos()
        {
            return _rect.position;
        }
    }
}