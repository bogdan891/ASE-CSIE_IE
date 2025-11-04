using System;

namespace Seminar3.Models
{
    public class Processor
    {

        private int _value;
        private int _steps;

        private delegate int Operation();
        
        public delegate void ValueChanged(bool increased, int value);
        public event ValueChanged OnValueChanged;

        public delegate void ProcessingStarted(int value);
        public event ProcessingStarted OnProcessingStarted;

        public event Action<int> OnProcessingFinished;

        public Processor(int value)
        {
            _value = value;
        }

        public int Increase()
        {
            var result = 3 * _value + 1;
            OnValueChanged?.Invoke(true, result);
            return result;
        }

        public int Decrease()
        {
            var result = _value / 2;
            OnValueChanged?.Invoke(false, result);
            return result;
        }

        public void Process()
        {
            OnProcessingStarted?.Invoke(_value);

            _steps = 0;
            var initial = _value;

            while(_value > 1)
            {
                Operation operation;
                if (_value % 2 == 0)
                {
                    operation = Decrease;
                }
                else
                {
                    operation = Increase;
                }
                
                _value = operation();
                _steps++;

                if (initial == _value)
                {
                    break;
                }

            }

            _value = initial;

            OnProcessingFinished?.Invoke(_steps);
        }
    }
}
