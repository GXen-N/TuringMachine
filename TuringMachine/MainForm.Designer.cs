
namespace TuringMachine {
	partial class MainForm {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.textBox_alfabet = new System.Windows.Forms.TextBox();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.Q1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Q2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Q3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Q4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.button_addState = new System.Windows.Forms.Button();
			this.button_removeState = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem_file = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_save = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_saveTape = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_saveProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_load = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_loadTape = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_loadProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_start = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_byStep = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_stop = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_pause = new System.Windows.Forms.ToolStripMenuItem();
			this.timerForExecution = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox_alfabet
			// 
			this.textBox_alfabet.Location = new System.Drawing.Point(12, 173);
			this.textBox_alfabet.Name = "textBox_alfabet";
			this.textBox_alfabet.Size = new System.Drawing.Size(254, 20);
			this.textBox_alfabet.TabIndex = 4;
			this.textBox_alfabet.TextChanged += new System.EventHandler(this.TextBox_alfabet_TextChanged);
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.AllowUserToResizeColumns = false;
			this.dataGridView.AllowUserToResizeRows = false;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Q1,
            this.Q2,
            this.Q3,
            this.Q4});
			this.dataGridView.Location = new System.Drawing.Point(12, 211);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersWidth = 62;
			this.dataGridView.Size = new System.Drawing.Size(756, 217);
			this.dataGridView.TabIndex = 5;
			// 
			// Q1
			// 
			this.Q1.HeaderText = "Q1";
			this.Q1.MinimumWidth = 8;
			this.Q1.Name = "Q1";
			this.Q1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Q1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Q1.Width = 60;
			// 
			// Q2
			// 
			this.Q2.HeaderText = "Q2";
			this.Q2.MinimumWidth = 8;
			this.Q2.Name = "Q2";
			this.Q2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Q2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Q2.Width = 60;
			// 
			// Q3
			// 
			this.Q3.HeaderText = "Q3";
			this.Q3.MinimumWidth = 8;
			this.Q3.Name = "Q3";
			this.Q3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Q3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Q3.Width = 60;
			// 
			// Q4
			// 
			this.Q4.HeaderText = "Q4";
			this.Q4.MinimumWidth = 8;
			this.Q4.Name = "Q4";
			this.Q4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Q4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Q4.Width = 60;
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(105, 57);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(591, 57);
			this.panel1.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 157);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Введите алфавит:";
			// 
			// button_addState
			// 
			this.button_addState.Location = new System.Drawing.Point(272, 158);
			this.button_addState.Name = "button_addState";
			this.button_addState.Size = new System.Drawing.Size(75, 48);
			this.button_addState.TabIndex = 8;
			this.button_addState.Text = "Добавить состояние";
			this.button_addState.UseVisualStyleBackColor = true;
			this.button_addState.Click += new System.EventHandler(this.Button_addState_Click);
			// 
			// button_removeState
			// 
			this.button_removeState.Location = new System.Drawing.Point(353, 158);
			this.button_removeState.Name = "button_removeState";
			this.button_removeState.Size = new System.Drawing.Size(75, 48);
			this.button_removeState.TabIndex = 9;
			this.button_removeState.Text = "Удалить состояние";
			this.button_removeState.UseVisualStyleBackColor = true;
			this.button_removeState.Click += new System.EventHandler(this.Button_removeState_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_file,
            this.toolStripMenuItem_start,
            this.toolStripMenuItem_byStep,
            this.toolStripMenuItem_stop,
            this.toolStripMenuItem_pause});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 10;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem_file
			// 
			this.toolStripMenuItem_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_save,
            this.toolStripMenuItem_load});
			this.toolStripMenuItem_file.Name = "toolStripMenuItem_file";
			this.toolStripMenuItem_file.Size = new System.Drawing.Size(48, 22);
			this.toolStripMenuItem_file.Text = "Файл";
			// 
			// toolStripMenuItem_save
			// 
			this.toolStripMenuItem_save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_saveTape,
            this.toolStripMenuItem_saveProgram});
			this.toolStripMenuItem_save.Name = "toolStripMenuItem_save";
			this.toolStripMenuItem_save.Size = new System.Drawing.Size(180, 22);
			this.toolStripMenuItem_save.Text = "Сохранить...";
			// 
			// toolStripMenuItem_saveTape
			// 
			this.toolStripMenuItem_saveTape.Name = "toolStripMenuItem_saveTape";
			this.toolStripMenuItem_saveTape.Size = new System.Drawing.Size(137, 22);
			this.toolStripMenuItem_saveTape.Text = "ленту";
			this.toolStripMenuItem_saveTape.Click += new System.EventHandler(this.SaveTape_Click);
			// 
			// toolStripMenuItem_saveProgram
			// 
			this.toolStripMenuItem_saveProgram.Name = "toolStripMenuItem_saveProgram";
			this.toolStripMenuItem_saveProgram.Size = new System.Drawing.Size(137, 22);
			this.toolStripMenuItem_saveProgram.Text = "программу";
			this.toolStripMenuItem_saveProgram.Click += new System.EventHandler(this.SaveProgram_Click);
			// 
			// toolStripMenuItem_load
			// 
			this.toolStripMenuItem_load.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_loadTape,
            this.toolStripMenuItem_loadProgram});
			this.toolStripMenuItem_load.Name = "toolStripMenuItem_load";
			this.toolStripMenuItem_load.Size = new System.Drawing.Size(180, 22);
			this.toolStripMenuItem_load.Text = "Загрузить...";
			// 
			// toolStripMenuItem_loadTape
			// 
			this.toolStripMenuItem_loadTape.Name = "toolStripMenuItem_loadTape";
			this.toolStripMenuItem_loadTape.Size = new System.Drawing.Size(180, 22);
			this.toolStripMenuItem_loadTape.Text = "ленту";
			this.toolStripMenuItem_loadTape.Click += new System.EventHandler(this.LoadTape_Click);
			// 
			// toolStripMenuItem_loadProgram
			// 
			this.toolStripMenuItem_loadProgram.Name = "toolStripMenuItem_loadProgram";
			this.toolStripMenuItem_loadProgram.Size = new System.Drawing.Size(180, 22);
			this.toolStripMenuItem_loadProgram.Text = "программу";
			this.toolStripMenuItem_loadProgram.Click += new System.EventHandler(this.LoadProgram_Click);
			// 
			// toolStripMenuItem_start
			// 
			this.toolStripMenuItem_start.Name = "toolStripMenuItem_start";
			this.toolStripMenuItem_start.Size = new System.Drawing.Size(57, 22);
			this.toolStripMenuItem_start.Text = "Запуск";
			this.toolStripMenuItem_start.Click += new System.EventHandler(this.Start_Click);
			// 
			// toolStripMenuItem_byStep
			// 
			this.toolStripMenuItem_byStep.Name = "toolStripMenuItem_byStep";
			this.toolStripMenuItem_byStep.Size = new System.Drawing.Size(75, 22);
			this.toolStripMenuItem_byStep.Text = "По шагам";
			this.toolStripMenuItem_byStep.Click += new System.EventHandler(this.ByStep_Click);
			// 
			// toolStripMenuItem_stop
			// 
			this.toolStripMenuItem_stop.Name = "toolStripMenuItem_stop";
			this.toolStripMenuItem_stop.Size = new System.Drawing.Size(46, 22);
			this.toolStripMenuItem_stop.Text = "Стоп";
			this.toolStripMenuItem_stop.Click += new System.EventHandler(this.Stop_Click);
			// 
			// toolStripMenuItem_pause
			// 
			this.toolStripMenuItem_pause.Name = "toolStripMenuItem_pause";
			this.toolStripMenuItem_pause.Size = new System.Drawing.Size(51, 22);
			this.toolStripMenuItem_pause.Text = "Пауза";
			this.toolStripMenuItem_pause.Click += new System.EventHandler(this.Pause_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button_removeState);
			this.Controls.Add(this.button_addState);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.textBox_alfabet);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Машина Тьринга";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBox_alfabet;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_addState;
		private System.Windows.Forms.Button button_removeState;
		private System.Windows.Forms.DataGridViewTextBoxColumn Q1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Q2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Q3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Q4;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Timer timerForExecution; 
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_pause;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_byStep;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_stop;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_start;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_file;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_save;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_saveTape;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_saveProgram;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_load;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_loadTape;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_loadProgram;
	}
}