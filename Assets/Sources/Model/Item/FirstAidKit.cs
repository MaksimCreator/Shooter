namespace Game.Model
{
    public class FirstAidKit : Item,IAction
    {
        private readonly int _healHealse;

        public FirstAidKit(int weight, int healHealse) : base(weight)
        {
            _healHealse = healHealse;

        }

        public void Action()
        {
            throw new System.NotImplementedException();
        }
    }
}
