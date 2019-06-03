using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Interface;
using System;

namespace Code_Submission_Gerald_A_Wakefield.Models
{
    public class Factor
    {
        private int _value;
        private int _sum;
        private bool _evenDivisor;
        private int _maxIteration;
        readonly IUtil _util;

        public Factor()
        {
            _util = ServiceInjector.Retrieve<IUtil>();
        }
        public Factor(IUtil util)
        {
            _util = util;
        }
        public Factor(int value) : this()
        {
            setValue(value);
        }

        public void setValue(int value)
        {
            if (value < _util.MaxValue && value > 0)
            {
                _value = value;
                // do work of Class
                return;
            }
            throw new ArgumentOutOfRangeException();
        }

        public int Value
        {
            get { return _value; }
        }

    }
}
