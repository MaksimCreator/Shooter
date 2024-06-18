namespace Game.Model
{
    public class InertMovement
    {
        private readonly float _accaleratePerSecond = 0.015f;
        private readonly float _accalerateMaxSpeed = 0.02f;
        private readonly float _accalerateSpeed;
        private readonly Zoom _zoom;

        public float Accaliration { get; private set; }

        public InertMovement(float accaleratePerSEcond, float accalerateMaxSpeed, float accalerateSpeed, Zoom zoom = null)
        {
            _accaleratePerSecond = accaleratePerSEcond;
            _accalerateMaxSpeed = accalerateMaxSpeed;
            _accalerateSpeed = accalerateSpeed;
            _zoom = zoom;
        }

        public void Accalerate(float delta)
        {
            if (Accaliration >= _accalerateMaxSpeed)
                return;

            Accaliration += delta * _accaleratePerSecond * _accalerateSpeed;
            _zoom?.Zooming(delta,true);
        }

        public void Slodown(float delta)
        {
            if (Accaliration == 0)
                return;

            if (Accaliration < 0)
            {
                Accaliration = 0;
                return;
            }

            Accaliration -= delta * _accaleratePerSecond * _accalerateSpeed;
            _zoom?.Zooming(delta,false);
        }
    }
}
