using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VehicleSkinDisplay : MonoBehaviour
{
    public VehicleSkin skin;
    public Image preview;
    public GameObject locker;
    public void Init(VehicleSkin skin, int id)
    {
        this.skin = skin;
        preview.sprite = skin.preview;
        skin.id = id;
        if (skin.isPurchased)
        {
            locker.SetActive(false);
            if (PlayerPrefs.GetInt("Skin", 0) == skin.id)
                preview.color = Color.white;
            else
                preview.color = VehicleShopManager.Instance.disableColor;
        }
        else
        {
            locker.SetActive(true);
            preview.color = VehicleShopManager.Instance.disableColor;
        }
    }

    public void OnClick()
    {
        VehicleShopManager.Instance.UpdateOnClick(skin.id);
        if (skin.isPurchased)
            this.PostEvent(EventID.OnSelectSkin);
    }
    public void SetStatus(bool status)
    {
        if (status == true)
            preview.color = Color.white;
        else preview.color = VehicleShopManager.Instance.disableColor;
    }
}
