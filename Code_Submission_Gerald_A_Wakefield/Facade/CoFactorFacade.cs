using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Interface;
using Code_Submission_Gerald_A_Wakefield.Model;
using Code_Submission_Gerald_A_Wakefield.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code_Submission_Gerald_A_Wakefield.Facade
{
    public class CoFactorFacade
    {
        readonly IUtil _util;
        readonly IInputService _inputService;
        readonly IFactorService _factorService;
        private List<Factor> factors = new List<Factor>();

        public CoFactorFacade()
        {
            _util = ServiceInjector.Retrieve<IUtil>();
            _inputService = ServiceInjector.Retrieve<IInputService>();
            _factorService = ServiceInjector.Retrieve<IFactorService>();
        }

        public CoFactorFacade(IUtil util, IInputService inputService, IFactorService factorService)
        {
            _util = util;
            _inputService = new InputService(_util);
            _factorService = new FactorService(_util);
        }

        public bool Load(string input)
        {
            if (factors.Count < 2)
            {
                var val = _inputService.ReadInt(input);

                factors.Add(new Factor(_util, val, _factorService.getSum(val)));
            }
            if (factors.Count < 2)
            {
                return true;
            }
            return false;
        }

        public int Calculate()
        {
            if (factors.Count != 2)
            {
                throw new InvalidOperationException("The CoFactor Facade has not been populated with enough Factors");
            }
            var sum = factors.Select(x => x.Sum).Sum();

            var inputs = factors.Select(x => x.Value).ToList();
            var GCD = GreatestCommonDivisor();
            var commonVals = 0;
            var LCD = LeastCommonMultiple(GCD);
            if (LCD < _util.MaxValue || GCD != 1)
            {
                commonVals = _factorService.getSum(LCD);
            }
            cleanUp();
            return sum - commonVals;
        }
        //Euclid's Algorithm
        private int GreatestCommonDivisor()
        {
            var vals = factors.Select(x => x.Value).ToArray();
            int a = vals[0];
            int b = vals[1];

            for (; ; )
            {
                int remainder = a % b;
                if (remainder == 0)
                {
                    return b;
                }
                a = b;
                b = remainder;
            }
        }

        private int LeastCommonMultiple(int GCD)
        {
            var vals = factors.Select(x => x.Value).ToArray();
            int a = vals[0];
            int b = vals[1];

            return a * b / GCD;
        }

        private void cleanUp()
        {
            factors.Clear();
        }

    }
}
