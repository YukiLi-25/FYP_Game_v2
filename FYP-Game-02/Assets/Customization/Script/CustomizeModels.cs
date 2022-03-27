using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeModels : MonoBehaviour
{
    // Eyes
    public GameObject[] eyes; // drag and drop all eyes models
    private int currentEyes; // current index of the array that we want visible !

    // Heads
    public GameObject[] heads; // drag and drop all head models
    private int currentHead; // current index of the array that we want visible !


    void Update()
    {
        for (int i = 0; i < eyes.Length; i++)
        {
            if (i == currentEyes)
            {
                eyes[i].SetActive(true);
            }
            else
            {
                eyes[i].SetActive(false);
            }
        }

        for (int i = 0; i < heads.Length; i++)
        {
            if(i == currentHead)
            {
                heads[i].SetActive(true);
            }
            else
            {
                heads[i].SetActive(false);
            }
        }
    }
    public void SwitchEyes()
    {
        if (currentEyes == eyes.Length - 1)
        {
            Debug.Log("eyes" + currentEyes);
            currentEyes = 0;
        }
        else
        {
            Debug.Log("eyes" + currentEyes);
            currentEyes++;
        }
    }

    public void SwitchHeads()
    {
        if(currentHead == heads.Length - 1)
        {
            Debug.Log("heads" + currentHead);
            currentHead = 0;
        }
        else
        {
            Debug.Log("heads" + currentHead);
            currentHead++;
        }
    }

}
