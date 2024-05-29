using System;


    public class TickEngine
    {
        public event Action OnTick;

        private float _tickTimer = 0;
        private int _tickRate;
        public int TickRate => _tickRate;
        public TickEngine(int tickRate)
        {
            if (tickRate <= 0)
            {
                throw new ArgumentException("Tick rate must be greater than 0.");
            }

            _tickRate = tickRate;
            _tickTimer = 1.0f / tickRate;
        }
        public void UpdateTicks(float delta)
        {
            _tickTimer -= delta;
            if (_tickTimer <= 0)
            {
                _tickTimer += 1.0f / _tickRate;
                OnTick?.Invoke();
            }
        }
    }
