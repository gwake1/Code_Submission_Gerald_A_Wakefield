using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Contracts;
using System;

namespace Code_Submission_Gerald_A_Wakefield.Services
{
    public class FactorService : IFactorService
    {
        readonly IUtil _util;

        public FactorService()
        {
            _util = ServiceInjector.Retrieve<IUtil>();
        }

        public FactorService(IUtil util)
        {
            _util = util;
        }

        public int GetGreatestMultiple(int Value)
        {
            var maxIteration = GetMaxIterations(Value);
            return Value * maxIteration;
        }

        public int GetSum(int Value)
        {
            var sum = 0;
            var maxIteration = GetMaxIterations(Value);
            var count = 1;
            {
                do
                {
                    sum += count * Value;
                    count += 1;
                } while (count <= maxIteration);
            }
            return sum;
        }

        private bool IsEvenDivisor(int val)
        {
            return _util.MaxValue % val == 0 ? true : false;
        }

        private int GetMaxIterations(int val)
        {
            double count = _util.MaxValue / val;
            var roundedDown = Convert.ToInt32(Math.Floor(count));
            if (IsEvenDivisor(val))
            {
                return roundedDown - 1;
            }
            return roundedDown;
        }
    }
}
