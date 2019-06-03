using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Interface;
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
            setValue(value);
            setSum(sum);
        }
        public Factor(IUtil util, int value, int sum)
        {
            _util = util;
            setValue(value);
            setSum(sum);
        }

        private void setSum(int sum)
        {
            if (sum < _util.MinSum)
            {
                throw new ArgumentException(String.Format("The sum cannot be less than : {0}", _util.MinSum));
            }
            _sum = sum;
        }

        private void setValue(int value)
        {
            if (value > _util.MaxInputValue || value < 0)
            {
                throw new ArgumentOutOfRangeException();
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
