using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UI_GameOver : MonoBehaviour
{
    #region singleton
    public static UI_GameOver Instance;
    private void Awake()
    {
        Instance = this;
        Reset();
    }
    #endregion
    public RectTransform playAgainBtn, menuBtn;
    public CanvasGroup canvasGroup;
    public GameObject panel;
    
    public void GameOver()
    {
        InputManager.canTouch = false;
        panel.SetActive(true);
        canvasGroup.interactable = true;
        canvasGroup.DOFade(1, 0.5f);
        playAgainBtn.DOAnchorPosX(0, 0.5f).SetEase(Ease.OutBack);
        menuBtn.DOAnchorPosX(0, 0.5f).SetEase(Ease.OutBack);
    }
    public void Close()
    {
        canvasGroup.interactable = false;
        canvasGroup.DOFade(0, 0.5f).OnComplete(() =>
        {
            panel.SetActive(false);
            InputManager.canTouch = true;
        });
        playAgainBtn.DOAnchorPosX(-700, 0.5f).SetEase(Ease.InBack);
        menuBtn.DOAnchorPosX(700, 0.5f).SetEase(Ease.InBack);
    }
    public void Reset()
    {
        canvasGroup.DOFade(0, 0);
        playAgainBtn.DOAnchorPosX(-700, 0);
        menuBtn.DOAnchorPosX(700, 0);
    }
}
