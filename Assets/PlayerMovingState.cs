using StateMachine;
using UnityEngine;

namespace Player
{
    public class PlayerMovingState : State
    {
        private PlayerStateController _controller;
        private Vector2 _input;
        private Vector3 _targetPos;

        public PlayerMovingState(StateMachine.StateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _controller = stateMachine.GetComponent<PlayerStateController>();
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (_input.x != 0) _input.y = 0;

            _targetPos = _controller.transform.position + new Vector3(_input.x, _input.y, 0f);
            _controller.StartCoroutine(Move());
        }

        public override void Update()
        {
            // nie trzeba nic robiæ — logika ruchu jest w coroutine
        }

        private System.Collections.IEnumerator Move()
        {
            _controller.isMoving = true;

            while ((_targetPos - _controller.transform.position).sqrMagnitude > Mathf.Epsilon)
            {
                _controller.transform.position = Vector3.MoveTowards(
                    _controller.transform.position,
                    _targetPos,
                    _controller.moveSpeed * Time.deltaTime
                );
                yield return null;
            }

            _controller.transform.position = _targetPos;
            _controller.isMoving = false;

            stateMachine.SetState(new PlayerIdleState(stateMachine));
        }
    }
}
