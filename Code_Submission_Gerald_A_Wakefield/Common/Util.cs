using Code_Submission_Gerald_A_Wakefield.Interface;
using System;
using System.Configuration;

namespace Code_Submission_Gerald_A_Wakefield.Common
{
    public class Util : IUtil
    {
        public Util()
        {
            MaxValue = Int32.Parse(ConfigurationManager.AppSettings["MaxValue"]);
        }
        public int MaxValue { get; private set; }
    }
}
