using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class Wallet : MonoBehaviour
{
	public static int gems;
 	private  static TextMeshProUGUI gemsText;
	void Start()
	{
		gemsText = gameObject.GetComponent<TextMeshProUGUI>();
		gems = PlayerPrefs.GetInt("Gems");
		WalletUpdate();
	}
	public static void WalletUpdate()
	{
		gemsText.text = gems.ToString();
	}
	public static void AddGems(int amount)
	{
		AudioManager.Instance.Play("CollectGem");
		StatisticManager.Instance.totalGems += amount;
		PlayerPrefs.SetInt("Gems", Wallet.gems += amount);
		Wallet.WalletUpdate();
	}
	public static void RemoveGems(int amount)
	{
		PlayerPrefs.SetInt("Gems", Wallet.gems -= amount);
		Wallet.WalletUpdate();
	}
}
