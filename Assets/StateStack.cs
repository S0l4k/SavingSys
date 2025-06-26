
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{

    public class Statestack
    {
        [SerializeField] private List<State> _stack = new();

        public void Push(State state)
        {
            _stack.Add(state);
        }

        public State Pop()
        {
            State lastState = Peek();
            _stack.RemoveAt(_stack.Count - 1);
            return lastState;
        }
        public State Peek()
        {
            if (_stack.Count == 0) return null;
            return _stack[_stack.Count - 1]; //zwraca ostatni element z listy
        }
        public int Count()
        {

            return _stack.Count;
        }
        public List<State> GetStack()
        {
            return _stack;
        }
    }
}
