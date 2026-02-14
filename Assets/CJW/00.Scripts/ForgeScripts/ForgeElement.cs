using System;
using CJW._00.Scripts.Dagger.SO;
using CJW._00.Scripts.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CJW._00.Scripts.ForgeScripts
{
    public class ForgeElement : MonoBehaviour
    {
        [SerializeField] private LayerMask daggerLayer;
        [SerializeField] private float checkRange;
        public DaggerDataSo So { get; private set; }
        private SpriteRenderer _image;

        public void Initialize(DaggerDataSo so)
        {
            this.So = so;
            
            _image = GetComponent<SpriteRenderer>();
            _image.sprite = so.icon;
        }

        private void OnMouseDrag()
        {
            transform.position = UtilClass.GetMousePos();
        }

        public void OnMouseUp()
        {
            var hits = Physics2D.OverlapCircleAll(transform.position, checkRange, daggerLayer);
            Debug.Log($"SEX {hits.Length}");
            foreach (var dagger in hits)
            {
                if(dagger.gameObject == gameObject) continue;
                var compo = dagger.GetComponent<ForgeElement>();
                
                if (compo.So.daggerID == So.daggerID)
                {
                    ForgeList.Instance.Merge(this, compo);
                    return;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, checkRange);
        }
    }
}