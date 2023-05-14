using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VehicleShopManager : MonoBehaviour
{
    public VehicleSkin[] skins;
    public GameObject skinPrefab;
    public Transform content;
    public TextMeshProUGUI price;

    public static VehicleShopManager Instance;
    public Color disableColor;


    private void Awake()
    {
        Instance = this;
    }
    public List<bool> purchasedList;
    private void Start()
    {
        purchasedList = ES3.Load("VehiclePurchaseList", GetDefaultPurchasedList());
        GameObject tmp;
        for (int i = 0; i < skins.Length; i++)
        {
            tmp = Instantiate(skinPrefab, content);
            tmp.GetComponent<VehicleSkinDisplay>().Init(skins[i], i);
        }
        UpdateOnClick(PlayerPrefs.GetInt("Skin", 0));
        UpdateCountText();
    }
    #region helper method
    private List<bool> GetDefaultPurchasedList()
    {
        List<bool> res = new List<bool> { true };
        for (int i = 1; i < skins.Length; i++)
        {
            res.Add(false);
        }
        return res;
    }
    private void SavePurchaseList()
    {
        ES3.Save("ThemePurchaseList", purchasedList);
    }
    #endregion
    int idSelected;
    public void UpdateOnClick(int id)
    {
        idSelected = id;
        for (int i = 0; i < skins.Length; i++)
        {
            content.GetChild(i).GetComponent<VehicleSkinDisplay>().SetStatus(false);
        }
        content.GetChild(id).GetComponent<VehicleSkinDisplay>().SetStatus(true);
        if (skins[id].isPurchased == true)
        {
            price.transform.parent.gameObject.SetActive(false); //buy button
            PlayerPrefs.SetInt("Skin", id);
        }
        else
        {
            price.transform.parent.gameObject.SetActive(true); //buy button
            price.text = skins[id].price.ToString();
        }
    }
    public void OnPurchased()
    {
        if (Wallet.gems >= skins[idSelected].price)
        {
            price.transform.parent.gameObject.SetActive(false); //buy button
            Wallet.RemoveGems(skins[idSelected].price);
            content.GetChild(idSelected).GetComponent<VehicleSkinDisplay>().SetStatus(true);
            content.GetChild(idSelected).GetComponent<VehicleSkinDisplay>().locker.SetActive(false);
            skins[idSelected].isPurchased = true;
            PlayerPrefs.SetInt("Skin", idSelected);
            this.PostEvent(EventID.OnSelectSkin);
        }
    }
    public Sprite GetSpriteVehicle()
    {
        return skins[idSelected].preview;
    }
    public TextMeshProUGUI[] countTxt;
    private void UpdateCountText()
    {
        foreach (TextMeshProUGUI txt in countTxt)
            txt.text = "" + GetCountPurchased() + "/" + purchasedList.Count;
    }
    public int GetCountPurchased()
    {
        int count = 0;
        foreach (bool b in purchasedList)
        {
            if (b == true) count++;
        }
        return count;
    }
}
