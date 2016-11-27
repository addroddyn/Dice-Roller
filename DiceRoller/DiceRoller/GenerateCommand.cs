
using System;
using System.Windows.Input;

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

        public GenerateDice(DiceRoller.Thrower.Thrower thrower)
        {
            _thrower = thrower;
        }
        
        private DiceRoller.Thrower.Thrower _thrower;
    }
}
