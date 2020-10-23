using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();   
    }

    private void OnEnable()
    {
        CancelInvoke("Shut_Down");

        Invoke("Shut_Down", 8.0f);
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void Shut_Down()
    {
        gameObject.SetActive(false);
    }
/*
    private void Update()
    {
        transform.Translate(0, hiz * Time.deltaTime, 0);
    }*/

    /*
   [SerializeField] private GameObject[] _dropGameObjects;
    // Start is called before the first frame update

    private Coroutine _dropCoroutine;

    void Start()
    {
       _dropCoroutine = StartCoroutine(SpawnDrop(1.5f));
    }


    private void OnDisable()
    {
        StopCoroutine(_dropCoroutine);
    }

    private IEnumerator SpawnDrop(float spawnPerid)
    {
        WaitForSeconds wait = new WaitForSeconds(spawnPerid);

        while (true)
        {
            var gmo = Instantiate(_dropGameObjects[Random.Range(0, 2)],GetRandomSpawnPosition(),Quaternion.identity);
            yield return wait;
        }

    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-Constants.X_BOUNDARY,Constants.X_BOUNDARY),Constants.DROP_HEIGHT,0f);
    }*/
}
