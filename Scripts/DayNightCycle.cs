using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    private bool isNight = false;

    public float timeBetween = 10f;



    public GameObject player;

    public List<GameObject> enemies;


    public List<DayNightObject> dayNightObjects;


    public GameObject sun;
    public Animator sunAnimator;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");



        //find all game objects with day night 
        List<GameObject> dayNightGameObjects = GameObject.FindGameObjectsWithTag("DayNightObject").ToList();
        dayNightObjects = new List<DayNightObject>();
        foreach (GameObject current in dayNightGameObjects)
        {
            dayNightObjects.Add(current.GetComponent<DayNightObject>());
        }

        ChangeMapState(isNight);

        StartCoroutine(ChangeBoolValueCoroutine());


        





    }

    // Coroutine to change the boolean value every 10 seconds
    private IEnumerator ChangeBoolValueCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetween);

            isNight = !isNight;

            ChangePLayerState(isNight);
            ChangeEnemiesStates(isNight);




            ChangeMapState(isNight);

            if (isNight)
            {
                sunAnimator.Play("SunSet");
                Debug.Log("SunAnimation ");
            }
            else
            {
                sunAnimator.Play("SunRise");
                Debug.Log("SunReversed ");
            }

            Debug.Log("Boolean value changed to: night: " + isNight);
        }
    }


    private void ChangeMapState(bool _isNight)
    {
            foreach (DayNightObject current in dayNightObjects)
            {
                current.ChangeState(_isNight);
            }


    }


    private void ChangePLayerState(bool _isNight)
    {
        
    }


    private void ChangeEnemiesStates(bool _isNight)
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        foreach (var enemy in enemies)
        {
            var script = enemy.GetComponent<EnemyMovement>();
            script.isNight = _isNight;
        }
    }

}
