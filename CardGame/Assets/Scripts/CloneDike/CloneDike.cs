using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDike : MonoBehaviour
{
    public GameObject deck;
    public List<GameObject> slots;

    public List<GameObject> results;


    void Awake()
    {
        deck = GameObject.Find("Deck");
        slots = new List<GameObject>();
        slots.AddRange(GameObject.FindGameObjectsWithTag("Slot"));

        results = new List<GameObject>();
        // Add result slots(4) later
    }

    private void Start()
    {
        // from deck, pop 7 to 1 cards and push them to slots accordingly



        // track score
        // use observer pattern?
        // For each event happens, update score on scoreboard.
        // Singleton to subscribe?

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
