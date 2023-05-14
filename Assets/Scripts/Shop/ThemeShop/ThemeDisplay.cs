using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ThemeDisplay : MonoBehaviour
{
    public Theme skin;
    public Image preview;
    public GameObject locker;
    public void Init(Theme skin, int id)
    {
        this.skin = skin;
        preview.color = skin.color;
        skin.id = id;
        if (ThemeManager.Instance.purchasedList[skin.id])
        {
            locker.SetActive(false);
            if (PlayerPrefs.GetInt("Theme", 0) == skin.id)
                preview.DOFade(1, 0);
            else
                preview.DOFade(0.5f, 0);
        }
        else
        {
            locker.SetActive(true);
        }
    }

    public void OnClick()
    {
        ThemeManager.Instance.UpdateOnClick(skin.id);
        if (ThemeManager.Instance.purchasedList[skin.id])
            this.PostEvent(EventID.OnSelectTheme);
    }
    public void SetStatus(bool status)
    {
        Color tmp = skin.color;
        if (status == true)
        {
            preview.color = tmp;
        }
        else
        {
            tmp.a = 0.5f;
            preview.color =tmp;
        }
    }
}
