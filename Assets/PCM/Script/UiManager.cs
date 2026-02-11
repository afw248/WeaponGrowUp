using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum Uitype
{
    Popup/*팝업창*/ , Window //설정창 같은거
}

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public static UiManager Instance {  get { return instance; } }
    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Stack<UiBase> UiStack = new Stack<UiBase>();

    public void ShowPanel(UiBase ui)
    {
        UiStack.Push(ui);
    }
    public void HidePanel()
    {
        if (UiStack.Count == 0) return;

        UiBase ui = UiStack.Pop();        
    }

    public void MovePanel(Vector3 pos, float time,RectTransform rect)
    {
        var tween = rect.DOAnchorPos(pos,time);
    }
    public void CloseCurrentPanel()
    {
        if (UiStack.Count == 0) return;

        UiBase ui = UiStack.Pop();
        ui.Close();
    }
}
