using Player;
using UnityEngine;

public class PointManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public int value = 1;
    public bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            PlayerStateController inventory = other.GetComponent<PlayerStateController>();
            if (inventory != null)
            {
                inventory.AddCoins(value);
            }
            collected = true;

           
            gameObject.SetActive(false);

            SaveData(ref DataPersistenceManager.instance.gameData); 
        }
    }

    public void LoadData(GameData data)
    {
      
        if (data.coinsCollected.Contains(id))
        {
            collected = true;
            gameObject.SetActive(false); 
        }
    }

    public void SaveData(ref GameData data)  
    {
       
        if (collected && !data.coinsCollected.Contains(id))
        {
            data.coinsCollected.Add(id);
        }
    }
}
