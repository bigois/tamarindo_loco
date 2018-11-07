using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestDrive.ViewModels {
    public abstract class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] String name = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
