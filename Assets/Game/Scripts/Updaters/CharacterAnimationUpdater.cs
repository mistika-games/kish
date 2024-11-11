using Game.Scripts.Controllers;
using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Core;
using Game.Scripts.Models;
using UnityEngine;

namespace Game.Scripts.Updaters
{
    public class CharacterAnimationUpdater : BaseCoreController
    {
        private readonly ICharacterModel _characterModel;
        private readonly CharacterHorizontalFlipController _characterHorizontalFlipController;
        private readonly Animator _animator;
    
        private static readonly int VSpd = Animator.StringToHash("v_spd");
        private static readonly int HSpd = Animator.StringToHash("h_spd");
        private static readonly int Grounded = Animator.StringToHash("grounded");
        private static readonly int Atk = Animator.StringToHash("atk");

        public CharacterAnimationUpdater(Animator animator, ICharacterModel characterModel, CharacterHorizontalFlipController characterHorizontalFlipController)
        {
            _characterModel = characterModel;
            _characterHorizontalFlipController = characterHorizontalFlipController;
            _animator = animator;
        }
        
        protected override void OnInit()
        {
            _characterModel.OnAttack += SetAtkTrigger;
        }

        public void Update()
        {
            _animator.SetBool(Grounded, _characterModel.IsGrounded);
            _animator.SetFloat(HSpd, Mathf.Abs(_characterModel.Velocity.x));
            _animator.SetFloat(VSpd, _characterModel.Velocity.y);
        }

        private void SetAtkTrigger()
        {
            _animator.SetTrigger(Atk);
        }
        
        protected override void OnDispose()
        {
            _characterModel.OnAttack -= SetAtkTrigger;
        }
    }
}