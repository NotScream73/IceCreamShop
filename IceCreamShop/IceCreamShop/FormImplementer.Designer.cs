namespace IceCreamShopView
{
    partial class FormImplementer
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
            labelName = new Label();
            labelWorkExperience = new Label();
            textBoxName = new TextBox();
            textBoxWorkExperience = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            textBoxPassword = new TextBox();
            labelPassword = new Label();
            textBoxQualification = new TextBox();
            labelQualification = new Label();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(27, 14);
            labelName.Name = "labelName";
            labelName.Size = new Size(37, 15);
            labelName.TabIndex = 0;
            labelName.Text = "ФИО:";
            // 
            // labelWorkExperience
            // 
            labelWorkExperience.AutoSize = true;
            labelWorkExperience.Location = new Point(27, 73);
            labelWorkExperience.Name = "labelWorkExperience";
            labelWorkExperience.Size = new Size(82, 15);
            labelWorkExperience.TabIndex = 1;
            labelWorkExperience.Text = "Стаж работы:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(127, 12);
            textBoxName.Margin = new Padding(3, 2, 3, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(263, 23);
            textBoxName.TabIndex = 2;
            // 
            // textBoxWorkExperience
            // 
            textBoxWorkExperience.Location = new Point(127, 70);
            textBoxWorkExperience.Margin = new Padding(3, 2, 3, 2);
            textBoxWorkExperience.Name = "textBoxWorkExperience";
            textBoxWorkExperience.Size = new Size(82, 23);
            textBoxWorkExperience.TabIndex = 3;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(127, 116);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(82, 22);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(254, 116);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(82, 22);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(127, 43);
            textBoxPassword.Margin = new Padding(3, 2, 3, 2);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(263, 23);
            textBoxPassword.TabIndex = 7;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(27, 45);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(37, 15);
            labelPassword.TabIndex = 6;
            labelPassword.Text = "ФИО:";
            // 
            // textBoxQualification
            // 
            textBoxQualification.Location = new Point(322, 73);
            textBoxQualification.Margin = new Padding(3, 2, 3, 2);
            textBoxQualification.Name = "textBoxQualification";
            textBoxQualification.Size = new Size(68, 23);
            textBoxQualification.TabIndex = 9;
            // 
            // labelQualification
            // 
            labelQualification.AutoSize = true;
            labelQualification.Location = new Point(222, 76);
            labelQualification.Name = "labelQualification";
            labelQualification.Size = new Size(91, 15);
            labelQualification.TabIndex = 8;
            labelQualification.Text = "Квалификация:";
            // 
            // FormImplementer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 155);
            Controls.Add(textBoxQualification);
            Controls.Add(labelQualification);
            Controls.Add(textBoxPassword);
            Controls.Add(labelPassword);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxWorkExperience);
            Controls.Add(textBoxName);
            Controls.Add(labelWorkExperience);
            Controls.Add(labelName);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormImplementer";
            Text = "Исполнитель";
            Load += FormImplementer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelWorkExperience;
        private TextBox textBoxName;
        private TextBox textBoxWorkExperience;
        private Button buttonSave;
        private Button buttonCancel;
        private TextBox textBoxPassword;
        private Label labelPassword;
        private TextBox textBoxQualification;
        private Label labelQualification;
    }
}