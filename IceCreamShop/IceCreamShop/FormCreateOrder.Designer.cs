namespace IceCreamShopView
{
	partial class FormCreateOrder
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
			labelCount = new Label();
			labelSum = new Label();
			comboBoxIceCream = new ComboBox();
			textBoxCount = new TextBox();
			textBoxSum = new TextBox();
			buttonSave = new Button();
			buttonCancel = new Button();
			labelClient = new Label();
			comboBoxClient = new ComboBox();
			SuspendLayout();
			// 
			// labelName
			// 
			labelName.AutoSize = true;
			labelName.Location = new Point(26, 15);
			labelName.Name = "labelName";
			labelName.Size = new Size(77, 15);
			labelName.TabIndex = 0;
			labelName.Text = "Мороженое:";
			// 
			// labelCount
			// 
			labelCount.AutoSize = true;
			labelCount.Location = new Point(26, 52);
			labelCount.Name = "labelCount";
			labelCount.Size = new Size(75, 15);
			labelCount.TabIndex = 1;
			labelCount.Text = "Количество:";
			// 
			// labelSum
			// 
			labelSum.AutoSize = true;
			labelSum.Location = new Point(26, 89);
			labelSum.Name = "labelSum";
			labelSum.Size = new Size(48, 15);
			labelSum.TabIndex = 2;
			labelSum.Text = "Сумма:";
			// 
			// comboBoxIceCream
			// 
			comboBoxIceCream.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxIceCream.FormattingEnabled = true;
			comboBoxIceCream.Location = new Point(150, 15);
			comboBoxIceCream.Margin = new Padding(3, 2, 3, 2);
			comboBoxIceCream.Name = "comboBoxIceCream";
			comboBoxIceCream.Size = new Size(230, 23);
			comboBoxIceCream.TabIndex = 3;
			comboBoxIceCream.SelectedIndexChanged += ComboBoxIceCream_SelectedIndexChanged;
			// 
			// textBoxCount
			// 
			textBoxCount.Location = new Point(150, 50);
			textBoxCount.Margin = new Padding(3, 2, 3, 2);
			textBoxCount.Name = "textBoxCount";
			textBoxCount.Size = new Size(230, 23);
			textBoxCount.TabIndex = 4;
			textBoxCount.TextChanged += TextBoxCount_TextChanged;
			// 
			// textBoxSum
			// 
			textBoxSum.Enabled = false;
			textBoxSum.Location = new Point(150, 84);
			textBoxSum.Margin = new Padding(3, 2, 3, 2);
			textBoxSum.Name = "textBoxSum";
			textBoxSum.Size = new Size(230, 23);
			textBoxSum.TabIndex = 5;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(212, 159);
			buttonSave.Margin = new Padding(3, 2, 3, 2);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(82, 22);
			buttonSave.TabIndex = 6;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(300, 159);
			buttonCancel.Margin = new Padding(3, 2, 3, 2);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(82, 22);
			buttonCancel.TabIndex = 7;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// labelClient
			// 
			labelClient.AutoSize = true;
			labelClient.Location = new Point(26, 129);
			labelClient.Name = "labelClient";
			labelClient.Size = new Size(49, 15);
			labelClient.TabIndex = 8;
			labelClient.Text = "Клиент:";
			// 
			// comboBoxClient
			// 
			comboBoxClient.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxClient.FormattingEnabled = true;
			comboBoxClient.Location = new Point(150, 121);
			comboBoxClient.Margin = new Padding(3, 2, 3, 2);
			comboBoxClient.Name = "comboBoxClient";
			comboBoxClient.Size = new Size(230, 23);
			comboBoxClient.TabIndex = 9;
			// 
			// FormCreateOrder
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(394, 192);
			Controls.Add(comboBoxClient);
			Controls.Add(labelClient);
			Controls.Add(buttonCancel);
			Controls.Add(buttonSave);
			Controls.Add(textBoxSum);
			Controls.Add(textBoxCount);
			Controls.Add(comboBoxIceCream);
			Controls.Add(labelSum);
			Controls.Add(labelCount);
			Controls.Add(labelName);
			Margin = new Padding(3, 2, 3, 2);
			Name = "FormCreateOrder";
			Text = "Заказ";
			Load += FormCreateOrder_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelName;
		private Label labelCount;
		private Label labelSum;
		private ComboBox comboBoxIceCream;
		private TextBox textBoxCount;
		private TextBox textBoxSum;
		private Button buttonSave;
		private Button buttonCancel;
		private Label labelClient;
		private ComboBox comboBoxClient;
	}
}