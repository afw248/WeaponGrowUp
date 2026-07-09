using System;
using CJW._00.Scripts.Dagger.SO;
using CJW._00.Scripts.ForgeScripts.Presenters;
using CJW._00.Scripts.ForgeScripts.Views;
using CJW._00.Scripts.Utils;
using UnityEngine;

namespace CJW._00.Scripts.ForgeScripts
{
    public class ForgeInstaller : MonoBehaviour
    {
        [SerializeField] private ForgeView view;
        [SerializeField] private EquipSlotView[] slotViews;
        [SerializeField] private DaggerDataSoList daggerDataSoList;

        private ForgePresenter _presenter;

        private void Awake()
        {
            _presenter = new ForgePresenter(view, daggerDataSoList, slotViews);
        }

        private void Start()
        {
            _presenter.LoadAll();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
                _presenter.Save();
        }

        private void OnApplicationQuit()
        {
            _presenter.Save();
        }

        [ContextMenu("RESET")]
        public void ResetSave()
        {
            SaveReset.Reset();
        }
    }
}