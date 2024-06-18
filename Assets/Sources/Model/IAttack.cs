namespace Game.Model
{
    public interface IAttack
    {
        bool IsActiveAttack { get; }

        void Attack();
    }
}
