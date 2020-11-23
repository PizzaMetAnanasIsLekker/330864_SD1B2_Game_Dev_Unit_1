using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 offset = new Vector3(0, 6, -11);
    float fov = 60;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        fov = Mathf.Lerp(fov, 60 + player.GetComponent<PlayerController>().speed * 0.5f, 1.0f * Time.deltaTime);
        Camera.main.fieldOfView = fov;
    }
}
