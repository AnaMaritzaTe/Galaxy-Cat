using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAlienB : MonoBehaviour
{

    private Vector3 targetPosition;
    public float duration;
    public float distance;
    public float rotationSpeed = 100f;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(distance, 0f, 0f);

        // Iniciar la coroutine de movimiento
        StartCoroutine(MoveToPosition(startPosition, targetPosition, duration));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator MoveToPosition(Vector3 start, Vector3 target, float duration)
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(start, target, timeElapsed / duration);
            //transform.Rotate(Vector3.up*-1);
            timeElapsed += Time.deltaTime;
            yield return null; 
                
        }
        transform.position = target;
        StartCoroutine(MoveToPosition(target, start, duration));
    }
    public void funcionParar()
    {
        StopAllCoroutines();
    }
}
