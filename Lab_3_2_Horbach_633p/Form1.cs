using System.Globalization;

namespace Lab_3_2_Horbach_633p
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_found_Click(object sender, EventArgs e)
        {
            try
            {
                Methods method_Wald = new Methods();
                method_Wald.Matrix_from_textbox(textBox_matrix.Text);
                string result_Wald = method_Wald.Criteria_Wald();
                textBox_Wald.Text = result_Wald;

                Methods method_Maximax = new Methods();
                method_Maximax.Matrix_from_textbox(textBox_matrix.Text);
                string result_Maximax = method_Maximax.Criteria_Maximax();
                textBox_Maximax.Text = result_Maximax;

                double a = double.Parse(textBox_y.Text, CultureInfo.InvariantCulture);
                Methods method_Hurwicz = new Methods();
                method_Hurwicz.Matrix_from_textbox(textBox_matrix.Text);
                string result_Hurwicz = method_Hurwicz.Criteria_Hurwicz(a);
                textBox_Hurwicz.Text = result_Hurwicz;


                Methods method_Savage = new Methods();
                method_Savage.Matrix_from_textbox(textBox_matrix.Text);
                string result_Savage = method_Savage.Criteria_Savage();
                textBox_Savage.Text = result_Savage;

                Methods method_Laplace = new Methods();
                method_Laplace.Matrix_from_textbox(textBox_matrix.Text);
                string result_Laplace = method_Laplace.Criteria_Laplace();
                textBox_Laplace.Text = result_Laplace;

                string input = textBox_p.Text;

                double[] p = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(s => double.Parse(s, CultureInfo.InvariantCulture))
                                  .ToArray();
                Methods method_Bayes = new Methods();
                method_Bayes.Matrix_from_textbox(textBox_matrix.Text);
                string result_Bayes = method_Bayes.Criteria_Bayes(p);
                textBox_Bayes.Text = result_Bayes;

                Methods method_all_s = new Methods();
                method_all_s.Matrix_from_textbox(textBox_matrix.Text);
                string result_all_s = method_all_s.Get_most_strategies(a, p);
                textBox_offten.Text = result_all_s;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка обчислення: " + ex.Message);
            }
        }

        private void button1_protocol(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt";
            sfd.FileName = "protocol.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Methods m = new Methods();
                m.Matrix_from_textbox(textBox_matrix.Text);

                double a = double.Parse(textBox_y.Text, CultureInfo.InvariantCulture);
                double[] p = textBox_p.Text.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToArray();

                string filePath = @"C:\Users\Arina Gorbach\Desktop\Lab_3.2_Horbach_633p.txt";
                m.SaveDetailedProtocolToFile(filePath, a, p);
                MessageBox.Show("Протокол успішно збережено!");
            }

        }
    }
}
