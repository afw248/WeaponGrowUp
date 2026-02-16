using DG.Tweening;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public abstract class UiBase : MonoBehaviour
{
    [SerializeField] private float _showTime = 0.2f;
    [SerializeField] private float _hideTime = 0.2f;
    [SerializeField] private Ease _ease = Ease.Linear;
    private bool isOpen;
    private CanvasGroup _canvasGroup;
    public virtual void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        if( _canvasGroup != null)
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            transform.localScale = new Vector3(1, 0, 1);
        }
    }
    //UiManager에서 Dotween 부분 가지고 오기
    public virtual void Open()
    {
        transform.DOKill();
        isOpen = true;
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        RectTransform uirt = _canvasGroup.GetComponent<RectTransform>();
        uirt.SetAsLastSibling();
        uirt.DOScaleY(1, _hideTime)
            .SetEase(_ease).
            SetUpdate(true);
        UiManager.instance.ShowPanel(_canvasGroup.GetComponent<UiBase>());
    }
    public virtual void Close()
    {
        isOpen = false;
        RectTransform uirt = _canvasGroup.GetComponent<RectTransform>();
        uirt.DOScaleY(0, _hideTime)
            .SetEase(_ease)
            .SetUpdate(true).
            OnComplete(
            () => {
                _canvasGroup.alpha = 0;
                _canvasGroup.blocksRaycasts = false;
            });
        UiManager.instance.HidePanel();
    }

    public virtual void OpenClose()
    {
        if (!isOpen)
        {
        Open();
        }
        else
        {
        Close();
        }
    }
}
