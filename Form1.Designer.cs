namespace Lab2
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
            txtNa = new TextBox();
            txtDeltaK = new TextBox();
            txtDeltaThreads = new TextBox();
            txtK = new TextBox();
            txtNThreads = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            button1 = new Button();
            countCore = new Label();
            clockFreq = new Label();
            SuspendLayout();
            // 
            // txtNa
            // 
            txtNa.Location = new Point(43, 125);
            txtNa.Name = "txtNa";
            txtNa.Size = new Size(236, 27);
            txtNa.TabIndex = 0;
            // 
            // txtDeltaK
            // 
            txtDeltaK.Location = new Point(409, 219);
            txtDeltaK.Name = "txtDeltaK";
            txtDeltaK.Size = new Size(341, 27);
            txtDeltaK.TabIndex = 2;
            // 
            // txtDeltaThreads
            // 
            txtDeltaThreads.Location = new Point(43, 219);
            txtDeltaThreads.Name = "txtDeltaThreads";
            txtDeltaThreads.Size = new Size(317, 27);
            txtDeltaThreads.TabIndex = 3;
            // 
            // txtK
            // 
            txtK.Location = new Point(559, 125);
            txtK.Name = "txtK";
            txtK.Size = new Size(191, 27);
            txtK.TabIndex = 4;
            // 
            // txtNThreads
            // 
            txtNThreads.Location = new Point(347, 125);
            txtNThreads.Name = "txtNThreads";
            txtNThreads.Size = new Size(141, 27);
            txtNThreads.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(43, 27);
            label1.Name = "label1";
            label1.Size = new Size(214, 33);
            label1.TabIndex = 6;
            label1.Text = "Входные данные";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(43, 89);
            label2.Name = "label2";
            label2.Size = new Size(236, 22);
            label2.TabIndex = 7;
            label2.Text = "Кол-во элементов массива";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(347, 89);
            label6.Name = "label6";
            label6.Size = new Size(141, 22);
            label6.TabIndex = 11;
            label6.Text = "Кол-во потоков";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(559, 89);
            label3.Name = "label3";
            label3.Size = new Size(191, 22);
            label3.TabIndex = 12;
            label3.Text = "Параметр сложности";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(43, 184);
            label4.Name = "label4";
            label4.Size = new Size(317, 22);
            label4.TabIndex = 13;
            label4.Text = "Шаг изменения количества потоков";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(409, 184);
            label5.Name = "label5";
            label5.Size = new Size(341, 22);
            label5.TabIndex = 14;
            label5.Text = "Шаг изменения параметра сложности ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(43, 292);
            label7.Name = "label7";
            label7.Size = new Size(233, 33);
            label7.TabIndex = 16;
            label7.Text = "Выходные данные";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(43, 352);
            label8.Name = "label8";
            label8.Size = new Size(157, 22);
            label8.TabIndex = 17;
            label8.Text = "Тактовая частота";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(252, 352);
            label9.Name = "label9";
            label9.Size = new Size(152, 22);
            label9.TabIndex = 18;
            label9.Text = "Количество ядер";
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(657, 366);
            button1.Name = "button1";
            button1.Size = new Size(115, 47);
            button1.TabIndex = 19;
            button1.Text = "Рассчёт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // countCore
            // 
            countCore.AutoSize = true;
            countCore.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            countCore.Location = new Point(252, 387);
            countCore.Name = "countCore";
            countCore.Size = new Size(127, 26);
            countCore.TabIndex = 20;
            countCore.Text = "кол-во ядер";
            // 
            // clockFreq
            // 
            clockFreq.AutoSize = true;
            clockFreq.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            clockFreq.Location = new Point(43, 387);
            clockFreq.Name = "clockFreq";
            clockFreq.Size = new Size(177, 26);
            clockFreq.TabIndex = 21;
            clockFreq.Text = "тактовая частота";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(clockFreq);
            Controls.Add(countCore);
            Controls.Add(button1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNThreads);
            Controls.Add(txtK);
            Controls.Add(txtDeltaThreads);
            Controls.Add(txtDeltaK);
            Controls.Add(txtNa);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNa;
        private TextBox txtDeltaK;
        private TextBox txtDeltaThreads;
        private TextBox txtK;
        private TextBox txtNThreads;
        private Label label1;
        private Label label2;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button button1;
        private Label countCore;
        private Label clockFreq;
    }
}