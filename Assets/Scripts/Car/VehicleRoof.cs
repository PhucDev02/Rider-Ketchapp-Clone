using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class VehicleRoof : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain") && !GameController.Instance.gameOver)
        {
            gameObject.GetComponentInParent<VehicleController>().ExecuteGameOver();
            AudioManager.Instance.Play("Death");
        }
    }
}
