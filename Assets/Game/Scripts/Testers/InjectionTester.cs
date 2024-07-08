using UnityEngine;
using VContainer;

namespace Game.Scripts
{
    public class InjectionTester : MonoBehaviour
    {
        [SerializeField]
        private RigidbodyContainer _rigidbodyContainer;
        private InputManagerHolder _inputmanagerholder;
        
        [Inject]
        public void Test(InputManager inputManager)
        {
            _inputmanagerholder = new InputManagerHolder(inputManager, _rigidbodyContainer.rb);
        }

        private void Update()
        {
            _inputmanagerholder.PrintRigidBodyName();
        }
    }
}