
namespace ProgectName
{
    partial class SectionsEditor
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
            this.dGVItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVSectionItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.up = new System.Windows.Forms.DataGridViewButtonColumn();
            this.down = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dGVSections = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAddSection = new System.Windows.Forms.Button();
            this.bntAddItem = new System.Windows.Forms.Button();
            this.bntDeleteItem = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSectionItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSections)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVItems
            // 
            this.dGVItems.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dGVItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dGVItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dGVItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewButtonColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dGVItems.Location = new System.Drawing.Point(523, 68);
            this.dGVItems.Name = "dGVItems";
            this.dGVItems.RowHeadersVisible = false;
            this.dGVItems.RowTemplate.Height = 25;
            this.dGVItems.Size = new System.Drawing.Size(265, 326);
            this.dGVItems.StandardTab = true;
            this.dGVItems.TabIndex = 9;
            this.dGVItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVItems_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Добавить к разделу";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "Добавить";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dGVSectionItems
            // 
            this.dGVSectionItems.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dGVSectionItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVSectionItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dGVSectionItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dGVSectionItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVSectionItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewButtonColumn2,
            this.up,
            this.down});
            this.dGVSectionItems.Location = new System.Drawing.Point(237, 68);
            this.dGVSectionItems.Name = "dGVSectionItems";
            this.dGVSectionItems.RowHeadersVisible = false;
            this.dGVSectionItems.RowTemplate.Height = 25;
            this.dGVSectionItems.Size = new System.Drawing.Size(280, 326);
            this.dGVSectionItems.StandardTab = true;
            this.dGVSectionItems.TabIndex = 10;
            this.dGVSectionItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVSectionItems_CellContentClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Убрать из раздела";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "Удалить";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 70;
            // 
            // up
            // 
            this.up.HeaderText = "Вверх";
            this.up.Name = "up";
            this.up.Width = 45;
            // 
            // down
            // 
            this.down.HeaderText = "Вниз";
            this.down.Name = "down";
            this.down.Width = 45;
            // 
            // dGVSections
            // 
            this.dGVSections.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dGVSections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVSections.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dGVSections.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dGVSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVSections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewButtonColumn3});
            this.dGVSections.Location = new System.Drawing.Point(41, 68);
            this.dGVSections.Name = "dGVSections";
            this.dGVSections.RowHeadersVisible = false;
            this.dGVSections.RowTemplate.Height = 25;
            this.dGVSections.Size = new System.Drawing.Size(190, 326);
            this.dGVSections.StandardTab = true;
            this.dGVSections.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Раздел";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.HeaderText = "Удалить";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.Text = "Удалить";
            this.dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn3.Width = 70;
            // 
            // btnAddSection
            // 
            this.btnAddSection.Location = new System.Drawing.Point(111, 400);
            this.btnAddSection.Name = "btnAddSection";
            this.btnAddSection.Size = new System.Drawing.Size(120, 23);
            this.btnAddSection.TabIndex = 12;
            this.btnAddSection.Text = "Добавить раздел";
            this.btnAddSection.UseVisualStyleBackColor = true;
            // 
            // bntAddItem
            // 
            this.bntAddItem.Location = new System.Drawing.Point(668, 400);
            this.bntAddItem.Name = "bntAddItem";
            this.bntAddItem.Size = new System.Drawing.Size(120, 23);
            this.bntAddItem.TabIndex = 13;
            this.bntAddItem.Text = "Добавить товар";
            this.bntAddItem.UseVisualStyleBackColor = true;
            // 
            // bntDeleteItem
            // 
            this.bntDeleteItem.Location = new System.Drawing.Point(523, 400);
            this.bntDeleteItem.Name = "bntDeleteItem";
            this.bntDeleteItem.Size = new System.Drawing.Size(120, 23);
            this.bntDeleteItem.TabIndex = 14;
            this.bntDeleteItem.Text = "Удалить товар";
            this.bntDeleteItem.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(237, 404);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(196, 19);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Редактировать главный раздел";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // SectionsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.bntDeleteItem);
            this.Controls.Add(this.bntAddItem);
            this.Controls.Add(this.btnAddSection);
            this.Controls.Add(this.dGVSections);
            this.Controls.Add(this.dGVSectionItems);
            this.Controls.Add(this.dGVItems);
            this.Name = "SectionsEditor";
            this.Text = "SectionsEditor";
            ((System.ComponentModel.ISupportInitialize)(this.dGVItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSectionItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSections)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVItems;
        private System.Windows.Forms.DataGridView dGVSectionItems;
        private System.Windows.Forms.DataGridView dGVSections;
        private System.Windows.Forms.Button btnAddSection;
        private System.Windows.Forms.Button bntAddItem;
        private System.Windows.Forms.Button bntDeleteItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn up;
        private System.Windows.Forms.DataGridViewButtonColumn down;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
    }
}