using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WpfAppZCzeslawem.Commands;

namespace WpfAppZCzeslawem.ModelViews {
    public class MainWindowModelView : INotifyPropertyChanged {

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowModelView() 
        {
            Wynik = "Wynik = ";
            NWDCommand = new RelayCommand(NWD);
        }
        public void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string wynik;
        public string Wynik
        {
            get { return wynik; }
            set
            {
                wynik = value;
                OnPropertyChanged(nameof(Wynik));
            }
        }
        private string arg1;
        public string Arg1 {
            get { return arg1; }
            set {
                arg1 = value;
                OnPropertyChanged(nameof(Arg1));
            }
        }
        private string arg2;
        public string Arg2 {
            get { return arg2; }
            set {
                arg2 = value;
                OnPropertyChanged(nameof(Arg2));
            }
        }
        public ICommand NWDCommand { get; set; }
        public void NWD(object obj) {
            try {
                int a = Convert.ToInt32(Arg1);
                int b = Convert.ToInt32(Arg2);
                while(a != b) {
                    if (a > b)
                        a -= b;
                    else
                        b -= a;
                }
                Wynik = $"NWD = {a}";
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
