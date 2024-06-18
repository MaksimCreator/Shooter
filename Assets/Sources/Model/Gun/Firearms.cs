using UnityEngine;
using System;

namespace Game.Model
{
    public class Firearms : Gun
    {
        private readonly int _maxBullet;
        private readonly int _minBulet = 0;
        private readonly int _numberBulletPerShot;
        private int _curentBullet;
        private float _timeRollbeck;
        private int _timeDelaitAttack;
        private float _timerRollbeck;

        private bool ActiveRollbeck = false;
        private bool ActiveAttack = false;
        private bool ActiveAction = false;

        public int CurentBullet => _curentBullet;
        public bool IsRollbeck => _curentBullet != _maxBullet;

        public Firearms(int TimeDelaitAttack,int MaxBullet,int NumberPerBullet,float TimeRollbeck,int Weight, float TimeAttack, Animator Animator) : base(TimeAttack, Weight, Animator)
        {
            _maxBullet = MaxBullet;
            _numberBulletPerShot = NumberPerBullet;
            _timeRollbeck = TimeRollbeck;
            _timeDelaitAttack = TimeDelaitAttack;
        }

        public void Action(Action Action)
        {
            if (ActiveAction)
                return;

            ActiveAction = true;
            Action?.Invoke();
        }

        public override void Attack()
        {

            if (_curentBullet == _minBulet && ActiveRollbeck == false)
            {
                Rollbeck();
                return;
            }

            ActiveAttack = true;
            animator.SetBool(Conffig.AnimatorItemToAttackWeapon, true);
        }

        public void Rollbeck()
        {
            if (IsRollbeck == false)
                throw new InvalidOperationException();

            if (ActiveRollbeck)
                return;

            ActiveRollbeck = true;
            animator.SetBool(Conffig.AnimatorItemToRollbeckWeapon, true);
        }

        public override void Update(float delta)
        {
            if (delta < 0)
                throw new InvalidOperationException(nameof(delta));

            if (ActiveAttack)
            {
                timerAttack += delta;

                if (timerAttack >= timeAttack)
                {
                    OnStopAttack();
                    timerAttack = 0;
                }
            }

            if (ActiveRollbeck)
            {
                _timerRollbeck += delta;

                if (_timerRollbeck >= _timeRollbeck)
                {
                    OnStopRollbeck();
                    _timeRollbeck = 0;
                }
            }

        }

        private void OnStopAttack()
        {
            ActiveAttack = false;
            animator.SetBool(Conffig.AnimatorItemToRollbeckWeapon,false);
        }

        private void OnStopRollbeck()
        {
            ActiveRollbeck = false;
            animator.SetBool(Conffig.AnimatorItemToRollbeckWeapon, false);
            _curentBullet = _maxBullet;
        }
    }
}