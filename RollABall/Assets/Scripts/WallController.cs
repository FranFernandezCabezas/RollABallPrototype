using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{

    [SerializeField] private List<GameObject> pickups;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject player;
    [SerializeField] private bool allPickupsTaken;


    // Start is called before the first frame update
    void Start()
    {
        allPickupsTaken = false;
        player = GameObject.FindGameObjectWithTag("Player");
        if (gameObject.CompareTag("Special Wall")) AddChildPickupsToList();
    }

    private void AddChildPickupsToList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Pick up"))
            pickups.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("White Wall"))
        {
            if (player.GetComponent<Renderer>().material.color == Color.white)
            {
                wall.SetActive(false);
            }
            else
            {
                wall.SetActive(true);
            }
        }
        else
        {
            if (pickups != null)
            {
                allPickupsTaken = true;
                foreach (GameObject pickup in pickups)
                {
                    if (pickup.activeInHierarchy)
                    {
                        allPickupsTaken = false;
                    }
                }
            }
            if (allPickupsTaken) wall.SetActive(false);
        }
    }
}
