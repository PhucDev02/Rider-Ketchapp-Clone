using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
public class Terrain : MonoBehaviour
{
    SpriteShapeRenderer renderer;
    SpriteRenderer sr;
    private void Awake()
    {
        this.RegisterListener(EventID.OnSelectTheme, (x) => UpdateSkin());
        try
        {
            renderer = gameObject.GetComponent<SpriteShapeRenderer>();
            sr = gameObject.GetComponent<SpriteRenderer>();
        }
        catch
        {

        }
    }
    private  void Start()
    {
        UpdateSkin();
    }
    private void UpdateSkin()
    {
        Debug.Log(ThemeManager.Instance.idSelected);
        if (renderer != null)
        {
            renderer.color = ThemeManager.Instance.GetColorTerrain();
        }
        if (sr != null)
            sr.color = ThemeManager.Instance.GetColorTerrain();
    }
}
