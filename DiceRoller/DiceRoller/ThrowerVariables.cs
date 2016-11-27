using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DiceRoller.Commands;
using DiceRoller.Dice;
using DiceRoller.Rolls;

namespace DiceRoller.Thrower
{
    public partial class Thrower : BaseObject
    {
        private string _numberLabel = "How many dice?";
        private string _sidesLabel = "How many sides per die?";
        private string _diceColumnLabel = "Dice Type";
        private string _historyColumnLabel = "Throw History";
        private string _infoLabel = "Throw Information";
        private string _rollSumLabel = "The sum of your throw:";
        private int _rollSum = 0;
        private string _successLabel = "Set the success treshold:";
        private string _successTreshold = "0";
        private bool _greater = true;
        private int _successCounter = 0;
        private Roll _currentRoll;
        private ObservableCollection<Roll> _throwHistoryRoll = new ObservableCollection<Roll>();
        private Die _die;
        
        public Thrower()
        {
            _die = new Die();
            GenerateCommand = new GenerateDice(this);
        }
        
        public ICommand GenerateCommand
        {
            get;
            private set;
        }
        
        public Die die
        {
            get
            {
                return _die;
            }
            set
            {
                _die = value;
                OnPropertyChanged("die");
            }
        }
        
        public string numberLabel
        {
            get
            {
                return _numberLabel;
            }
        }
        
        public string sidesLabel
        {
            get
            {
                return _sidesLabel;
            }
        }
        
        public string diceColumnLabel
        {
            get
            {
                return _diceColumnLabel;
            }
        }
        
        public string historyColumnLabel
        {
            get
            {
                return _historyColumnLabel;
            }
        }
        
        public Roll currentRoll
        {
            get 
            {
                return _currentRoll;
            }
            set 
            {
                _currentRoll = value;
                OnPropertyChanged("currentRoll");
                ShowInfo();
            }
        }
        
        public bool greater
        {
            get 
            {
                return _greater;
            }
            set
            {
                _greater = value;
                OnPropertyChanged("greater");
                CheckTreshold();
            }
        }
        
        public ObservableCollection<Roll> throwHistoryRoll
        {
            get
            {
                return _throwHistoryRoll;
            }
            set
            {
                _throwHistoryRoll = value;
                OnPropertyChanged("throwHistoryRoll");
            }
        }
        
        public string infoLabel
        {
            get
            {
                return _infoLabel;
            }
        }
        
        public string rollSumLabel
        {
            get
            {
                return _rollSumLabel;
            }
        }
        
        public int rollSum
        {
            get
            {
                return _rollSum;
            }
            set 
            {
                _rollSum = value;
                OnPropertyChanged("rollSum");
            }
        }
        
        public string successLabel
        {
            get
            {
                return _successLabel;
            }
        }
        
        public string successTreshold
        {
            get 
            {
                return _successTreshold;
            }
            set
            {
                _successTreshold = value;
                OnPropertyChanged("successTreshold");
                CheckTreshold();
            }
        }
        
        public int successCounter
        {
            get
            {
                return _successCounter;
            }
            set
            {
                _successCounter = value;
                OnPropertyChanged("successCounter");
            }
        }
    }
}
