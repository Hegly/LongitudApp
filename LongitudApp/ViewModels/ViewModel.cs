using System;
using System.ComponentModel;
using System.Windows.Input;

namespace LongitudApp.ViewModels
{
	public class ViewModel
	{
        // ViewModel para la pestaña Km a m
        public class KmaMViewModel : INotifyPropertyChanged
        {
            private double _kilometros;
            private double _resultado;

            public double Kilometros
            {
                get { return _kilometros; }
                set
                {
                    if (_kilometros != value)
                    {
                        _kilometros = value;
                        OnPropertyChanged(nameof(Kilometros));
                    }
                }
            }

            public double Resultado
            {
                get { return _resultado; }
                set
                {
                    if (_resultado != value)
                    {
                        _resultado = value;
                        OnPropertyChanged(nameof(Resultado));
                    }
                }
            }

            public ICommand ConvertCommand => new Command(Convert);

            private void Convert()
            {
                Resultado = Kilometros * 1000;
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // ViewModel para la pestaña m a cm
        public class MaCmViewModel : INotifyPropertyChanged
        {
            private double _metros;
            private double _resultado;

            public double Metros
            {
                get { return _metros; }
                set
                {
                    if (_metros != value)
                    {
                        _metros = value;
                        OnPropertyChanged(nameof(Metros));
                    }
                }
            }

            public double Resultado
            {
                get { return _resultado; }
                set
                {
                    if (_resultado != value)
                    {
                        _resultado = value;
                        OnPropertyChanged(nameof(Resultado));
                    }
                }
            }

            public ICommand ConvertCommand => new Command(Convert);

            private void Convert()
            {
                Resultado = Metros * 100;
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

