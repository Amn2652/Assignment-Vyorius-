using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject itemPrefab;
    private int itemCountPLayer1= 0;
    private int itemCountPLayer2 = 0;// Counter to keep track of collected items
    int presentItems = 4;
    private Alteruna.Avatar avatar;
    
    private void Awake()
    {
        Instantiate(itemPrefab, new Vector3(Random.Range(-24, 24), 1.25f, Random.Range(-24, 24)), Quaternion.identity);
        Instantiate(itemPrefab, new Vector3(Random.Range(-24, 24), 1.25f, Random.Range(-24, 24)), Quaternion.identity);
    }
    void Start()
    {
        avatar = GetComponent<Alteruna.Avatar>();
    }

    void Update()
    {
        if (presentItems < 4)
        {
            Instantiate(itemPrefab, new Vector3(Random.Range(-24,24), 1.25f, Random.Range(-24, 24)), Quaternion.identity);
            presentItems++;
        }
        if(itemCountPLayer1 == 8 || itemCountPLayer2 == 8)
        {
            if(itemCountPLayer1 == 8)
            {
                Debug.Log("Player 1 wins");
            }
            else
            {
                Debug.Log("Player 2 wins");
            }
        }
    }

    // This method is called when a collider enters another collider
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "item")
        {
            if (avatar.IsMe)
            {
                itemCountPLayer1++;
                presentItems--;
                Destroy(collision.gameObject);
            }
            else
            {
                itemCountPLayer2++;
                presentItems--;
                Destroy(collision.gameObject);
            }
        }
    }
}
