using System;

namespace DiceRoller.Dice
{
    public class Die : BaseObject
    {
        private string _numberOfDice;
        private string _numberOfSides;
        
        public Die()
        {
            _numberOfDice = "1";
            _numberOfSides = "6";
        }
        
        public string numberOfDice
        {
            get
            {
                return _numberOfDice;
            }
            set
            {
                _numberOfDice = value;
                OnPropertyChanged("numberOfDice");
            }
        }
        
        public string numberOfSides
        {
            get
            {
                return _numberOfSides;
            }
            set
            {
                _numberOfSides = value;
                OnPropertyChanged("numberOfSides");
            }
        }
    }
}
