using Code_Submission_Gerald_A_Wakefield.Contracts;
using System;
using System.Linq;

namespace Code_Submission_Gerald_A_Wakefield.Services
{
    public class InputService : IInputService
    {
        private IUtil _util;
        public InputService(IUtil util)
        {
            _util = util;
        }
        public int ReadInt(string line)
        {
            if (String.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentNullException("line");
            }
            if (line.ToCharArray().Any(c => Char.IsLetter(c)))
            {
                throw new ArgumentException("Please Provide Only One Numeric Value");
            }
            int val = Int32.Parse(line);
            if (val <= 0)
            {
                throw new ArgumentException("Please provide a Numeric Value greater than Zero");
            }
            if (val >= _util.MaxValue)
            {
                throw new ArgumentOutOfRangeException(String.Format("Please provide a Numeric Value less than the default Max Value of {0}", _util.MaxValue));
            }
            return val;
        }
    }
}
