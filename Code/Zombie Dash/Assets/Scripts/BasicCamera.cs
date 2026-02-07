using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 0, -1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = new Vector3(
                player.transform.position.x + offset.x,
                player.transform.position.y + offset.y,
                player.transform.position.z + offset.z);
        }
    }
}
