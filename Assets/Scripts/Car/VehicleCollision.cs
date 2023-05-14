using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class VehicleCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem deathParticle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ExecuteGameOver();
        }
    }
    private async void ExecuteGameOver()
    {
        deathParticle.Play();
        this.PostEvent(EventID.OnGameEndlessOver);

        await Task.Delay(1000);
        if (Time.timeScale != 0)
            UI_GameOver.Instance.GameOver();
    }
}
