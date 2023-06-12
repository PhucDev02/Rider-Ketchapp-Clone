using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Notice : MonoBehaviour
{
    public static UI_Notice Instance;
    [SerializeField] private GameObject panel;
    private void Awake()
    {
        Instance = this;
    }
    public void Open()
    {
        panel.SetActive(true);
    }
}
