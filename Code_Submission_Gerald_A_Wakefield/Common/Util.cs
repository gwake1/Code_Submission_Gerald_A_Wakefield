using Code_Submission_Gerald_A_Wakefield.Contracts;
using System;
using System.Configuration;

namespace Code_Submission_Gerald_A_Wakefield.Common
{
    public class Util : IUtil
    {
        public Util()
        {
            MaxValue = Int32.Parse(ConfigurationManager.AppSettings["MaxValue"]);
            MaxInputValue = MaxValue - 1;
            MinSum = (MaxValue / 2) - 1;
        }
        public int MaxValue { get; private set; }
        public int MinSum { get; private set; }
        public int MaxInputValue { get; private set; }
    }
}
