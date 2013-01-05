namespace ParserWallsVK
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.idGroup = new System.Windows.Forms.TextBox();
            this.RichBox = new System.Windows.Forms.RichTextBox();
            this.groupRadioButton = new System.Windows.Forms.RadioButton();
            this.userRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.countLabel = new System.Windows.Forms.Label();
            this.withEdit = new System.Windows.Forms.TextBox();
            this.onEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(13, 81);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(431, 110);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Получить сообщения";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // idGroup
            // 
            this.idGroup.Location = new System.Drawing.Point(218, 11);
            this.idGroup.Name = "idGroup";
            this.idGroup.Size = new System.Drawing.Size(100, 20);
            this.idGroup.TabIndex = 2;
            // 
            // RichBox
            // 
            this.RichBox.Location = new System.Drawing.Point(12, 198);
            this.RichBox.Name = "RichBox";
            this.RichBox.Size = new System.Drawing.Size(432, 207);
            this.RichBox.TabIndex = 3;
            this.RichBox.Text = "";
            // 
            // groupRadioButton
            // 
            this.groupRadioButton.AutoSize = true;
            this.groupRadioButton.Checked = true;
            this.groupRadioButton.Location = new System.Drawing.Point(6, 17);
            this.groupRadioButton.Name = "groupRadioButton";
            this.groupRadioButton.Size = new System.Drawing.Size(61, 17);
            this.groupRadioButton.TabIndex = 4;
            this.groupRadioButton.TabStop = true;
            this.groupRadioButton.Text = "группы";
            this.groupRadioButton.UseVisualStyleBackColor = true;
            // 
            // userRadioButton
            // 
            this.userRadioButton.AutoSize = true;
            this.userRadioButton.Location = new System.Drawing.Point(6, 40);
            this.userRadioButton.Name = "userRadioButton";
            this.userRadioButton.Size = new System.Drawing.Size(96, 17);
            this.userRadioButton.TabIndex = 5;
            this.userRadioButton.TabStop = true;
            this.userRadioButton.Text = "пользователя";
            this.userRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupRadioButton);
            this.groupBox1.Controls.Add(this.userRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 64);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "id";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(215, 35);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(127, 13);
            this.countLabel.TabIndex = 7;
            this.countLabel.Text = "На стене было записей";
            // 
            // withEdit
            // 
            this.withEdit.Location = new System.Drawing.Point(151, 5);
            this.withEdit.Name = "withEdit";
            this.withEdit.Size = new System.Drawing.Size(58, 20);
            this.withEdit.TabIndex = 8;
            this.withEdit.Text = "1";
            // 
            // onEdit
            // 
            this.onEdit.Location = new System.Drawing.Point(151, 28);
            this.onEdit.Name = "onEdit";
            this.onEdit.Size = new System.Drawing.Size(58, 20);
            this.onEdit.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "по";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 417);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.onEdit);
            this.Controls.Add(this.withEdit);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RichBox);
            this.Controls.Add(this.idGroup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox);
            this.Name = "Form1";
            this.Text = "Парсер стен";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox idGroup;
        private System.Windows.Forms.RichTextBox RichBox;
        private System.Windows.Forms.RadioButton groupRadioButton;
        private System.Windows.Forms.RadioButton userRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.TextBox withEdit;
        private System.Windows.Forms.TextBox onEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}

