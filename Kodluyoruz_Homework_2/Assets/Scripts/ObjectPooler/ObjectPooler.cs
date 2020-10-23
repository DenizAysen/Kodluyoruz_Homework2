using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    
   private List<GameObject> coinList = new List<GameObject>();
    private List<GameObject> boxList = new List<GameObject>();
    [SerializeField]  private GameObject box, coin;

   
    private void Start()
    {
        Create(box, 6, boxList);
        Create(coin, 10, coinList);    
    }

    void Create(GameObject gameObject,int quantity,List<GameObject>list)
    {
        for(int i = 0; i < quantity; i++)
        {
            GameObject new_object = Instantiate(gameObject);
            new_object.SetActive(false);
            list.Add(new_object);
        }
        
    }
    
    void DropCoin()
        {
           int random = Random.Range(0, 5);

            if (random < 3)
            {
                foreach (GameObject _object in coinList)
                {
                    if (_object.activeSelf == false)
                    {
                        _object.SetActive(true);
                        _object.transform.position = GetRandomSpawnPosition();
                        break;
                    }
                }
            }

            else
            {
                foreach (GameObject _object in boxList)
                {
                    if (_object.activeSelf == false)
                    {
                        _object.SetActive(true);
                        _object.transform.position = GetRandomSpawnPosition();
                        break;
                    }
                }
            }

        }

    void DropBox()
    {
        foreach (GameObject _object in boxList)
        {
            if (_object.activeSelf == false)
            {
                _object.SetActive(true);
                _object.transform.position = GetRandomSpawnPosition();
                break;
            }
        }
    }

    private void OnEnable()
    {
        SpawnObject();
    }

    private void OnDisable()
    {
        StopSpawn();
    }


    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-Constants.X_BOUNDARY, Constants.X_BOUNDARY), Constants.DROP_HEIGHT, 0f);
    }


    public void SpawnObject()
    {
        InvokeRepeating("DropCoin", 0.0f, Constants.DROP_PERIOD);
    }


    public void StopSpawn()
    {
        CancelInvoke("DropCoin");
    }

    
}






