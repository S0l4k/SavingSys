using UnityEngine;
using StateMachine;

namespace Player
{
    public class PlayerStateController : StateMachine.StateMachine, IDataPersistence
    {
        public float moveSpeed = 3f;
        public bool isMoving = false;
        public int coinCount = 0;

        private void Start()
        {
            Begin(new PlayerIdleState(this));
        }

        public void AddCoins(int amount)
        {
            coinCount += amount;
            Debug.Log("Zebrano monetê! Aktualnie masz: " + coinCount);
        }

        public void LoadData(GameData data)
        {
            this.transform.position = data.playerPosition;
            this.coinCount = data.coinCount;
        }

        public void SaveData(ref GameData data)
        {
            data.playerPosition = this.transform.position;
            data.coinCount = this.coinCount;
        }
    }
}
