using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Transform rider;
    public static GameController Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void PlayAgain()
    {
        Time.timeScale = 1;
        InputManager.canTouch = true;
        gameOver = false;
        Reset(); 
    }
    public void Reset()
    {
        rider.SetPositionAndRotation(Vector3.up * 3.95f, Quaternion.identity);
        rider.GetComponent<Rigidbody2D>().angularVelocity = 0;
        rider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ScoreManager.Instance.ResetScore();
        ObjectPool.Instance.RecallAll();
    }
    private void Start()
    {
        Time.timeScale = 0;
    }
    public bool gameOver;
}
