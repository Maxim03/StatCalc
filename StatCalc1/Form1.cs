using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatCalc1
{
    public partial class Form1 : Form
    {
        List<double> data;
        CalcManager manager;
        public Form1()
        {
            InitializeComponent();
            data = new List<double>();
            manager = new CalcManager();
        }

        private void addValue()
        {
            string input = inputField.Text;
            if (String.IsNullOrEmpty(input))
            {
                MessageBox.Show("Ви не ввели вихідне значення", "Попередження",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                inputField.Focus();
            }
            else
            {
                try
                {
                    double value = Convert.ToDouble(input);
                    valuesList.Items.Add(value);
                    data.Add(value);
                    inputField.Clear();
                    inputField.Focus();
                }
                catch (Exception error)
                {
                    MessageBox.Show($"Помилка при додаванні величини. \n{error.Message}", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inputField.Clear();
                    inputField.Focus();
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addValue();
            
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            inputField.Clear();
            inputField.Focus();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int k = valuesList.SelectedIndex;
            if (k == -1)
            {
                MessageBox.Show("Ви не вказали видаляєме значення", "Попередження",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                valuesList.Items.RemoveAt(k);
                data.RemoveAt(k);
            }

            MessageBox.Show(k.ToString());
        }

        private void cleareButton_Click(object sender, EventArgs e)
        {
            valuesList.Items.Clear();
            data.Clear();
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            if (data.Count == 0)
            {
                MessageBox.Show("Відсутні данні для обчислення", "Попередження",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                manager.Data = data;
                manager.SortData();
                manager.CalcAverage();
                manager.BuildDeviations();
                manager.CalcError();

                foreach (double x in manager.Data)
                {
                    sortDataList.Text += $"{x:F}  _  ";
                }

                foreach (double y in manager.Deviations)
                {
                    deviationList.Text += $"{y:F}  _  ";
                }

                resultField.Text = $"{manager.Average:F} +- {manager.MeasureError:F}";
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void valuesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void inputField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addValue();
            }
        }
    }
}
