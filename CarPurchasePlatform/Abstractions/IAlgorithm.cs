using CarPurchasePlatform.Models.Algorithms;
using CarPurchasePlatform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Abstractions
{
    public interface IAlgorithm
    {
        IEnumerable<IEnumerable<Rule>> Execute();
        void Init(IEnumerable<Rule> rules, IEnumerable<string> facts, IEnumerable<string> goals, ILoggerService logger);
    }
}
