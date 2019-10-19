using System.Globalization;
using System.Windows.Input;
using WPF.Calculadora.Commands;

namespace WPF.Calculadora.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private decimal _operador;
        private bool _limpaResultado = false;

        private string _resultado;
        public string Resultado 
        { 
            get { return _resultado; } 
            set { SetProperty(ref _resultado, value); } 
        }

        public ICommand PressionaNumeroCmd { get; set; }

        public ICommand PressionaSomaCmd { get; set; }

        public ICommand PressionaSubtracaoCmd { get; set; }

        public MainViewModel()
        {
            _operador = 0;
            Resultado = "";

            PressionaNumeroCmd = new RelayCommand(PressionaNumero);
            PressionaSomaCmd = new RelayCommand(param => PressionaSoma());
            PressionaSubtracaoCmd = new RelayCommand(param => PressionaSubtracao());
        }

        void PressionaNumero(object number)
        {
            if (_limpaResultado)
            {
                Resultado = number.ToString();
                _limpaResultado = false;
            }
            else
                Resultado += number.ToString();
        }

        void PressionaSoma()
        {
            _limpaResultado = true;

            _operador += decimal.Parse(Resultado);
            Resultado = _operador.ToString(CultureInfo.CurrentUICulture);
        }

        void PressionaSubtracao()
        {
            _limpaResultado = true;

            _operador -= decimal.Parse(Resultado);
            Resultado = _operador.ToString(CultureInfo.CurrentUICulture);
        }
    }
}
