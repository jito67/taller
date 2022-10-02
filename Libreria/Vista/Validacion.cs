using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    class Validacion
    {
        public string validaRut(string ElNumero, TextBox Rut)
        {
            string Resultado = "";
            int Multiplicador = 2;
            int iNum = 0;
            int Suma = 0;
            int n = ElNumero.Length - 1;

            if (Rut.TextLength == ElNumero.Length && Rut.TextLength >= 8)
            {
                for (int i = 7; i >= 0; i--)
                {
                    //MessageBox.Show(Convert.ToInt32(ElNumero.Substring(i, 1)).ToString());
                    iNum = Convert.ToInt32(ElNumero.Substring(i, 1));

                    Suma += iNum * Multiplicador;
                    Multiplicador += 1;
                    if (Multiplicador == 8)
                    {
                        Multiplicador = 2;
                    }
                }
                Resultado = Convert.ToString(11 - (Suma % 11));
                if (Resultado == "10")
                    Resultado = "K";
                if (Resultado == "11")
                    Resultado = "0";
                //MessageBox.Show(Resultado);
            }
            return Resultado;
        }

        public void SoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Debe ingresar solo Números 0 al 9");
            }
        }
    }
}
