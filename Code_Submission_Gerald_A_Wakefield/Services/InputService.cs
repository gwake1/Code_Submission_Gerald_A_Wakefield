using Code_Submission_Gerald_A_Wakefield.Interface;
using System;
using System.Linq;

namespace Code_Submission_Gerald_A_Wakefield.Services
{
    public class InputService : IInputService
    {
        public int ReadInt(string line)
        {
            if (String.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentNullException("Line");
            }
            if (line.ToCharArray().Any(c => Char.IsLetter(c)))
            {
                throw new ArgumentException("Please Provide Only One Numeric Value");
            }
            int val;
            Int32.TryParse(line, out val);
            if (val <= 0)
            {
                throw new ArgumentException("Please provide a Numeric Value greater than Zero");
            }
            return val;
        }
    }
}
