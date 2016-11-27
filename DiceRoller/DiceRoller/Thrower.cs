using System;
using System.Windows;
using System.Windows.Input;
using DiceRoller.Commands;
using DiceRoller.Dice;
using DiceRoller.Rolls;

namespace DiceRoller.Thrower
{
    public partial class Thrower : BaseObject
    {
        
        public void Generate()
        {
            ThrowDice(int.Parse(die.numberOfDice), int.Parse(die.numberOfSides));
        }
        
        public bool CanUpdate 
        {
            get
            {
                if (IsBiggerThanZero(die.numberOfDice) && IsBiggerThanZero(die.numberOfSides))
                {
                    return true;
                }
                return false;
            }
        }
        
        private bool IsBiggerThanZero(string input)
        {
            int number;
            if (int.TryParse(input, out number) && number > 0)
            {
                return true;
            }
            return false;
        }
        
        private void ThrowDice(int numberOfDice, int numberOfSides)
        {
            Random rnd = new Random();
            int[] resultInt = new int[numberOfDice];
            for (int i = 0; i < resultInt.Length; i++)
            {
                resultInt[i] = rnd.Next(1, numberOfSides + 1);
            }
            Roll currentRoll = new Roll(numberOfDice, numberOfSides, resultInt);
            _throwHistoryRoll.Insert(0, currentRoll);
        }
        
        private void ShowInfo()
        {
            rollSum = 0;
            foreach(int digit in _currentRoll.result)
            {
                rollSum += digit;
            }
            CheckTreshold();
        }
        
        public void CheckTreshold()
        {
            successCounter = 0;
            int number;
            if (!int.TryParse(_successTreshold, out number))
            {
                successCounter = 0;
                return;
            }
            switch(_greater)
            {
                case true:
                    {
                        HigherThanTreshold();
                        break;
                    }
                case false:
                    {
                        LowerThanTreshold();
                        break;
                    }
            }
        }
        
        private void HigherThanTreshold()
        {
            foreach (int digit in _currentRoll.result)
            {
                if (digit >= int.Parse(_successTreshold))
                {
                    successCounter++;
                }
            }
        }
        
        private void LowerThanTreshold()
        {
            foreach (int digit in _currentRoll.result)
            {
                if (digit <= int.Parse(_successTreshold))
                {
                    successCounter++;
                }
            }
        }
    }
}
