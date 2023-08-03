namespace IceCreamShopView
{
    partial class FormMain
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
            menuStrip = new MenuStrip();
            справочникиToolStripMenuItem = new ToolStripMenuItem();
            AdditivesToolStripMenuItem = new ToolStripMenuItem();
            IceCreamsToolStripMenuItem = new ToolStripMenuItem();
            ShopsToolStripMenuItem = new ToolStripMenuItem();
            ClientsToolStripMenuItem = new ToolStripMenuItem();
            ImplementersToolStripMenuItem = new ToolStripMenuItem();
            отчётыToolStripMenuItem = new ToolStripMenuItem();
            IceCreamsReportToolStripMenuItem = new ToolStripMenuItem();
            ShopsReportToolStripMenuItem = new ToolStripMenuItem();
            IceCreamAdditivesReportToolStripMenuItem = new ToolStripMenuItem();
            ShopIceCreamsReportToolStripMenuItem = new ToolStripMenuItem();
            OrdersReportToolStripMenuItem = new ToolStripMenuItem();
            GroupedOrdersReportToolStripMenuItem = new ToolStripMenuItem();
            StartWorkingToolStripMenuItem = new ToolStripMenuItem();
            MessagesToolStripMenuItem = new ToolStripMenuItem();
            dataGridView = new DataGridView();
            buttonCreateOrder = new Button();
            buttonTakeOrderInWork = new Button();
            buttonOrderReady = new Button();
            buttonIssuedOrder = new Button();
            buttonRef = new Button();
            buttonAddIceCream = new Button();
            buttonSellIceCream = new Button();
            MessagesToolStripMenuItem = new ToolStripMenuItem();
            CreateBackUpToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, отчётыToolStripMenuItem, StartWorkingToolStripMenuItem, MessagesToolStripMenuItem, CreateBackUpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 2, 0, 2);
            menuStrip.Size = new Size(1185, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "Справочники";
            // 
            // справочникиToolStripMenuItem
            // 
            справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AdditivesToolStripMenuItem, IceCreamsToolStripMenuItem, ShopsToolStripMenuItem, ClientsToolStripMenuItem, ImplementersToolStripMenuItem });
            справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            справочникиToolStripMenuItem.Size = new Size(94, 20);
            справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // AdditivesToolStripMenuItem
            // 
            AdditivesToolStripMenuItem.Name = "AdditivesToolStripMenuItem";
            AdditivesToolStripMenuItem.Size = new Size(149, 22);
            AdditivesToolStripMenuItem.Text = "Добавки";
            AdditivesToolStripMenuItem.Click += AdditivesToolStripMenuItem_Click;
            // 
            // IceCreamsToolStripMenuItem
            // 
            IceCreamsToolStripMenuItem.Name = "IceCreamsToolStripMenuItem";
            IceCreamsToolStripMenuItem.Size = new Size(149, 22);
            IceCreamsToolStripMenuItem.Text = "Мороженые";
            IceCreamsToolStripMenuItem.Click += IceCreamsToolStripMenuItem_Click;
            // 
            // ShopsToolStripMenuItem
            // 
            ShopsToolStripMenuItem.Name = "ShopsToolStripMenuItem";
            ShopsToolStripMenuItem.Size = new Size(149, 22);
            ShopsToolStripMenuItem.Text = "Магазины";
            ShopsToolStripMenuItem.Click += ShopsToolStripMenuItem_Click;
            // 
            // ClientsToolStripMenuItem
            // 
            ClientsToolStripMenuItem.Name = "ClientsToolStripMenuItem";
            ClientsToolStripMenuItem.Size = new Size(149, 22);
            ClientsToolStripMenuItem.Text = "Клиенты";
            ClientsToolStripMenuItem.Click += ClientsToolStripMenuItem_Click;
            // 
            // ImplementersToolStripMenuItem
            // 
            ImplementersToolStripMenuItem.Name = "ImplementersToolStripMenuItem";
            ImplementersToolStripMenuItem.Size = new Size(149, 22);
            ImplementersToolStripMenuItem.Text = "Исполнители";
            ImplementersToolStripMenuItem.Click += ImplementersToolStripMenuItem_Click;
            // 
            // отчётыToolStripMenuItem
            // 
            отчётыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { IceCreamsReportToolStripMenuItem, ShopsReportToolStripMenuItem, IceCreamAdditivesReportToolStripMenuItem, ShopIceCreamsReportToolStripMenuItem, OrdersReportToolStripMenuItem, GroupedOrdersReportToolStripMenuItem });
            отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            отчётыToolStripMenuItem.Size = new Size(60, 20);
            отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // IceCreamsReportToolStripMenuItem
            // 
            IceCreamsReportToolStripMenuItem.Name = "IceCreamsReportToolStripMenuItem";
            IceCreamsReportToolStripMenuItem.Size = new Size(243, 22);
            IceCreamsReportToolStripMenuItem.Text = "Список мороженых";
            IceCreamsReportToolStripMenuItem.Click += IceCreamsReportToolStripMenuItem_Click;
            // 
            // ShopsReportToolStripMenuItem
            // 
            ShopsReportToolStripMenuItem.Name = "ShopsReportToolStripMenuItem";
            ShopsReportToolStripMenuItem.Size = new Size(243, 22);
            ShopsReportToolStripMenuItem.Text = "Таблица магазинов";
            ShopsReportToolStripMenuItem.Click += ShopsReportToolStripMenuItem_Click;
            // 
            // IceCreamAdditivesReportToolStripMenuItem
            // 
            IceCreamAdditivesReportToolStripMenuItem.Name = "IceCreamAdditivesReportToolStripMenuItem";
            IceCreamAdditivesReportToolStripMenuItem.Size = new Size(243, 22);
            IceCreamAdditivesReportToolStripMenuItem.Text = "Добавки по мороженым";
            IceCreamAdditivesReportToolStripMenuItem.Click += IceCreamAdditivesReportToolStripMenuItem_Click;
            // 
            // ShopIceCreamsReportToolStripMenuItem
            // 
            ShopIceCreamsReportToolStripMenuItem.Name = "ShopIceCreamsReportToolStripMenuItem";
            ShopIceCreamsReportToolStripMenuItem.Size = new Size(243, 22);
            ShopIceCreamsReportToolStripMenuItem.Text = "Загруженность магазинов";
            ShopIceCreamsReportToolStripMenuItem.Click += ShopIceCreamsReportToolStripMenuItem_Click;
            // 
            // OrdersReportToolStripMenuItem
            // 
            OrdersReportToolStripMenuItem.Name = "OrdersReportToolStripMenuItem";
            OrdersReportToolStripMenuItem.Size = new Size(243, 22);
            OrdersReportToolStripMenuItem.Text = "Список заказов";
            OrdersReportToolStripMenuItem.Click += OrdersReportToolStripMenuItem_Click;
            // 
            // GroupedOrdersReportToolStripMenuItem
            // 
            GroupedOrdersReportToolStripMenuItem.Name = "GroupedOrdersReportToolStripMenuItem";
            GroupedOrdersReportToolStripMenuItem.Size = new Size(243, 22);
            GroupedOrdersReportToolStripMenuItem.Text = "Список заказов за весь период";
            GroupedOrdersReportToolStripMenuItem.Click += GroupedOrdersReportToolStripMenuItem_Click;
            // 
            // StartWorkingToolStripMenuItem
            // 
            StartWorkingToolStripMenuItem.Name = "StartWorkingToolStripMenuItem";
            StartWorkingToolStripMenuItem.Size = new Size(92, 20);
            StartWorkingToolStripMenuItem.Text = "Запуск работ";
            StartWorkingToolStripMenuItem.Click += StartWorkingToolStripMenuItem_Click;
            // 
            // MessagesToolStripMenuItem
            // 
            MessagesToolStripMenuItem.Name = "MessagesToolStripMenuItem";
            MessagesToolStripMenuItem.Size = new Size(62, 20);
            MessagesToolStripMenuItem.Text = "Письма";
            MessagesToolStripMenuItem.Click += MessagesToolStripMenuItem_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(10, 23);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(987, 305);
            dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            buttonCreateOrder.Location = new Point(1003, 34);
            buttonCreateOrder.Margin = new Padding(3, 2, 3, 2);
            buttonCreateOrder.Name = "buttonCreateOrder";
            buttonCreateOrder.Size = new Size(170, 22);
            buttonCreateOrder.TabIndex = 2;
            buttonCreateOrder.Text = "Создать заказ";
            buttonCreateOrder.UseVisualStyleBackColor = true;
            buttonCreateOrder.Click += ButtonCreateOrder_Click;
            // 
            // buttonTakeOrderInWork
            // 
            buttonTakeOrderInWork.Location = new Point(1003, 60);
            buttonTakeOrderInWork.Margin = new Padding(3, 2, 3, 2);
            buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            buttonTakeOrderInWork.Size = new Size(170, 22);
            buttonTakeOrderInWork.TabIndex = 3;
            buttonTakeOrderInWork.Text = "Отдать на выполнение";
            buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            buttonTakeOrderInWork.Click += ButtonTakeOrderInWork_Click;
            // 
            // buttonOrderReady
            // 
            buttonOrderReady.Location = new Point(1003, 86);
            buttonOrderReady.Margin = new Padding(3, 2, 3, 2);
            buttonOrderReady.Name = "buttonOrderReady";
            buttonOrderReady.Size = new Size(170, 22);
            buttonOrderReady.TabIndex = 4;
            buttonOrderReady.Text = "Заказ готов";
            buttonOrderReady.UseVisualStyleBackColor = true;
            buttonOrderReady.Click += ButtonOrderReady_Click;
            // 
            // buttonIssuedOrder
            // 
            buttonIssuedOrder.Location = new Point(1003, 112);
            buttonIssuedOrder.Margin = new Padding(3, 2, 3, 2);
            buttonIssuedOrder.Name = "buttonIssuedOrder";
            buttonIssuedOrder.Size = new Size(170, 22);
            buttonIssuedOrder.TabIndex = 5;
            buttonIssuedOrder.Text = "Заказ выдан";
            buttonIssuedOrder.UseVisualStyleBackColor = true;
            buttonIssuedOrder.Click += ButtonIssuedOrder_Click;
            // 
            // buttonRef
            // 
            buttonRef.Location = new Point(1003, 138);
            buttonRef.Margin = new Padding(3, 2, 3, 2);
            buttonRef.Name = "buttonRef";
            buttonRef.Size = new Size(170, 22);
            buttonRef.TabIndex = 6;
            buttonRef.Text = "Обновить";
            buttonRef.UseVisualStyleBackColor = true;
            buttonRef.Click += ButtonRef_Click;
            // 
            // buttonAddIceCream
            // 
            buttonAddIceCream.Location = new Point(1003, 164);
            buttonAddIceCream.Margin = new Padding(3, 2, 3, 2);
            buttonAddIceCream.Name = "buttonAddIceCream";
            buttonAddIceCream.Size = new Size(170, 22);
            buttonAddIceCream.TabIndex = 7;
            buttonAddIceCream.Text = "Пополнение магазина";
            buttonAddIceCream.UseVisualStyleBackColor = true;
            buttonAddIceCream.Click += ButtonAddIceCream_Click;
            // 
            // buttonSellIceCream
            // 
            buttonSellIceCream.Location = new Point(1004, 191);
            buttonSellIceCream.Name = "buttonSellIceCream";
            buttonSellIceCream.Size = new Size(169, 23);
            buttonSellIceCream.TabIndex = 8;
            buttonSellIceCream.Text = "Продажа мороженого";
            buttonSellIceCream.UseVisualStyleBackColor = true;
            buttonSellIceCream.Click += buttonSellIceCream_Click;
            // 
            // MessagesToolStripMenuItem
            // CreateBackUpToolStripMenuItem
            // 
            CreateBackUpToolStripMenuItem.Name = "CreateBackUpToolStripMenuItem";
            CreateBackUpToolStripMenuItem.Size = new Size(97, 20);
            CreateBackUpToolStripMenuItem.Text = "Создать бекап";
            CreateBackUpToolStripMenuItem.Click += CreateBackUpToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 338);
            Controls.Add(buttonSellIceCream);
            Controls.Add(buttonAddIceCream);
            Controls.Add(buttonRef);
            Controls.Add(buttonIssuedOrder);
            Controls.Add(buttonOrderReady);
            Controls.Add(buttonTakeOrderInWork);
            Controls.Add(buttonCreateOrder);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormMain";
            Text = "Лавка с мороженым";
            Load += FormMain_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem AdditivesToolStripMenuItem;
        private ToolStripMenuItem IceCreamsToolStripMenuItem;
        private DataGridView dataGridView;
        private Button buttonCreateOrder;
        private Button buttonTakeOrderInWork;
        private Button buttonOrderReady;
        private Button buttonIssuedOrder;
        private Button buttonRef;
        private ToolStripMenuItem отчётыToolStripMenuItem;
        private ToolStripMenuItem IceCreamsReportToolStripMenuItem;
        private ToolStripMenuItem IceCreamAdditivesReportToolStripMenuItem;
        private ToolStripMenuItem OrdersReportToolStripMenuItem;
        private ToolStripMenuItem ShopsToolStripMenuItem;
        private Button buttonAddIceCream;
        private Button buttonSellIceCream;
        private ToolStripMenuItem ShopsReportToolStripMenuItem;
        private ToolStripMenuItem ShopIceCreamsReportToolStripMenuItem;
        private ToolStripMenuItem GroupedOrdersReportToolStripMenuItem;
        private ToolStripMenuItem ClientsToolStripMenuItem;
        private ToolStripMenuItem ImplementersToolStripMenuItem;
        private ToolStripMenuItem StartWorkingToolStripMenuItem;
        private ToolStripMenuItem MessagesToolStripMenuItem;
        private ToolStripMenuItem CreateBackUpToolStripMenuItem;
    }
}