using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ParallaxBackground : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class ParallaxComponent
    {
        public Transform holder;
        [HideInInspector]
        public List<Transform> sprites;
        public float moveSpeed;
        public float distance;
    }

    [SerializeField] ParallaxComponent[] backgrounds;
    [SerializeField] Transform rider;

    void Start()
    {
        foreach (ParallaxComponent i in backgrounds)
        {
            foreach (Transform child in i.holder)
                i.sprites.Add(child);

            i.distance = i.sprites[1].transform.position.x - i.sprites[0].transform.position.x;
        }
    }

    private float velocity;
    private Vector3 lastPos;
    // Update is called once per frame
    private void LateUpdate()
    {
        velocity = (rider.position.x - lastPos.x) / Time.fixedDeltaTime;
        lastPos = rider.position;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (rider.position.x - 6.5f > backgrounds[i].sprites.First().position.x)
            {
                GenNextBackground(i);
            }
            backgrounds[i].holder.transform.position = Vector3.Lerp(backgrounds[i].holder.transform.position
                                                        , backgrounds[i].holder.transform.position - Vector3.right*velocity * backgrounds[i].moveSpeed
                                                        , Time.fixedDeltaTime);
        }

    }
    public void GenNextBackground(int i) //
    {
        backgrounds[i].sprites.First().position = backgrounds[i].sprites.Last().position
                                                    + Vector3.right * backgrounds[i].distance;
        backgrounds[i].sprites.Add(backgrounds[i].sprites.First());
        backgrounds[i].sprites.RemoveAt(0);
    }
}
