using CarPurchasePlatform.Services;
using CarPurchasePlatform.Abstractions;
using CarPurchasePlatform.Models.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Algorithms
{
    public class ForwardChainingAlgorithm : IAlgorithm
    {
        //Services
        private ILoggerService _logger;

        //Input
        private IEnumerable<string> _facts;
        private IEnumerable<Rule> _rules;
        private IEnumerable<string> _goals;

        //Internal variables
        private List<string> _doesntHave = new List<string>();
        private List<Rule> _productions = new List<Rule>();

        public void Init(IEnumerable<Rule> rules, IEnumerable<string> facts, IEnumerable<string> goals, ILoggerService logger)
        {
            _facts = facts;
            _rules = rules;
            _goals = goals;
            _logger = logger;

            //Assign numbers to rules
            var i = 1;
            foreach (var rule in _rules)
            {
                rule.Number = $"R{i}";
                rule.NumberNumeric = i;
                i++;
            }
        }

        //Executes algorithm
        public IEnumerable<IEnumerable<Rule>> Execute()
        {
            _productions = new List<Rule>();
            _doesntHave = new List<string>();

            _logger.WriteLine("PART 1. Data");
            _logger.WriteLine("");
            _logger.WriteLine("    1) Rules");

            foreach (var rule in _rules)
                _logger.WriteLine($"       {rule.Number}: {rule.ToString()}");

            _logger.WriteLine($"    2) Facts {string.Join(", ", _facts)}.");
            _logger.WriteLine($"    3) Goals {string.Join(", ", _goals)}.");

            _logger.WriteLine("PART 2. Trace");
            _logger.WriteLine("");

            bool state = ExecuteInternal();
            _logger.WriteLine("");

            _logger.WriteLine("PART 3. Results");
            _logger.Write($"    1) Goal {string.Join(", ", _goals)} ");

            if (state)
            {
                if (_productions.Any())
                    _logger.Write($"achieved.");
                else
                    _logger.Write($"in facts. Empty path.");
            }
            else
            {
                _logger.Write($"not achieved.");
            }

            _logger.WriteLine("");

            if (state && _productions.Any())
            {
                //Pre process and produce groups for parallel execution
                var groups = new List<List<Rule>>();
                var productionsCopy = new List<Rule>(_productions);
                var tempFacts = new List<string>();
                tempFacts.AddRange(_facts);

                do
                {
                    var prodValid = productionsCopy.Where(x => x.LeftSide.All(y => tempFacts.Contains(y)) &&
                                                               !groups.Any(y => y.Any(z => z.Number == x.Number))).ToList();
                    groups.Add(new List<Rule>(prodValid));
                    tempFacts.AddRange(prodValid.SelectMany(x => x.RightSide).ToList());

                } while (groups.SelectMany(x => x.ToList()).Count() != _productions.Count);

                _logger.Write($"    1) Path ");

                foreach (var group in groups)
                {
                    if (group.Count == 1)
                        _logger.Write(group.First().Number);
                    else
                    {
                        _logger.Write($"[{string.Join(",", group.Select(x => x.Number).ToList())}]");
                    }

                    if (groups.Last() != group)
                        _logger.Write(",");
                }

                _logger.Write($".");
                _logger.WriteLine("");

                return groups;
            }

            return null;
        }

        private bool ExecuteInternal()
        {
            bool halt;
            int index = 0;
            int iteration = 0;
            var GDB = new List<string>(_facts);
            var goals = _goals;
            var rules = new List<Rule>(_rules);

            while (true)
            {
                //If goal is in facts = end
                if (goals.All(x => GDB.Contains(x)))
                {
                    if (iteration != 0)
                        _logger.WriteLine("      Goals achieved.");

                    return true;
                }

                halt = true;
                _logger.WriteLine($"    ITERATION {iteration + 1}");
                iteration++;

                index = 0;

                foreach (var r in rules)
                {
                    index++;

                    //If goals is in facts = end
                    if (goals.All(x => GDB.Contains(x)))
                    {
                        _logger.WriteLine("      Goals achieved.");
                        return true;
                    }

                    if (r.Flag2)
                        _logger.WriteLine($"      {r.Number}:{r.ToString()} skip, because flag 2 raised.");
                    else
                    {
                        if (r.Flag1)
                            _logger.WriteLine($"      {r.Number}:{r.ToString()} skip, because flag 1 raised.");
                        else
                        {
                            if (r.RightSide.All(x => GDB.Contains(x)))
                            {
                                r.Flag2 = true;
                                _logger.WriteLine($"      {r.Number}:{r.ToString()} not applied, because RHSs in facts. Raise flag2.");
                            }
                            else
                            {
                                if (IsInRuleLeftSide(r.LeftSide, GDB))
                                {
                                    halt = !halt;
                                    GDB.AddRange(r.RightSide.Where(x => !GDB.Contains(x)).ToList());
                                    r.Flag1 = true;

                                    var temp = GDB.Except(_facts).ToList();
                                    _logger.WriteLine($"      {r.Number}:{r.ToString()} apply. Raise flag1. Facts {string.Join(", ", _facts.ToList())} and {string.Join(", ", temp)}.");
                                    _productions.Add(r);
                                    break;
                                }
                                else
                                {

                                    foreach (string c in r.LeftSide)
                                        if (!GDB.Contains(c))
                                            _doesntHave.Add(c);

                                    _logger.WriteLine($"      {r.Number}:{r.ToString()} not applied, because of lacking {string.Join(", ", _doesntHave.ToList())}.");
                                    _doesntHave = new List<string>();
                                }
                            }
                        }
                    }
                }

                if (halt)
                    return false;
            }
        }

        /// <summary>
        /// Helper function to determine if all members of the left side in the rule are in global database
        /// </summary>
        /// <param name="facts">Facts</param>
        /// <param name="GDB">Global database</param>
        /// <returns>True - if all facts are in global database. False - if not all of the facts are in global database.</returns>
        private bool IsInRuleLeftSide(IEnumerable<string> facts, IEnumerable<string> GDB)
        {
            int cnt = 0;

            foreach (string c in facts)
                if (GDB.Contains(c))
                    cnt++;

            return cnt == facts.Count();
        }

        public void Dispose()
        {
            _logger?.Dispose();
        }

    }
}
