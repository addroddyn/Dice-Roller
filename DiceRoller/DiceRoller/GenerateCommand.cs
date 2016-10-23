
using System;
using System.Windows.Input;
using DiceRoller.Roller;

namespace DiceRoller.Commands
{
    /// <summary>
    /// Description of GenerateCommand.
    /// </summary>
    public class GenerateDice : ICommand
    {
        #region ICommand implementation

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    
        public bool CanExecute(object parameter)
        {
            return _thrower.CanUpdate;
        }
    
        public void Execute(object parameter)
        {
            _thrower.Generate();
        }
    
        #endregion

        public GenerateDice(Thrower thrower)
        {
            _thrower = thrower;
        }
        
        private Thrower _thrower;
    }
}
