using UnityEngine;

namespace Game.Scripts
{
    public class InputManagerHolder
    {
        private readonly InputManager _inputManager;
        private readonly Rigidbody2D _rigidbody;

        public InputManagerHolder(InputManager inputManager, Rigidbody2D rigidbody)
        {
            _inputManager = inputManager;
            _rigidbody = rigidbody;
        }

        public void PrintRigidBodyName()
        {
            Debug.Log($"RigidBodyName = {_rigidbody.name}");
        }
    }
}