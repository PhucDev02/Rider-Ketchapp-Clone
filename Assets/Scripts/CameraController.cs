using UnityEngine;
using Cinemachine;
using DG.Tweening;
public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCamera;
    private float initSize = 13, highSize = 16;
    private void Update()
    {
        if (vCamera.m_Follow.position.y > 14.0f)
        {
            vCamera.m_Lens.OrthographicSize = Mathf.Lerp(vCamera.m_Lens.OrthographicSize, highSize, 5 * Time.deltaTime);
        }
        else
        {
            vCamera.m_Lens.OrthographicSize = Mathf.Lerp(vCamera.m_Lens.OrthographicSize, initSize, 7 * Time.deltaTime);
        }
    }
}
