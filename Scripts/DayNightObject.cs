using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightObject : MonoBehaviour
{
    public GameObject nightVersion;
    public GameObject dayVerson;
    public void ChangeState(bool isNight)
    {
        if (isNight)
        { 
            dayVerson.SetActive(false);
            nightVersion.SetActive(true);
        }
        else
        {
            dayVerson.SetActive(true);
            nightVersion.SetActive(false);
        }

    }
}
