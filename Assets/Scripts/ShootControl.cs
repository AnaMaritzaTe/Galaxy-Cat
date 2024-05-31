using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{


    public Transform shootPoint;
    public GameObject bullet;
    public Animator gunAnimator;
    [Range(0, 1)]
    public float disperseBullet;
    public alertarEnemigo alerta;
    private Coroutine shootCoroutine;
    //public float duration = 5f;

    private Transform playerPosition;

    private void Start()
    {
        playerPosition = FindObjectOfType<PC>().transform;
        
       
    }

    private void Update()
    {
        

        if (alerta.isDetected && shootCoroutine == null)
        {
            shootCoroutine = StartCoroutine(ShootCoroutine());
        }
        else if (!alerta.isDetected && shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            shootCoroutine = null;
            StopShootingAn();
        }

    }
    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(3f);
        }
    }

   

    public void Shoot()
    {
        StopShootingAn();
        Vector3 playerDirection = playerPosition.position - transform.position;

        GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * 2000 + new Vector3(Random.Range(disperseBullet, -disperseBullet), Random.Range(disperseBullet, -disperseBullet), 0) * 100, ForceMode.Force);

        gunAnimator.SetBool("IsShooting", true);
    }

    public void StopShootingAn()
    {

            gunAnimator.SetBool("IsShooting", false);

        
    }
}
