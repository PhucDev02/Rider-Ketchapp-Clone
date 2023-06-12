using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ThemeManager : MonoBehaviour
{
    public Theme[] themes;
    public GameObject themePrefab;
    public Transform content;
    public TextMeshProUGUI price;

    public static ThemeManager Instance;


    private void Awake()
    {
        Instance = this;
    }
    //[HideInInspector]
    public List<bool> purchasedList;
    private void Start()
    {
        purchasedList = ES3.Load("ThemePurchaseList", GetDefaultPurchasedList());
        GameObject tmp;
        for (int i = 0; i < themes.Length; i++)
        {
            tmp = Instantiate(themePrefab, content);
            tmp.GetComponent<ThemeDisplay>().Init(themes[i], i);
        }
        UpdateOnClick(PlayerPrefs.GetInt("Theme", 0));
        UpdateCountText();
    }
    #region helper method
    private List<bool> GetDefaultPurchasedList()
    {
        List<bool> res = new List<bool> { true };
        for (int i = 1; i < themes.Length; i++)
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
    public int idSelected;
    public void UpdateOnClick(int id)
    {
        idSelected = id;
        for (int i = 0; i < themes.Length; i++)
        {
            content.GetChild(i).GetComponent<ThemeDisplay>().SetStatus(false);
        }
        content.GetChild(id).GetComponent<ThemeDisplay>().SetStatus(true);

        if (purchasedList[id] == true)
        {
            price.transform.parent.gameObject.SetActive(false); //buy button
            PlayerPrefs.SetInt("Theme", id);
        }
        else
        {
            price.transform.parent.gameObject.SetActive(true); //buy button
            price.text = themes[id].price.ToString();
        }
    }
    public void OnPurchased()
    {
        if (Wallet.gems >= themes[idSelected].price)
        {
            price.transform.parent.gameObject.SetActive(false); //buy button
            Wallet.RemoveGems(themes[idSelected].price);
            content.GetChild(idSelected).GetComponent<ThemeDisplay>().SetStatus(true);
            content.GetChild(idSelected).GetComponent<ThemeDisplay>().locker.SetActive(false);
            Instance.purchasedList[idSelected] = true;
            PlayerPrefs.SetInt("Theme", idSelected);
            this.PostEvent(EventID.OnSelectTheme);
        }
        else
            UI_Notice.Instance.Open();
        SavePurchaseList();
        UpdateCountText();
    }
    public Color GetColorTerrain()
    {
        return themes[idSelected].color;
    }
    public TextMeshProUGUI countTxt;
    private void UpdateCountText()
    {
        countTxt.text = "" + GetCountPurchased() + "/" + purchasedList.Count;
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
