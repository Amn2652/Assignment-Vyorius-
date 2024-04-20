using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    float speed = 5f;
    private Alteruna.Avatar avatar;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        avatar = GetComponent<Alteruna.Avatar>();
        if(!avatar.IsMe)
        {
            player.name = "Player 2";
            return;
        }
        else
        {
            player.name = "Player 1";
        }
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        if (!avatar.IsMe)
        {
            return;
        }
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if(moveX != 0 || moveZ != 0)
        {
            player.transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * speed;

        }

    }

}
