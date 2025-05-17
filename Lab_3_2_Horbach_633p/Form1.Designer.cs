namespace Lab_3_2_Horbach_633p
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox_matrix = new TextBox();
            textBox_y = new TextBox();
            textBox_p = new TextBox();
            button_found = new Button();
            textBox_Wald = new TextBox();
            textBox_Maximax = new TextBox();
            textBox_Hurwicz = new TextBox();
            textBox_Savage = new TextBox();
            textBox_offten = new TextBox();
            textBox_Bayes = new TextBox();
            textBox_Laplace = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            button_protocol = new Button();
            SuspendLayout();
            // 
            // textBox_matrix
            // 
            textBox_matrix.Location = new Point(12, 50);
            textBox_matrix.Multiline = true;
            textBox_matrix.Name = "textBox_matrix";
            textBox_matrix.Size = new Size(300, 288);
            textBox_matrix.TabIndex = 0;
            // 
            // textBox_y
            // 
            textBox_y.Location = new Point(450, 60);
            textBox_y.Name = "textBox_y";
            textBox_y.Size = new Size(82, 27);
            textBox_y.TabIndex = 1;
            // 
            // textBox_p
            // 
            textBox_p.Location = new Point(333, 120);
            textBox_p.Name = "textBox_p";
            textBox_p.Size = new Size(199, 27);
            textBox_p.TabIndex = 2;
            // 
            // button_found
            // 
            button_found.Location = new Point(333, 179);
            button_found.Name = "button_found";
            button_found.Size = new Size(199, 56);
            button_found.TabIndex = 3;
            button_found.Text = "Знайти оптимальні стратегії";
            button_found.UseVisualStyleBackColor = true;
            button_found.Click += button_found_Click;
            // 
            // textBox_Wald
            // 
            textBox_Wald.Location = new Point(333, 311);
            textBox_Wald.Name = "textBox_Wald";
            textBox_Wald.ReadOnly = true;
            textBox_Wald.Size = new Size(199, 27);
            textBox_Wald.TabIndex = 4;
            // 
            // textBox_Maximax
            // 
            textBox_Maximax.Location = new Point(333, 383);
            textBox_Maximax.Name = "textBox_Maximax";
            textBox_Maximax.ReadOnly = true;
            textBox_Maximax.Size = new Size(199, 27);
            textBox_Maximax.TabIndex = 5;
            // 
            // textBox_Hurwicz
            // 
            textBox_Hurwicz.Location = new Point(333, 451);
            textBox_Hurwicz.Name = "textBox_Hurwicz";
            textBox_Hurwicz.ReadOnly = true;
            textBox_Hurwicz.Size = new Size(199, 27);
            textBox_Hurwicz.TabIndex = 6;
            // 
            // textBox_Savage
            // 
            textBox_Savage.Location = new Point(333, 525);
            textBox_Savage.Name = "textBox_Savage";
            textBox_Savage.ReadOnly = true;
            textBox_Savage.Size = new Size(199, 27);
            textBox_Savage.TabIndex = 7;
            // 
            // textBox_offten
            // 
            textBox_offten.Location = new Point(333, 599);
            textBox_offten.Name = "textBox_offten";
            textBox_offten.ReadOnly = true;
            textBox_offten.Size = new Size(199, 27);
            textBox_offten.TabIndex = 8;
            // 
            // textBox_Bayes
            // 
            textBox_Bayes.Location = new Point(12, 383);
            textBox_Bayes.Name = "textBox_Bayes";
            textBox_Bayes.ReadOnly = true;
            textBox_Bayes.Size = new Size(253, 27);
            textBox_Bayes.TabIndex = 9;
            // 
            // textBox_Laplace
            // 
            textBox_Laplace.Location = new Point(12, 451);
            textBox_Laplace.Name = "textBox_Laplace";
            textBox_Laplace.ReadOnly = true;
            textBox_Laplace.Size = new Size(253, 27);
            textBox_Laplace.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(257, 20);
            label1.TabIndex = 11;
            label1.Text = "Матриця користності результатів U:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(333, 67);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 12;
            label2.Text = "Кофіцієнт Y:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(333, 97);
            label3.Name = "label3";
            label3.Size = new Size(138, 20);
            label3.TabIndex = 13;
            label3.Text = "Стратегії природи:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(333, 288);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 14;
            label4.Text = "Критерії Вальда:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(333, 360);
            label5.Name = "label5";
            label5.Size = new Size(151, 20);
            label5.TabIndex = 15;
            label5.Text = "Критерії максімаксу:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(333, 428);
            label6.Name = "label6";
            label6.Size = new Size(126, 20);
            label6.TabIndex = 16;
            label6.Text = "Критерії Гурвіца:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(333, 502);
            label7.Name = "label7";
            label7.Size = new Size(130, 20);
            label7.TabIndex = 17;
            label7.Text = "Критерії Севіджа:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(333, 576);
            label8.Name = "label8";
            label8.Size = new Size(151, 20);
            label8.TabIndex = 18;
            label8.Text = "Найчастіші стратегії:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 360);
            label9.Name = "label9";
            label9.Size = new Size(122, 20);
            label9.TabIndex = 19;
            label9.Text = "Критерії Байєса:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 428);
            label10.Name = "label10";
            label10.Size = new Size(132, 20);
            label10.TabIndex = 20;
            label10.Text = "Критерії Лапласа:";
            // 
            // button_protocol
            // 
            button_protocol.Location = new Point(12, 525);
            button_protocol.Name = "button_protocol";
            button_protocol.Size = new Size(262, 80);
            button_protocol.TabIndex = 21;
            button_protocol.Text = "Отримати протокол обчислення";
            button_protocol.UseVisualStyleBackColor = true;
            button_protocol.Click += button1_protocol;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 638);
            Controls.Add(button_protocol);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_Laplace);
            Controls.Add(textBox_Bayes);
            Controls.Add(textBox_offten);
            Controls.Add(textBox_Savage);
            Controls.Add(textBox_Hurwicz);
            Controls.Add(textBox_Maximax);
            Controls.Add(textBox_Wald);
            Controls.Add(button_found);
            Controls.Add(textBox_p);
            Controls.Add(textBox_y);
            Controls.Add(textBox_matrix);
            Name = "Form1";
            Text = "Lab_3.2_Horbach_633p";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_matrix;
        private TextBox textBox_y;
        private TextBox textBox_p;
        private Button button_found;
        private TextBox textBox_Wald;
        private TextBox textBox_Maximax;
        private TextBox textBox_Hurwicz;
        private TextBox textBox_Savage;
        private TextBox textBox_offten;
        private TextBox textBox_Bayes;
        private TextBox textBox_Laplace;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button button_protocol;
    }
}
