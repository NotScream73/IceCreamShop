namespace IceCreamShopView
{
    partial class FormMessageAnswer
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
            buttonSave = new Button();
            buttonCancel = new Button();
            labelSubject = new Label();
            labelText = new Label();
            labelAnswer = new Label();
            textBoxSubject = new TextBox();
            textBoxText = new TextBox();
            textBoxAnswer = new TextBox();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(403, 385);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(484, 385);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // labelSubject
            // 
            labelSubject.AutoSize = true;
            labelSubject.Location = new Point(12, 9);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(65, 15);
            labelSubject.TabIndex = 2;
            labelSubject.Text = "Заголовок";
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Location = new Point(12, 37);
            labelText.Name = "labelText";
            labelText.Size = new Size(36, 15);
            labelText.TabIndex = 3;
            labelText.Text = "Текст";
            // 
            // labelAnswer
            // 
            labelAnswer.AutoSize = true;
            labelAnswer.Location = new Point(12, 154);
            labelAnswer.Name = "labelAnswer";
            labelAnswer.Size = new Size(38, 15);
            labelAnswer.TabIndex = 4;
            labelAnswer.Text = "Ответ";
            // 
            // textBoxSubject
            // 
            textBoxSubject.Location = new Point(83, 6);
            textBoxSubject.Name = "textBoxSubject";
            textBoxSubject.ReadOnly = true;
            textBoxSubject.Size = new Size(510, 23);
            textBoxSubject.TabIndex = 5;
            // 
            // textBoxText
            // 
            textBoxText.Location = new Point(83, 37);
            textBoxText.Multiline = true;
            textBoxText.Name = "textBoxText";
            textBoxText.ReadOnly = true;
            textBoxText.Size = new Size(510, 108);
            textBoxText.TabIndex = 6;
            // 
            // textBoxAnswer
            // 
            textBoxAnswer.Location = new Point(83, 151);
            textBoxAnswer.Multiline = true;
            textBoxAnswer.Name = "textBoxAnswer";
            textBoxAnswer.Size = new Size(510, 228);
            textBoxAnswer.TabIndex = 7;
            // 
            // FormMessageAnswer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 423);
            Controls.Add(textBoxAnswer);
            Controls.Add(textBoxText);
            Controls.Add(textBoxSubject);
            Controls.Add(labelAnswer);
            Controls.Add(labelText);
            Controls.Add(labelSubject);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Name = "FormMessageAnswer";
            Text = "Ответ на сообщения";
            Load += FormMessageAnswer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
        private Label labelSubject;
        private Label labelText;
        private Label labelAnswer;
        private TextBox textBoxSubject;
        private TextBox textBoxText;
        private TextBox textBoxAnswer;
    }
}