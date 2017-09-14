using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace INotifyPropertyChanged_Style1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public MainWindowViewModel()
        {

            InitializeCommands();
            Name = "Initial Name";
        }

        #region Properties
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                RaisePropertyChanged(value, ref _name);
            }
        }

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged<T>(T value, ref T field, [CallerMemberName] string propertyName = "")
        {
            if (!Equals(value, field))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region ICommand
        public ICommand Click { get; set; }

        private void InitializeCommands()
        {
            Click = new CustomCommand(OnClick, CanClick);
        }

        private void OnClick(object obj)
        {
            Name = "Changed Name " + new Random().Next(1, 100);
        }

        private bool CanClick(object obj) => true;
        #endregion
    }
}
