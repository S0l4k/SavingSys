using StateMachine;
using UnityEngine;

namespace Player
{
    public class PlayerIdleState : State
    {
        private PlayerStateController _controller;

        public PlayerIdleState(StateMachine.StateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _controller = stateMachine.GetComponent<PlayerStateController>();
        }

        public override void Update()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (input != Vector2.zero)
            {
                stateMachine.SetState(new PlayerMovingState(stateMachine));
            }
        }
    }
}
