namespace IceCreamShopView
{
    partial class FormMessages
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
            dataGridView = new DataGridView();
            buttonPrevious = new Button();
            buttonNext = new Button();
            labelPage = new Label();
            buttonAnswer = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(776, 426);
            dataGridView.TabIndex = 0;
            // 
            // buttonPrevious
            // 
            buttonPrevious.Enabled = false;
            buttonPrevious.Location = new Point(257, 448);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new Size(75, 23);
            buttonPrevious.TabIndex = 1;
            buttonPrevious.Text = "<";
            buttonPrevious.UseVisualStyleBackColor = true;
            buttonPrevious.Click += ButtonPrevious_Click;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(480, 448);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(75, 23);
            buttonNext.TabIndex = 2;
            buttonNext.Text = ">";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += ButtonNext_Click;
            // 
            // labelPage
            // 
            labelPage.AutoSize = true;
            labelPage.Location = new Point(387, 452);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(0, 15);
            labelPage.TabIndex = 3;
            // 
            // buttonAnswer
            // 
            buttonAnswer.Location = new Point(12, 448);
            buttonAnswer.Name = "buttonAnswer";
            buttonAnswer.Size = new Size(75, 23);
            buttonAnswer.TabIndex = 4;
            buttonAnswer.Text = "Ответить";
            buttonAnswer.UseVisualStyleBackColor = true;
            buttonAnswer.Click += ButtonAnswer_Click;
            // 
            // FormMessages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 483);
            Controls.Add(buttonAnswer);
            Controls.Add(labelPage);
            Controls.Add(buttonNext);
            Controls.Add(buttonPrevious);
            Controls.Add(dataGridView);
            Name = "FormMessages";
            Text = "Сообщения";
            Load += FormMessages_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Button buttonPrevious;
        private Button buttonNext;
        private Label labelPage;
        private Button buttonAnswer;
    }
}