using CarPurchasePlatform.Abstractions;
using CarPurchasePlatform.Models.Algorithms;
using CarPurchasePlatform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Algorithms
{
    public class BackwardChainingAlgorithm : IPlanningAlgorithm
    {
        //Services
        private ILoggerService _logger;

        //Input
        private IEnumerable<string> _facts;
        private IEnumerable<Rule> _rules;
        private IEnumerable<string> _goals;

        //Internal variables
        private List<string> _derivedFacts = new List<string>();
        private List<Rule> _productions = new List<Rule>();
        private List<string> _operationalGoals = new List<string>();
        private int _level;
        private int _counter;

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
            _derivedFacts = new List<string>();
            _productions = new List<Rule>();
            _operationalGoals = new List<string>();
            _level = 0;
            _counter = 0;

            _logger.WriteLine("PART 1. Data");
            _logger.WriteLine("");
            _logger.WriteLine("    1) Rules");

            foreach (var rule in _rules)
                _logger.WriteLine($"       {rule.Number}: {rule.ToString()}");

            _logger.WriteLine($"    2) Facts {string.Join(", ", _facts)}.");
            _logger.WriteLine($"    3) Goals {string.Join(", ", _goals)}.");
            _logger.WriteLine("");

            _logger.WriteLine("PART 2. Trace");
            _logger.WriteLine("");

            _level = 0;
            _counter = 0;

            bool state = true;

            foreach(var goal in _goals)
            {
                var tempState = ExecuteInternal(goal);
                if(!tempState)
                {
                    state = false;
                    break;
                }    
            }

            _logger.WriteLine("");

            _logger.WriteLine("PART 3. Results");
            _logger.Write($"    1) Goals {string.Join(", ", _goals)} ");

            if (state)
            {
                var prodCopy = new List<Rule>(_productions);
                _productions = _productions.Where(x => x.RightSide.Any(y => _goals.Contains(y)) || x.RightSide.Any(y => prodCopy.Any(z => z.LeftSide.Any(k => k == y)))).ToList();

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

                foreach(var group in groups)
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

        bool initial;
        List<string> ongoingGoals = new List<string>();

        /// <summary>
        /// Internal BC recursive algorithm
        /// </summary>
        /// <param name="goal">Goal</param>
        /// <returns>True if goal achieved, false if not</returns>
        private bool ExecuteInternal(string goal)
        {
            //initial = false;

            if (!_operationalGoals.Contains(goal))
            {
                if (_facts.Contains(goal))
                {
                    _logger.Write($"  {string.Format("{0, 2}", _counter + 1)}) {RepeatSymbol('-', _level)}Goal {goal}. Fact (initial), as facts are {string.Join(", ", _facts)}.");
                    _level--;
                    _counter++;
                    initial = true;

                    //if (_goals != goals)
                    //    _logger.Write(" Back, OK.");
                    //else
                    //    _logger.Write(" OK.");

                    _logger.WriteLine("");

                    return true;
                }
                else if (_derivedFacts.Contains(goal))
                {
                    _logger.Write($"  {string.Format("{0, 2}", _counter + 1)}) {RepeatSymbol('-', _level)}Goal {goal}. Fact (earlier inferred), as facts {string.Join(", ", _facts)} and {string.Join(", ", _derivedFacts)}.");
                    _level--;
                    _counter++;

                    //if (_goal != goal)
                    //    _logger.Write(" Back, OK.");
                    //else
                    //    _logger.Write(" OK.");

                    _logger.WriteLine("");

                    return true;
                }
                else
                {
                    _operationalGoals.Add(goal);
                    foreach (var rule in _rules)
                    {
                        if (rule.RightSide.Contains(goal))
                        {
                            _logger.WriteLine($"  {string.Format("{0, 2}", _counter + 1)}) {RepeatSymbol('-', _level)}Goal {goal}. Find {rule.Number}:{rule.ToString()}. New goals {string.Join(",", rule.LeftSide)}.");
                            ongoingGoals.AddRange(rule.LeftSide);
                            _counter++;
                            _level++;

                            bool usable = true;
                            List<string> temp_derived_facts = new List<string>();
                            List<Rule> temp_productions = new List<Rule>();
                            temp_derived_facts.AddRange(_derivedFacts);
                            temp_productions.AddRange(_productions);

                            foreach (var fact in rule.LeftSide)
                            {
                                if (!ExecuteInternal(fact))
                                {
                                    usable = false;
                                    _derivedFacts = temp_derived_facts;
                                    _productions = temp_productions;
                                    break;
                                }
                            }

                            if (usable)
                            {
                                _derivedFacts.AddRange(rule.RightSide);
                                _productions.Add(rule);
                                _operationalGoals.Remove(goal);
                                ongoingGoals.Remove(goal);
                                _logger.Write($"  {string.Format("{0, 2}", _counter + 1)}) {RepeatSymbol('-', _level)}Goal {goal}. Fact (presently inferred). Facts {string.Join(", ", _facts)} and {string.Join(", ", _derivedFacts)}.");

                                //if (_goal != goal)
                                //{
                                //    //TODO: Sample 2 - C buvo anksciau, tai nereikia back-tracking.
                                //    //TODO: Reikia prideti salyga (apgalvoti).

                                //    if (!initial)
                                //    {
                                //        _level--;
                                //        _logger.Write(" Back, OK.");
                                //    }
                                //    else
                                //        initial = false;
                                //}
                                //else
                                //    _logger.Write(" OK.");

                                _logger.WriteLine("");
                                _counter++;
                                return true;
                            }
                        }
                    }

                    if (!_rules.Any(x => x.RightSide.Contains(goal)))
                        _logger.WriteLine($"  {string.Format("{0, 2}", _counter + 1)}) {RepeatSymbol('-', _level)}Goal {goal}. No rules. Back, FAIL.");
                    else
                        _logger.WriteLine($"  {string.Format("{0, 2}", _counter + 1)}) {RepeatSymbol('-', _level)}Goal {goal}. No more rules. Back, FAIL.");

                    _level--;
                    _counter++;
                    _operationalGoals.Remove(goal);
                    ongoingGoals.Remove(goal);
                    return false;
                }
            }
            else
            {
                _logger.WriteLine($"  {string.Format("{0, 2}", _counter + 1)}) {RepeatSymbol('-', _level)}Goal {goal}. Cycle. Back, FAIL.");
                _level--;
                _counter++;
                return false;
            }
        }

        /// <summary>
        /// Repeats the symbol amount of times and forms a string
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="amount">Amount of times to repeat symbol</param>
        /// <returns>String composed of symbol repeated amount of times</returns>
        private string RepeatSymbol(char symbol, int amount)
        {
            var str = new StringBuilder();
            for (int i = 0; i < amount; i++)
                str.Append(symbol);

            return str.ToString();
        }

        public void Dispose()
        {
            _logger?.Dispose();
        }
    }
}
