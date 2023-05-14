using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UI_Pause : MonoBehaviour
{
    public GameObject panel;
    public Transform board;
    public CanvasGroup canvasGroup;
    private void Awake()
    {
        board.transform.localScale = Vector3.zero;
        canvasGroup.alpha = 0;
    }
    public void Open()
    {
        InputManager.canTouch = false;
        panel.SetActive(true);
        Time.timeScale = 0;
        canvasGroup.DOFade(1, 0.5f).SetUpdate(true);
        board.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).SetUpdate(true);
    }
    public void Close()
    {
        canvasGroup.DOFade(0, 0.5f).SetUpdate(true);
        board.transform.DOScale(0, 0.5f).SetEase(Ease.OutBack).SetUpdate(true).OnComplete(() =>
            {
                panel.SetActive(false);
                InputManager.canTouch = true;
                Time.timeScale = 1;
            }
        );
    }
}
