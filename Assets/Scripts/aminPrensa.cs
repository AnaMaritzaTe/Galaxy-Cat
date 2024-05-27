using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using static UnityEngine.UI.ScrollRect;

public class aminPrensa : MonoBehaviour
{
    private Vector3 targetPosition;
    public float duration;
    public float distance;

    private Vector3 startPosition;
    //public pararPren var;


    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(0f,distance,0f);
        StartCoroutine(MoveBackAndForth(startPosition, targetPosition, distance));
    }

    // Update is called once per frame
    void Update()
    {
    }


    private IEnumerator MoveBackAndForth(Vector3 start, Vector3 target, float duration)
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(start, target, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null; 
        }

        transform.position = target;

        StartCoroutine(MoveBackAndForth(target, start, duration));
    }

    public void funcionParar ()
    {
        StopAllCoroutines();
        Debug.Log("Se ha ejecutado la funcion stop" );

    }

}
