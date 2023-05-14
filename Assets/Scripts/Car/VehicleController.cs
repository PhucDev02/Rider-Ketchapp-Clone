using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    new SpriteRenderer renderer;
    private void Awake()
    {
        this.RegisterListener(EventID.OnSelectSkin, (param) => UpdateSkin());
        renderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        UpdateSkin();
    }
    private void UpdateSkin()
    {
        renderer.sprite = VehicleShopManager.Instance.GetSpriteVehicle();
    }
    [SerializeField] ParticleSystem deathParticle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ExecuteGameOver();
        }
    }
    public async void ExecuteGameOver()
    {
        if (GameController.Instance.gameOver == true) return;
        deathParticle.Play();
        GameController.Instance.gameOver = true;
        this.PostEvent(EventID.OnGameEndlessOver);
        await Task.Delay(1000);
        if (Time.timeScale != 0)
            UI_GameOver.Instance.GameOver();
    }
}
