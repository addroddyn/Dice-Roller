
using System;

namespace DiceRoller.Rolls
{
    public class Roll
    {
        private int _numberOfDice;
        private int _numberOfSides;
        private int[] _result;
        private string _resultString;
        
        public Roll(int numberOfDice, int numberOfSides, int[] result)
        {
            _numberOfDice = numberOfDice;
            _numberOfSides = numberOfSides;
            _result = result;
            for (int i = 0; i < result.Length; i++)
            {
                _resultString += result[i].ToString();
                if (i != result.Length-1)
                    _resultString +=", ";
            }
        }
        
        public int numberOfDice
        {
            get 
            {
                return _numberOfDice;
            }
        }
        
        public int numberOfSides
        {
            get 
            {
                return _numberOfSides;
            }
        }
        
        public int[] result
        {
            get 
            {
                return _result;
            }
        }
        
        public string resultString
        {
            get
            {
                return _resultString;
            }
        }
        public string throwSummary
        {
            get
            {
                return (numberOfDice.ToString() + "d" + numberOfSides.ToString() + ": ");
            }
        }
    }
}
