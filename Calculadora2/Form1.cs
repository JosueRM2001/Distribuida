using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora2
{

    public partial class Form2 : Form
    {
        string operador;
        double numb1, numb2, resultado;
        Boolean ban_btn = true, ban_num = true, ban_ope = true;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Código de inicialización si es necesario
        }

        // Función para manejar la inserción de números en la pantalla
        private void AddNumberToScreen(string number)
        {
            if (ban_num)
            {
                Pantalla.Clear();
                Pantalla.Text = number;
                ban_num = false;
            }
            else
            {
                Pantalla.Text += number;
            }
            ban_btn = false;
        }

        
        // Botón para el punto decimal
        private void button17_Click(object sender, EventArgs e)
        {
            Pantalla.Text += ".";
        }

        // Función para manejar los operadores
        private void HandleOperator(string op)
        {
            operador = op;
            ban_num = true;

            if (ban_ope)
            {
                if (double.TryParse(Pantalla.Text, out numb1))
                {
                    ban_ope = false;
                }
                else
                {
                    MessageBox.Show("Número no válido");
                }
            }
            else if (!ban_btn)
            {
                if (double.TryParse(Pantalla.Text, out numb2))
                {
                    f_switch(operador);
                    numb1 = resultado; // Actualiza numb1 para la siguiente operación
                    ban_btn = true;
                    ban_num = true;
                }
                else
                {
                    MessageBox.Show("Número no válido");
                }
            }
        }

        // Botones para operadores
        private void button10_Click(object sender, EventArgs e) => HandleOperator("+");
        private void button11_Click(object sender, EventArgs e) => HandleOperator("-");
        private void button12_Click_1(object sender, EventArgs e) => HandleOperator("*");
        private void button16_Click_1(object sender, EventArgs e) => HandleOperator("/");

        // Botones de números
        private void button1_Click_1(object sender, EventArgs e) => AddNumberToScreen("1");

        private void button2_Click(object sender, EventArgs e) => AddNumberToScreen("2");

        private void button3_Click(object sender, EventArgs e) => AddNumberToScreen("3");

        private void button4_Click(object sender, EventArgs e) => AddNumberToScreen("4");

        private void button5_Click(object sender, EventArgs e) => AddNumberToScreen("5");

        private void button6_Click(object sender, EventArgs e) => AddNumberToScreen("6");

        private void button7_Click(object sender, EventArgs e) => AddNumberToScreen("7");

        private void button8_Click(object sender, EventArgs e) => AddNumberToScreen("8");

        private void button9_Click(object sender, EventArgs e) => AddNumberToScreen("9");
       

        // Botón de igual
        private void button15_Click(object sender, EventArgs e)
        {
            if (!ban_btn)
            {
                if (!ban_ope && double.TryParse(Pantalla.Text, out numb2))
                {
                    f_switch(operador);
                    ban_btn = true;
                    ban_num = true;
                    ban_ope = true;
                }
            }
        }

        // Botón de limpiar
        private void button14_Click(object sender, EventArgs e)
        {
            Pantalla.Clear();
            numb1 = numb2 = resultado = 0;
            operador = "";
            ban_btn = ban_num = ban_ope = true;
        }

        // Función para realizar las operaciones
        void f_switch(string operador)
        {
            switch (operador)
            {
                case "+":
                    resultado = numb1 + numb2;
                    break;
                case "-":
                    resultado = numb1 - numb2;
                    break;
                case "*":
                    resultado = numb1 * numb2;
                    break;
                case "/":
                    if (numb2 != 0)
                    {
                        resultado = numb1 / numb2;
                    }
                    else
                    {
                        MessageBox.Show("No se puede dividir entre cero.");
                        return; // Evita seguir si hay error
                    }
                    break;
                default:
                    MessageBox.Show("Operador no válido.");
                    return;
            }
            Pantalla.Text = resultado.ToString();
        }
    }
}
