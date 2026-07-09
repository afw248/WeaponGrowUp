using System;
using System.Collections.Generic;
using System.Linq;
using CJW._00.Scripts.Dagger.SO;
using CJW._00.Scripts.ForgeScripts.Models;
using CJW._00.Scripts.ForgeScripts.Views;
using CJW._00.Scripts.Utils;
using DG.Tweening;
using UnityEngine;

namespace CJW._00.Scripts.ForgeScripts.Presenters
{
    public class ForgePresenter
    {
        private ForgeModel _model;
        private ForgeView _view;
        private DaggerDataSoList _daggerList;
        private EquipSlotView[] _slots = new EquipSlotView[4];
        private List<ForgeElementView> _elements = new();
        public Action OnSpawnClicked;
        
        public ForgePresenter(ForgeView view, DaggerDataSoList list, EquipSlotView[] slots)
        {
            _model = new ForgeModel();
            _view = view;
            _daggerList = list;
            OnSpawnClicked += () =>
            {
                MakeDagger(_model.SpawnId, true);
            };
            _view.Initialize(this);

            _slots = slots;
            foreach (var slot in _slots)
            {
                slot.Initialize(this);
            }

        }

        public void LoadAll()
        {
            LoadDaggers();
            LoadSlots();
        }
        private void LoadDaggers()
        {
            foreach (var id in _model.DaggerIds)
                CreateElementView(id, true);
        }

        private void LoadSlots()
        {
            HashSet<ForgeElementView> used = new();
            for (int i = 0; i < _model.EquipIds.Count && i < _slots.Length; i++)
            {
                Debug.Log($"{_model.EquipIds[i]} / {i}");
                int equipId = _model.EquipIds[i];
                if (equipId == 0) continue;

                var element = _elements.FirstOrDefault(x => x.Id == equipId && !used.Contains(x));
                if (element == null)
                {
                    Debug.LogWarning($"Equip ID {equipId} not found");
                    continue;
                }

                used.Add(element);
                _slots[i].Equip(element);
            }
        }

        public void TryEquip( int index, ForgeElementView view)
        {
            _model.EquipDagger(view.Id, index);

            view.SetMovable(false);

            var rect = view.GetComponent<RectTransform>();
            DOTween.Kill(rect);
            rect.position = _slots[index].GetWorldPos();
        }

        public void Unequip(int index, ForgeElementView view)
        {
            view.SetMovable(true);
            Debug.Log(view.IsCanMove);
            _model.UnequipDagger(view.Id, index);
        }
        private void MakeDagger(int id, bool anim,Vector2? spawnPos = null)
        {
            _model.Add(id);
            CreateElementView(id, anim, spawnPos);
        }

        public void ArrayViews()
        {
            var element = _elements.Where(x => x.IsCanMove).OrderByDescending(x => x.Id).ToList();
            var grid = GridCalculator.Calculate(element.Count, new Vector2(100, 100), new Vector2(10, 10), 6);
            for (var i = 0; i < grid.Count; i++)
            {
                _elements[i].MoveAnim(grid[i], true);
            }
        }
        private void CreateElementView(int id, bool anim, Vector2? spawnPos = null)
        {
            var element = _view.CreateElement();
            
            _elements.Add(element);
            
            element.Initialize(this, _daggerList.GetSo(id));
            if(anim)
                element.MoveAnim(_view.GetRandomPos(), true);
            else if(spawnPos != null)
                element.Move(spawnPos.Value);
        }
        public void TryMerge(ForgeElementView element)
        {
            foreach (var other in _elements)
            {
                if(element == other) continue;
                if (other.Id == element.Id &&
                    Vector3.Distance(other.GetPos(), element.GetPos()) < 100f)
                {
                    Merge(element, other);
                    return;
                } 
            }
        }

        private void Merge(ForgeElementView a, ForgeElementView b)
        {
            var nextLevel = _daggerList.GetSo(a.Id).nextLevel;
            
            _view.PlayMergeEffect(a.transform.position);
            
            _model.Remove(a.Id);
            _model.Remove(b.Id);

            _elements.Remove(a);
            _elements.Remove(b);
            
            GameObject.Destroy(a.gameObject);
            GameObject.Destroy(b.gameObject);
            
            MakeDagger(nextLevel ,false, a.GetPos());
        }

        public void Save() => _model.Save();
    }
}