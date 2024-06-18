using System;
using UnityEngine;

namespace Game.Model
{
    public class FirearmsInfo : GunInfo
    {
        public readonly int MaxBullet; 
        public readonly int NumberBulletPerShot;
        public readonly int TimeRollbeck;

        [SerializeField] private int _startBullet;

        public int StartBullet => _startBullet;

        public void SaveStartBullet(int StartBullet)
        {
            if (StartBullet < 0)
                throw new InvalidOperationException(nameof(StartBullet));

            if(StartBullet > MaxBullet)
                throw new ArgumentOutOfRangeException(nameof(StartBullet));

            _startBullet = StartBullet;
        }

        //    private readonly int _minBulet = 0;
        //    private int _curentBullet;
        //    private Timers<Firearms> _timerAttack;
        //    private Timers<Firearms> _timerRollbeck;

        //    public bool IsRollbeck => _curentBullet != _maxBulet;
        //    public bool IsActiveRollbeck { get; private set; } = false;
        //    public bool IsActiveAttack { get; private set; } = false;

        //    public void Awake()
        //    {
        //        _timerAttack = new Timers<Firearms>();
        //        _timerRollbeck = new Timers<Firearms>();
        //        _timerAttack.AddTimer(_timeAttack,() => StopAttack());
        //        _timerRollbeck.AddTimer(_timeRollbeck, () => StopRollbeck());
        //    }

        //    public override void Attack()
        //    {
        //        IsActiveAttack = true;
        //        _animator.SetBool(Conffig.AnimationItemToAttackWeapon,true);
        //    }

        //    public void Rollbeck()
        //    {
        //        IsActiveRollbeck = true;
        //        _animator.SetBool(Conffig.AnimatorItemToRollbeckWeapon, true);
        //    }

        //    public void Update(float delta)
        //    {
        //        if (delta < 0)
        //            throw new InvalidOperationException();

        //        if(_curentBullet == _minBulet)
        //            Rollbeck();

        //        if(IsActiveAttack)
        //            _timerAttack.Tick(delta);

        //        if (IsActiveRollbeck)
        //            _timerRollbeck.Tick(delta);
        //    }

        //    private void StopRollbeck()
        //    {
        //        IsActiveRollbeck = false;
        //        _animator.SetBool(Conffig.AnimatorItemToRollbeckWeapon, false);
        //    }

        //    private void StopAttack()
        //    {
        //        IsActiveAttack = false;
        //        prefab.SetActive(false);
        //        _animator.SetBool(Conffig.AnimationItemToAttackWeapon, false);
        //    }
    }
}