using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Runtime.CompilerServices;

namespace OperatiiMatrice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            changeImage(1);
            def();

        }

        string laststring = "";
        Matrix<double> glb;
        Button[,] B;
        double[,] A;
        int ii = 0; int jj = 0, cnt = 0, sum = 0;
        double det = 0;

        public void def()
        {
            // Set the background color of the PictureBox control
            pictureBox2.BackColor = Color.White;

            // Create a new Bitmap with the desired color
            Bitmap bmp = new Bitmap(1, 1);
            bmp.SetPixel(0, 0, Color.White);

            // Assign the Bitmap to the Image property of the PictureBox control
            pictureBox2.Image = bmp;

        }
        public bool ContainsNonDigit(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return true;
                }
            }

            return false;
        }


        public Matrix<double> refresh1()
        {
            string input = richTextBox1.Text;
            if (input != "" && ContainsNonDigit(input) == true)
            {
                string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // Remove trailing spaces from each line
                for (int i = 0; i < lines.Length; ++i)
                {
                    lines[i] = lines[i].TrimEnd();
                }

                double[,] values = new double[lines.Length, lines[0].Split(' ').Length];

                // Check that each row has the same number of elements
                int numElementsPerRow = -1;
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].TrimEnd();

                    string[] lineValues = line.Split(' ');

                    // If this is the first row, record the number of elements
                    if (numElementsPerRow == -1)
                    {
                        numElementsPerRow = lineValues.Length;
                    }

                    // Check that this row has the same number of elements as the first row
                    if (lineValues.Length != numElementsPerRow)
                    {
                        MessageBox.Show("Eroare: Fiecare linie trebuie să aibă același număr de elemente");
                        return null;
                    }

                    for (int j = 0; j < lineValues.Length; j++)
                    {
                        double.TryParse(lineValues[j], out values[i, j]);
                    }
                }

                // Check that each column has the same number of elements
                int numElementsPerColumn = -1;
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    // Count the number of non-zero elements in this column
                    int numElementsInColumn = 0;
                    for (int i = 0; i < values.GetLength(0); i++)
                    {
                        if (values[i, j] != 0)
                        {
                            numElementsInColumn++;
                        }
                    }

                    // If this is the first column, record the number of elements
                    if (numElementsPerColumn == -1)
                    {
                        numElementsPerColumn = numElementsInColumn;
                    }

                    // Check that this column has the same number of elements as the first column
                    if (numElementsInColumn != numElementsPerColumn)
                    {
                        MessageBox.Show("Eroare: Fiecare coloana trebuie să aibă același număr de elemente");
                        return null;
                    }
                }

                Matrix<double> matrix = Matrix<double>.Build.DenseOfArray(values);
                return matrix;
            }
            else
            {

                return null;
            }
        }

        public Matrix<double> refresh2()
        {
            string input = richTextBox2.Text;
            if (input != "" && ContainsNonDigit(input) == true)
            {
                string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // Remove trailing spaces from each line
                for (int i = 0; i < lines.Length; ++i)
                {
                    lines[i] = lines[i].TrimEnd();
                }

                double[,] values = new double[lines.Length, lines[0].Split(' ').Length];

                // Check that each row has the same number of elements
                int numElementsPerRow = -1;
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].TrimEnd();

                    string[] lineValues = line.Split(' ');

                    // If this is the first row, record the number of elements
                    if (numElementsPerRow == -1)
                    {
                        numElementsPerRow = lineValues.Length;
                    }

                    // Check that this row has the same number of elements as the first row
                    if (lineValues.Length != numElementsPerRow)
                    {
                        MessageBox.Show("Eroare: Fiecare linie trebuie să aibă același număr de elemente");
                        return null;
                    }

                    for (int j = 0; j < lineValues.Length; j++)
                    {
                        double.TryParse(lineValues[j], out values[i, j]);
                    }
                }

                // Check that each column has the same number of elements
                int numElementsPerColumn = -1;
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    // Count the number of non-zero elements in this column
                    int numElementsInColumn = 0;
                    for (int i = 0; i < values.GetLength(0); i++)
                    {
                        if (values[i, j] != 0)
                        {
                            numElementsInColumn++;
                        }
                    }

                    // If this is the first column, record the number of elements
                    if (numElementsPerColumn == -1)
                    {
                        numElementsPerColumn = numElementsInColumn;
                    }

                    // Check that this column has the same number of elements as the first column
                    if (numElementsInColumn != numElementsPerColumn)
                    {
                        MessageBox.Show("Eroare: Fiecare coloana trebuie să aibă același număr de elemente");
                        return null;
                    }
                }

                Matrix<double> matrix = Matrix<double>.Build.DenseOfArray(values);
                return matrix;
            }
            else
            {
                return null;
            }
        }

        public Matrix<double> refresh3()
        {
            string input = richTextBox3.Text;
            if (input != "" && ContainsNonDigit(input) == true)
            {
                string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // Remove trailing spaces from each line
                for (int i = 0; i < lines.Length; ++i)
                {
                    lines[i] = lines[i].TrimEnd();
                }

                double[,] values = new double[lines.Length, lines[0].Split(' ').Length];

                // Check that each row has the same number of elements
                int numElementsPerRow = -1;
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].TrimEnd();

                    string[] lineValues = line.Split(' ');

                    // If this is the first row, record the number of elements
                    if (numElementsPerRow == -1)
                    {
                        numElementsPerRow = lineValues.Length;
                    }

                    // Check that this row has the same number of elements as the first row
                    if (lineValues.Length != numElementsPerRow)
                    {
                        MessageBox.Show("Eroare: Fiecare linie trebuie să aibă același număr de elemente");
                        return null;
                    }

                    for (int j = 0; j < lineValues.Length; j++)
                    {
                        double.TryParse(lineValues[j], out values[i, j]);
                    }
                }

                // Check that each column has the same number of elements
                int numElementsPerColumn = -1;
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    // Count the number of non-zero elements in this column
                    int numElementsInColumn = 0;
                    for (int i = 0; i < values.GetLength(0); i++)
                    {
                        if (values[i, j] != 0)
                        {
                            numElementsInColumn++;
                        }
                    }

                    // If this is the first column, record the number of elements
                    if (numElementsPerColumn == -1)
                    {
                        numElementsPerColumn = numElementsInColumn;
                    }

                    // Check that this column has the same number of elements as the first column
                    if (numElementsInColumn != numElementsPerColumn)
                    {
                        MessageBox.Show("Eroare: Fiecare coloana trebuie să aibă același număr de elemente");
                        return null;
                    }
                }

                Matrix<double> matrix = Matrix<double>.Build.DenseOfArray(values);
                return matrix;
            }
            else
            {

                return null;
            }
        }

        /*
        public Matrix<double> refresh2()
        {
            string input = richTextBox2.Text;
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Remove trailing spaces from each line
            for (int i = 0; i < lines.Length; ++i)
            {
                lines[i] = lines[i].TrimEnd();
            }

            double[,] values = new double[lines.Length, lines[0].Split(' ').Length];

            //MessageBox.Show(lines.Length + " " + lines[0].Split(' ').Length);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].TrimEnd();

                string[] lineValues = line.Split(' ');
                for (int j = 0; j < lineValues.Length; j++)
                {
                    double.TryParse(lineValues[j], out values[i, j]);
                }
            }
            Matrix<double> matrix = Matrix<double>.Build.DenseOfArray(values);
            return matrix;
        }
        */

        public static string MatrixToString(Matrix<double> matrix) // Matrice format in sir de caractere
        {
            if (matrix != null)
            {
                int numRows = matrix.RowCount;
                int numCols = matrix.ColumnCount;

                // Find the maximum width of each column
                int[] maxColumnWidths = new int[numCols];
                for (int j = 0; j < numCols; j++)
                {
                    int max = int.MinValue;
                    for (int i = 0; i < numRows; i++)
                    {
                        string valueString = matrix[i, j].ToString("0.#####");
                        int width = valueString.Length;
                        if (width > max)
                        {
                            max = width;
                        }
                    }
                    maxColumnWidths[j] = max;
                }

                // Build the formatted string
                string output = "";
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numCols; j++)
                    {
                        string valueString = matrix[i, j].ToString("0.#####");
                        int paddingWidth = maxColumnWidths[j] - valueString.Length;
                        string padding = new string(' ', paddingWidth);
                        output += valueString + padding + " ";
                    }
                    output += "\n";
                }
                return output;
            }
            return null;
        }



        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Buton Adunare Matrice
        {

            Matrix<double> mx1 = refresh1();
            Matrix<double> mx2 = refresh2();
            if (mx1 != null && mx2 != null)
            {
                glb = mx1 + mx2;
                Label label = new Label();
                label.AutoSize = true;
                label.Text = "\n" + MatrixToString(mx1 + mx2);
                flowLayoutPanel1.Controls.Add(label);
            }
            else
                MessageBox.Show("Eroare! Matricea nu contine niciun element!");

        }

        private void button5_Click(object sender, EventArgs e) // Determinant B
        {
            Matrix<double> mx2 = refresh2();
            if (mx2 != null)
            {
                if (mx2.RowCount == mx2.ColumnCount)
                    MessageBox.Show($"Determinantul este: {mx2.Determinant()}");
                else
                    MessageBox.Show("Eroare! Matricea nu este patratica! Reincercati!");
            }
        }

        private void button6_Click(object sender, EventArgs e) // Inversa Matricii B
        {
            Matrix<double> mx2 = refresh2();
            if (mx2 != null)
            {
                if (mx2.RowCount == mx2.ColumnCount)
                {
                    if (mx2.Determinant() != 0)
                    {
                        glb = mx2.Inverse();
                        Label label = new Label();
                        label.AutoSize = true;
                        label.Text = "\n" + MatrixToString(mx2.Inverse());
                        flowLayoutPanel1.Controls.Add(label);
                    }
                    else
                        MessageBox.Show("Determinantul este 0! Matricea nu are inversa!");
                }
                else
                    MessageBox.Show("Eroare! Matricea nu este patratica! Reincercati!");

            }
        }

        private void button9_Click(object sender, EventArgs e) // Ridica la putere B
        {
            Matrix<double> mx2 = refresh2();
            if (mx2 != null) {
                if (mx2.RowCount == mx2.ColumnCount)
                {
                    int putere = (int)numericUpDown2.Value;
                    glb = mx2.Power(putere);
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Text = "\n" + MatrixToString(mx2.Power(putere));
                    flowLayoutPanel1.Controls.Add(label);
                }
                else
                    MessageBox.Show("Eroare! Matricea nu este patratica! Reincercati!");

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Matrix<double> mx2 = refresh2();
            if (mx2 != null)
            {
                glb = mx2.Conjugate();
                Label label = new Label();
                label.AutoSize = true;
                label.Text = "\n" + MatrixToString(mx2.Conjugate());
                flowLayoutPanel1.Controls.Add(label);
            }
        }

        private void button19_Click(object sender, EventArgs e) //imparte A
        {
            Matrix<double> mx1 = refresh1();
            if (mx1 != null)
            {
                int nr = (int)numericUpDown5.Value;
                glb = mx1.Divide(nr);

                Label label = new Label();
                label.AutoSize = true;
                label.Text = "\n" + MatrixToString(mx1.Divide(nr));
                flowLayoutPanel1.Controls.Add(label);
            }
        }

        private void button16_Click(object sender, EventArgs e) //inmulteste A
        {
            Matrix<double> mx1 = refresh1();
            if (mx1 != null)
            {
                int nr = (int)numericUpDown6.Value;
                glb = mx1.Multiply(nr);
                Label label = new Label();
                label.AutoSize = true;
                label.Text = "\n" + MatrixToString(mx1.Multiply(nr));
                flowLayoutPanel1.Controls.Add(label);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e) // Conjugata A
        {
            Matrix<double> mx1 = refresh1();
            if (mx1 != null)
            {
                glb = mx1.Conjugate();
                Label label = new Label();
                label.AutoSize = true;
                label.Text = "\n" + MatrixToString(mx1.Conjugate());
                flowLayoutPanel1.Controls.Add(label);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)// Ridica putere A
        {
            Matrix<double> mx1 = refresh1();
            if (mx1 != null)
            {
                if (mx1.RowCount == mx1.ColumnCount)
                {
                    int putere = (int)numericUpDown1.Value;
                    glb = mx1.Power(putere);
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Text = "\n" + MatrixToString(mx1.Power(putere));
                    flowLayoutPanel1.Controls.Add(label);
                }
                else
                    MessageBox.Show("Eroare! Matricea nu este patratica! Reincercati!");

            }
        }

        private void button21_Click(object sender, EventArgs e) // Rang A
        {
            Matrix<double> mx1 = refresh1();
            if (mx1 != null)
                MessageBox.Show($"Rangul este: {mx1.Rank()}");
        }

        private void button22_Click(object sender, EventArgs e) // Transpusa A
        {
            Matrix<double> mx1 = refresh1();
            if (mx1 != null)
            {
                glb = mx1.Transpose();
                Label label = new Label();
                label.AutoSize = true;
                label.Text = "\n" + MatrixToString(mx1.Transpose());
                flowLayoutPanel1.Controls.Add(label);
            }
        }

        private void button23_Click(object sender, EventArgs e) // Inversa Matricii A
        {
            Matrix<double> mx1 = refresh1();
            if (mx1 != null)
            {
                if (mx1.RowCount == mx1.ColumnCount)
                {
                    if (mx1.Determinant() != 0)
                    {
                        glb = mx1.Inverse();
                        Label label = new Label();
                        label.AutoSize = true;
                        label.Text = "\n" + MatrixToString(mx1.Inverse());
                        flowLayoutPanel1.Controls.Add(label);
                    }
                    else
                        MessageBox.Show("Determinantul este 0! Matricea nu are inversa!");
                }
                else
                    MessageBox.Show("Eroare! Matricea nu este patratica! Reincercati!");

            }
        }

        private void button3_Click(object sender, EventArgs e) // Buton Scadere Matrice
        {
            Matrix<double> mx1 = refresh1();
            Matrix<double> mx2 = refresh2();
            if (mx1 != null && mx2 != null)
            {
                glb = mx1 - mx2;
                Label label = new Label();
                label.AutoSize = true;
                label.Text = "\n" + MatrixToString(mx1 - mx2);
                flowLayoutPanel1.Controls.Add(label);
            }
            else
                MessageBox.Show("Eroare! Matricea nu contine niciun element!");
        }

        private void button4_Click(object sender, EventArgs e) // Buton Inmultire Matrice
        {

            Matrix<double> mx1 = refresh1();
            Matrix<double> mx2 = refresh2();
            if (mx1 != null && mx2 != null)
            {
                glb = mx1 * mx2;
                Label label = new Label();
                label.AutoSize = true;
                label.Text = "\n" + MatrixToString(mx1 * mx2);
                flowLayoutPanel1.Controls.Add(label);
            }
            else
                MessageBox.Show("Eroare! Matricea nu contine niciun element!");
        }

        private void button26_Click(object sender, EventArgs e) // Stergere scris Richtextbox1
        {
            richTextBox1.Clear();
        }

        private void button25_Click(object sender, EventArgs e) // Stergere scris Richtextbox2
        {
            richTextBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e) //Swap scris intre Matrice A si Matrice B
        {
            string temp = richTextBox1.Text;
            richTextBox1.Text = richTextBox2.Text;
            richTextBox2.Text = temp;
        }

        private void button24_Click(object sender, EventArgs e) // Determinant A
        {
            Matrix<double> mx1 = refresh1();
            if (mx1 != null)
            {
                if (mx1.RowCount == mx1.ColumnCount)
                    MessageBox.Show($"Determinantul este: {mx1.Determinant()}");
                else
                    MessageBox.Show("Eroare! Matricea nu este patratica! Reincercati!");
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e) //pune in A
        {
            richTextBox1.Text = MatrixToString(glb);
        }

        private void button28_Click(object sender, EventArgs e) //pune in B
        {
            richTextBox2.Text = MatrixToString(glb);
        }

        private void button8_Click(object sender, EventArgs e) // Rang B
        {
            Matrix<double> mx2 = refresh2();
            if (mx2 != null)
                MessageBox.Show($"Determinantul este: {mx2.Rank()}");
        }

        private void button7_Click(object sender, EventArgs e) // Transpusa B
        {
            Matrix<double> mx2 = refresh2();
            if (mx2 != null)
            {
                glb = mx2.Transpose();
                Label label = new Label();
                label.AutoSize = true;
                label.Text = "\n" + MatrixToString(mx2.Transpose());
                flowLayoutPanel1.Controls.Add(label);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e) //inmulteste cu B
        {
            Matrix<double> mx2 = refresh2();
            if (mx2 != null)
            {
                glb = mx2;
                int nr = (int)numericUpDown3.Value;
                Label label = new Label();
                label.AutoSize = true;
                label.Text = "\n" + MatrixToString(mx2.Multiply(nr));
                flowLayoutPanel1.Controls.Add(label);
            }
        }

        private void button10_Click(object sender, EventArgs e) //imparte B
        {
            Matrix<double> mx2 = refresh2();
            if (mx2 != null)
            {
                int nr = (int)numericUpDown4.Value;
                glb = mx2.Divide(nr);
                Label label = new Label();
                label.AutoSize = true;
                label.Text = "\n" + MatrixToString(mx2.Divide(nr));
                flowLayoutPanel1.Controls.Add(label);
            }
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        int i = 1;

        private void changeImage(int num) //functie alterneaza poze
        {
            switch (num)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources._1;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources._2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources._3;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources._4;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources._5;
                    break;

            }
        }

        private void button14_Click(object sender, EventArgs e) //button previuous poze
        {
            i++;
            if (i > 5)
                i = 1;
            changeImage(i);
        }

        private void button12_Click(object sender, EventArgs e) //butoon next poze
        {
            i--;
            if (i < 1)
                i = 5;
            changeImage(i);
        }

        private void button15_Click_1(object sender, EventArgs e)// video site button
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Matrix_(mathematics)");
        }

        private void button17_Click_1(object sender, EventArgs e)// video site button
        {
            System.Diagnostics.Process.Start("https://ro.wikipedia.org/wiki/Matrice");
        }

        private void button29_Click(object sender, EventArgs e)// video site button
        {
            System.Diagnostics.Process.Start("https://liceunet.ro/ghid-matrice/notiuni-generale");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)// video site button
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=wAga3F8JHPc");

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e) // video site button
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=NbWyRXJyohw");

        }

        private void button32_Click(object sender, EventArgs e)// video site button
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=c8IBV0ZuBp4");
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e) //imagine triunghiului
        {
            pictureBox2.Image = Properties.Resources._11;
            timer2.Interval = 100;
            timer2.Stop();
            label10.Text = "";

            ii = 0; jj = 0; cnt = 0;
            B = new Button[3, 3];
            A = new double[4, 4];

            Matrix<double> mx3 = refresh3();

            bool verific = false;
            if (mx3 != null && (mx3.RowCount == 3 && mx3.ColumnCount == 3))
                verific = true;

            if (mx3 != null && verific == true)
            {
                det = mx3.Determinant();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Assign the double value to A
                        A[i, j] = mx3[i, j];
                    }
                }

                panel1.Controls.Clear();
                panel2.Controls.Clear();
                timer2.Start();
            }
            else
                MessageBox.Show("Eroare! Verificati matricea sa aiba format 3x3!");
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)//imagine sarrus
        {
            pictureBox2.Image = Properties.Resources._33;
            timer1.Interval = 100;
            label10.Text = "";
            timer1.Stop();
            ii = 0; jj = 0; cnt = 0;
            B = new Button[8, 8];
            A = new double[8, 8];

            Matrix<double> mx3 = refresh3();

            bool verific = false;
            if (mx3 != null && (mx3.RowCount == 3 && mx3.ColumnCount == 3))
                verific = true;

            if (mx3 != null && verific == true)
            {
                det = mx3.Determinant();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Assign the double value to A
                        A[i, j] = mx3[i, j];
                    }
                }

                for (int i = 3; i < 5; i++)
                    for (int j = 0; j < 3; j++)
                        A[i, j] = A[i - 3, j];

                panel1.Controls.Clear();
                panel2.Controls.Clear();
                timer1.Start();
            }
            else
                MessageBox.Show("Eroare! Verificati matricea sa aiba format 3x3!");
            

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button36_Click(object sender, EventArgs e)
        {
            // Get the text from the RichTextBox control
            string text = richTextBox2.Text;

            // Copy the text to the clipboard
            if (text != "")
                Clipboard.SetText(text);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            // Get the text from the RichTextBox control
            string text = richTextBox1.Text;

            // Copy the text to the clipboard
            if (text != "")
                Clipboard.SetText(text);
        }
        public void res1() // reseteaza culoarea butoaneloirrrr
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    B[i, j].BackColor = Color.Transparent; 
        }

        private void button37_Click(object sender, EventArgs e)
        {
            // Get the text from the RichTextBox control
            string text = richTextBox3.Text;

            // Copy the text to the clipboard
            Clipboard.SetText(text);
        }

        private void butona(int nr) //
        {
            panel2.Controls.Clear();
            Button b = new Button();
            b.Width = 50;
            b.Height = 50;
            
            b.Top = 0;
            b.Left = 20;
            if (nr == 1)
            {
                b.Text = "+";
                b.BackColor = Color.Turquoise;
            }
            if (nr == 2)
            {
                b.Text = "-";
                b.BackColor = Color.Pink;
            }

            panel2.Controls.Add(b);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            cnt++;

            if (cnt < 10)
            {
                B[ii, jj] = new Button();

                B[ii, jj].Width = 80;
                B[ii, jj].Height = 50;

                B[ii, jj].Top = (200 - 3 * 50) / 2 + ii * 50;
                B[ii, jj].Left = (250 - 3 * 80) / 2 + jj * 80;

                B[ii, jj].Text = A[ii, jj].ToString();
                panel1.Controls.Add(B[ii, jj]);

                if (jj == 3 - 1)
                {
                    ii++;
                    jj = 0;
                }
                else
                    jj++;
            }

            if (cnt == 9)
                timer2.Interval = 1000;

            if (cnt == 10)
            {
                butona(1);
                B[0, 0].BackColor = Color.Blue;
                B[1, 1].BackColor = Color.Blue;
                B[2, 2].BackColor = Color.Blue;
            }

            if (cnt == 11)
            {
                res1();
                butona(1);
                B[0, 1].BackColor = Color.Blue;
                B[1, 2].BackColor = Color.Blue;
                B[2, 0].BackColor = Color.Blue;
            }

            if (cnt == 12)
            {
                res1();
                butona(1);
                B[0, 2].BackColor = Color.Blue;
                B[1, 0].BackColor = Color.Blue;
                B[2, 1].BackColor = Color.Blue;
            }

            if (cnt == 13)
            {
                res1();
                butona(2);
                B[0, 2].BackColor = Color.Red;
                B[1, 1].BackColor = Color.Red;
                B[2, 0].BackColor = Color.Red;
            }

            if (cnt == 14)
            {
                res1();
                butona(2);
                B[0, 0].BackColor = Color.Red;
                B[1, 2].BackColor = Color.Red;
                B[2, 1].BackColor = Color.Red;
            }

            if (cnt == 15)
            {
                res1();
                butona(2);
                B[0, 1].BackColor = Color.Red;
                B[1, 0].BackColor = Color.Red;
                B[2, 2].BackColor = Color.Red;
            }

            if (cnt == 15)
            {
                label10.Text = det.ToString();
                timer2.Stop();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;

            if (cnt < 16)
            {
                B[ii, jj] = new Button();

                B[ii, jj].Width = 80;
                B[ii, jj].Height = 50;

                B[ii, jj].Top = (200 - 3 * 50) / 2 + ii * 50;
                B[ii, jj].Left = (250 - 3 * 80) / 2 + jj * 80;

                B[ii, jj].Text = A[ii, jj].ToString();

                if (cnt > 9) {
                    B[ii, jj].BackColor = Color.LightGray;
                }
                
                panel1.Controls.Add(B[ii, jj]);

                if (jj == 3 - 1)
                {
                    ii++;
                    jj = 0;
                }
                else
                    jj++;
            }
            
            if (cnt == 16)
                timer1.Interval = 1000;

            if (cnt == 17)
            {
                butona(1);

                B[0, 0].BackColor = Color.Blue;
                B[1, 1].BackColor = Color.Blue;
                B[2, 2].BackColor = Color.Blue;
            }

            if (cnt == 18)
            {
                butona(1);
                B[1, 0].BackColor = Color.Blue;
                B[2, 1].BackColor = Color.Blue;
                B[3, 2].BackColor = Color.Blue;
            }

            if (cnt == 19)
            {
                butona(1);
                B[2, 0].BackColor = Color.Blue;
                B[3, 1].BackColor = Color.Blue;
                B[4, 2].BackColor = Color.Blue;
            }

            if (cnt == 20)
            {
                butona(2);
                B[0, 2].BackColor = Color.Red;
                B[1, 1].BackColor = Color.Red;
                B[2, 0].BackColor = Color.Red;
            }

            if (cnt == 21)
            {
                butona(2);
                B[1, 2].BackColor = Color.Red;
                B[2, 1].BackColor = Color.Red;
                B[3, 0].BackColor = Color.Red;
            }

            if (cnt == 22)
            {

                butona(2);
                B[2, 2].BackColor = Color.Red;
                B[3, 1].BackColor = Color.Red;
                B[4, 0].BackColor = Color.Red;
            }

            if (cnt == 22)
            {
                label10.Text = det.ToString();
                timer1.Stop();
            }
                
        }
    }
}
