using UnityEngine;
public class Config
{
    public static float yOffset = 0.15f;
    public static float yFaceUpOffset = 0.3f;
    public static float zOffset = 0.4f;
    public static float xOffsetStock = 0.3f;

    public static float cardMovingTime = 0.6f;

    public static float dealingTimePerCard = 0.01f;


    public static float vibrateTime = 0.01f;
    public static Vector2 pileColliderSize=Vector2.right*0.625f+Vector2.up*0.90f;
    public static float cardFadeTime = 0.25f;
    public static string[] tags = { "Foundation", "Pile", "StockUp", "StockDown" };
}
