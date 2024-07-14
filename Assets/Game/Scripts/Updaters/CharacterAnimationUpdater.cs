using Game.Scripts.Controllers.Interfaces;
using UnityEngine;

namespace Game.Scripts.Updaters
{
    public class CharacterAnimationUpdater
    {
        private readonly ICharacterModel _characterModel;
        private readonly Animator _animator;
    
        private static readonly int VSpd = Animator.StringToHash("v_spd");
        private static readonly int HSpd = Animator.StringToHash("h_spd");
        private static readonly int Grounded = Animator.StringToHash("grounded");
        private static readonly int Atk = Animator.StringToHash("atk");

        public CharacterAnimationUpdater(Animator animator, ICharacterModel characterModel)
        {
            _characterModel = characterModel;
            _animator = animator;
        }

        public void Update()
        {
            var absX = Mathf.Abs(_characterModel.Velocity.x);
            if (absX>1)
                _animator.transform.localScale = new Vector3(1 * (Mathf.Sign(_characterModel.Velocity.x)), 1, 1);
            _animator.SetBool(Grounded, _characterModel.IsGrounded);
            _animator.SetFloat(HSpd, absX);
            _animator.SetFloat(VSpd, _characterModel.Velocity.y);
            _animator.SetBool(Atk, _characterModel.IsAttacking);
        }
    }
}
