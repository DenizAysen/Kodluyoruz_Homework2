using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : MonoBehaviour
{
    [SerializeField] private DropItemModel behaviour = new DropItemModel();

    GameState gameState;
    GameManager gameManager;
  

    private void Start()
    {

        gameState = GameObject.Find("GameStates").GetComponentInChildren<GameState>();
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            other.gameObject.GetComponent<PlayerController>().ChangeScore(behaviour.point);
        }
        if(other.gameObject.tag == "MissedZone")
        {
          
            gameObject.SetActive(false);
            gameState.LoseChance();
        }
    }

}

[System.Serializable]
class DropItemModel
{
   public DropType dropType;
    public int point;
}

public enum DropType
{
    coin,
   box
}
