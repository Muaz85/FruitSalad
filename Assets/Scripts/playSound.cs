using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public static bool Startcreatfruit, startplay = false;
    public GameObject FruitSpawner1, FruitSpawner2, FruitSpawner3, FruitSpawner4, FruitSpawner5;
    void Start()
    {
        audioSource.Play();
    }
    public void startgame()
    {
        Startcreatfruit = true;
        startplay = true;
        FruitSpawner1.GetComponent<FruitSpawner>().enabled = true;
        FruitSpawner2.GetComponent<FruitSpawner>().enabled = true;
        FruitSpawner3.GetComponent<FruitSpawner>().enabled = true;
        FruitSpawner4.GetComponent<FruitSpawner>().enabled = true;
        FruitSpawner5.GetComponent<FruitSpawner>().enabled = true;
        //mainCanvas.active = false;
    }
    // Update is called once per frame

}
