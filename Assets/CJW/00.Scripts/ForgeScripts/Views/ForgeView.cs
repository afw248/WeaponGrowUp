using CJW._00.Scripts.ForgeScripts.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace CJW._00.Scripts.ForgeScripts.Views
{
    public class ForgeView : MonoBehaviour
    {
        [SerializeField] private GameObject template;
        [SerializeField] private GameObject mergeEffect;
        [SerializeField] private RectTransform spawnPos;
        [SerializeField] private RectTransform spawnArea;
        [SerializeField] private Button spawnButton;
        [SerializeField] private Button arrayButton;

        private GridLayoutGroup _layout;
        private ForgePresenter _presenter;
        
        public void Initialize(ForgePresenter presenter)
        {
            _presenter = presenter;
            _layout = GetComponentInChildren<GridLayoutGroup>();
            spawnButton.onClick.AddListener(() =>
            {
                _presenter.OnSpawnClicked?.Invoke();
            });
            arrayButton.onClick.AddListener((() =>
            {
                _presenter.ArrayViews();
            }));
        }

        public ForgeElementView CreateElement()
        {
            var obj = Instantiate(template, spawnArea, false);
            obj.GetComponent<RectTransform>().anchoredPosition = spawnPos.anchoredPosition;
            return obj.GetComponent<ForgeElementView>();
        }

        public Vector2 GetRandomPos()
        {
            float xSize = spawnArea.rect.width / 2 - 2;
            float ySize = spawnArea.rect.height / 2 - 2;

            float randomX = Random.Range(-xSize, xSize + 1);
            float randomY = Random.Range(-ySize, ySize + 1);
            return new Vector2(randomX, randomY);
        }
        public void PlayMergeEffect(Vector3 pos)
        {
            Instantiate(mergeEffect, pos, Quaternion.identity);
        }
    }
}