using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class UI_Menu : MonoBehaviour
{
    [SerializeField] RectTransform topElement;
    [SerializeField] RectTransform playBtn, levelBtn, settingBtn, shopBtn,progressBtn;
    [SerializeField] CanvasGroup canvasGroup;
    private void Start()
    {
        Reset();
        Open();
    }
    private void Reset()
    {
        gameObject.SetActive(true);
        topElement.DOAnchorPosY(-150, 0).SetUpdate(true);
        playBtn.DOScale(0.2f, 0).SetUpdate(true);
        shopBtn.DOAnchorPosX(-700, 0).SetUpdate(true);
        settingBtn.DOAnchorPosX(700, 0).SetUpdate(true);
        progressBtn.DOAnchorPosX(700, 0).SetUpdate(true);
        levelBtn.DOAnchorPosY(-1000, 0).SetUpdate(true);
    }
    private float moveTime = 1.0f;
    public void Open()
    {
        AudioManager.Instance.Play("TabPopUpIn");
        Time.timeScale = 0;
        InputManager.canTouch = false;
        StatisticManager.Instance.UpdateStat();
        gameObject.SetActive(true);
        GameController.Instance.Reset();
        canvasGroup.alpha = 1;
        topElement.DOAnchorPosY(-850, moveTime).SetEase(Ease.OutBack).SetUpdate(true);
        playBtn.DOScale(1, moveTime).SetEase(Ease.OutBack).SetUpdate(true);
        shopBtn.DOAnchorPosX(-200, moveTime / 3).SetEase(Ease.OutSine).SetUpdate(true).SetDelay(moveTime/2);
        settingBtn.DOAnchorPosX(200, moveTime / 3).SetEase(Ease.OutSine).SetUpdate(true).SetDelay(moveTime / 2);
        progressBtn.DOAnchorPosX(200, moveTime / 3).SetEase(Ease.OutSine).SetUpdate(true).SetDelay(moveTime / 2);
        levelBtn.DOAnchorPosY(-210, moveTime / 3).SetEase(Ease.OutSine).SetUpdate(true).SetDelay(moveTime / 2);
    }
    public async void PlayGame()
    {
        Close();
        await System.Threading.Tasks.Task.Delay((int)(moveTime)*1000);
        GameController.Instance.PlayAgain();
        StatisticManager.Instance.gamesPlayed++;
    }
    public void Close()
    {
        AudioManager.Instance.Play("TabPopUpIn");
        canvasGroup.DOFade(0, moveTime).SetUpdate(true);
        topElement.DOAnchorPosY(-150,moveTime).SetUpdate(true);
        playBtn.DOScale(0f, moveTime/2).SetUpdate(true);
        shopBtn.DOAnchorPosX(-700, moveTime).SetUpdate(true);
        settingBtn.DOAnchorPosX(700, moveTime).SetUpdate(true);
        progressBtn.DOAnchorPosX(700, moveTime).SetUpdate(true);
        levelBtn.DOAnchorPosY(-1000, moveTime).SetUpdate(true).OnComplete(()=> gameObject.SetActive(false));
    }
}
