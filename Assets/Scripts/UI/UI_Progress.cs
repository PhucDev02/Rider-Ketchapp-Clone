using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class UI_Progress : MonoBehaviour
{
    public TextMeshProUGUI progressTitle;
    public Transform levelProgress;
    public TextMeshProUGUI[] stats;
    public GameObject panel;
    public CanvasGroup canvasGroup;
    public void Reset()
    {
        progressTitle.GetComponent<RectTransform>().DOAnchorPosY(75, 0);
        levelProgress.DOScale(0, 0);
        canvasGroup.DOFade(0, 0);
        foreach (TextMeshProUGUI text in stats)
            text.DOFade(0, 0);
    }
    private void Awake()
    {
        Reset();
    }
    public void Open()
    {
        panel.SetActive(true);
        Sequence sequence = DOTween.Sequence();
        sequence.SetUpdate(true);
        sequence.Append(progressTitle.GetComponent<RectTransform>().DOAnchorPosY(-285, 0.3f).SetEase(Ease.OutSine));
        sequence.Join(canvasGroup.DOFade(1, 0.5f));
        sequence.Append(levelProgress.DOScale(1, 0.2f).SetEase(Ease.OutBack));

        foreach (TextMeshProUGUI text in stats)
        {
            sequence.Append(text.DOFade(1, 0.05f));
        }
    }
    public void Close()
    {
        Debug.Log("close");
        DOTween.KillAll();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(progressTitle.GetComponent<RectTransform>().DOAnchorPosY(75, 0.3f).SetEase(Ease.InSine));
        sequence.Append(levelProgress.DOScale(0, 0.2f).SetEase(Ease.InBack));
        sequence.Join(canvasGroup.DOFade(0, 0.3f));
        foreach (TextMeshProUGUI text in stats)
        {
            sequence.Append(text.DOFade(0, 0.05f));
        }
        sequence.SetUpdate(true);
        sequence.OnComplete(() => panel.SetActive(false));
    }
}
