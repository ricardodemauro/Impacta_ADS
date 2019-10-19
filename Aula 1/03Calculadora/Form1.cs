using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03Calculadora
{
    public class SimpleEventArgs : EventArgs
    {
        public SimpleEventArgs(string number)
        {
            Number = number;
        }

        public string Number { get; private set; }
    }

    public partial class Form1 : Form
    {
        public string Number { get; private set; }
        public event EventHandler<SimpleEventArgs> OnNumberChanged;

        public Form1()
        {
            InitializeComponent();
            OnNumberChanged += Form1_OnNumberChanged;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            OnNumberChanged -= Form1_OnNumberChanged;
            base.OnClosing(e);
        }

        private void Form1_OnNumberChanged(object sender, SimpleEventArgs e)
        {
            textBoxResultado.Text = e.Number;
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            Number += btnSender.Text;

            OnNumberChanged?.Invoke(this, new SimpleEventArgs(Number));
        }

        private void btnCC_Click(object sender, EventArgs e)
        {
            Number = string.Empty;
            OnNumberChanged?.Invoke(this, new SimpleEventArgs(Number));
        }
    }
}
