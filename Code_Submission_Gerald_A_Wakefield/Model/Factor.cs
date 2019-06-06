using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Contracts;
using System;

namespace Code_Submission_Gerald_A_Wakefield.Model
{
    public class Factor
    {
        private int _value;
        private int _sum;
        readonly IUtil _util;

        public Factor()
        {
            _util = ServiceInjector.Retrieve<IUtil>();
        }
        public Factor(int value, int sum) : this()
        {
            SetValue(value);
            SetSum(sum);
        }
        public Factor(IUtil util, int value, int sum)
        {
            _util = util;
            SetValue(value);
            SetSum(sum);
        }

        private void SetSum(int sum)
        {
            if (sum < _util.MinSum)
            {
                throw new ArgumentException(String.Format("The sum cannot be less than : {0}", _util.MinSum));
            }
            _sum = sum;
        }

        private void SetValue(int value)
        {
            if (value > _util.MaxInputValue || value < 0)
            {
                throw new ArgumentOutOfRangeException("value", String.Format("The input value cannot be greater than the default max value of {0} or less than Zero", _util.MaxValue));
            }
            _value = value;
        }

        public int Value
        {
            get { return _value; }
        }
        public int Sum
        {
            get { return _sum; }
        }

    }
}
