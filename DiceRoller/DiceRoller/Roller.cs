
using System;
using System.Windows;
using System.Windows.Input;
using DiceRoller.Commands;
using DiceRoller.Dice;

namespace DiceRoller.Roller
{
    /// <summary>
    /// Description of Data.
    /// </summary>
    public class Thrower : BaseObject
    {
        private string _numberLabel = "How many dice?";
        private string _sidesLabel = "How many sides per die?";
        private Die _die;
        
        public Thrower()
        {
            _die = new Die();
            GenerateCommand = new GenerateDice(this);
        }
        
        public Die die
        {
            get
            {
                return _die;
            }
            set
            {
                OnPropertyChanged("die");
            }
        }
        
        public string numberLabel
        {
            get
            {
                return _numberLabel;
            }
            set
            {
                _numberLabel = value;
                OnPropertyChanged("numberLabel");
            }
        }
        
        public string sidesLabel
        {
            get
            {
                return _sidesLabel;
            }
            set
            {
                _sidesLabel = value;
                OnPropertyChanged("sidesLabel");
            }
        }
        
        public ICommand GenerateCommand
        {
            get;
            private set;
        }
        
        public void Generate()
        {
            string result = ThrowDice(int.Parse(die.numberOfDice), int.Parse(die.numberOfSides));
            MessageBox.Show(result, "The results of your throw:");
        }
        
        public bool CanUpdate {
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
        
        private string ThrowDice(int numberOfDice, int numberOfSides)
        {
            Random rnd = new Random();
            int[] resultNumbers = new int[numberOfDice];
            string result = "";
            for (int i = 0; i < resultNumbers.Length; i++)
            {
                resultNumbers[i] = rnd.Next(1, numberOfSides + 1);
                if (i == 0)
                {
                    result += resultNumbers[i];
                }
                else
                {
                    result += ", " + resultNumbers[i];
                }
            }
            return result;
        }
    }
}
