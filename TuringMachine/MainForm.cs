using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace TuringMachine {
	public partial class MainForm : Form {
		private Dictionary<int, string> dictionary_tape;
		private NotSelectableButton button_left, button_right;
		private readonly List<char> alfabet;
		private const int TapeButtonsCount = 20;
		private TapeButton[] tape_buttons;
		private ChangeTapeValueForm changeTapeValueForm;
		private readonly Processor processor;
		private readonly Color greenForHighliting = Color.FromArgb(181, 230, 29);

		private void ToolStripsEnabled(bool start, bool pause, bool stop, bool byStep) {
			toolStripMenuItem_start.Enabled = start;
			toolStripMenuItem_pause.Enabled = pause;
			toolStripMenuItem_stop.Enabled = stop;
			toolStripMenuItem_byStep.Enabled = byStep;
		}

		private void InitializeTape() {
			tape_buttons = new TapeButton[TapeButtonsCount];
			for (int i = 0; i < tape_buttons.Length; i++) {
				tape_buttons[i] = new TapeButton();
				tape_buttons[i].Button.Location = new Point(i * 29, panel1.Size.Height - 32);
				tape_buttons[i].MouseDown += TapeButton_Click;
				tape_buttons[i].Label.Location = new Point(i * 29 + 8, 3);
				tape_buttons[i].Label.Text = (i - 9).ToString();
				panel1.Controls.Add(tape_buttons[i].Button);
				panel1.Controls.Add(tape_buttons[i].Label);
			}
			dictionary_tape = new Dictionary<int, string>();
			for (int i = -100; i <= 100; i++) dictionary_tape.Add(i, "");
			foreach (var tape_button in tape_buttons)
				if (tape_button.Label.Text == processor.PointedCell.ToString()) {
					tape_button.Button.BackColor = greenForHighliting;
					break;
				}
		}

		private void TapeButton_Click(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				changeTapeValueForm = new ChangeTapeValueForm(alfabet,
					((TapeButton)sender).Button.Text, ((TapeButton)sender).Label.Text);
				changeTapeValueForm.FormClosed += ChangeTapeValueForm_FormClosed;
				changeTapeValueForm.Show();
			}
		}

		private void ChangeTapeValueForm_FormClosed(object sender, FormClosedEventArgs e) {
			int idx = 0;
			for (int i = 0; i < tape_buttons.Length; i++)
				if (tape_buttons[i].Label.Text == changeTapeValueForm.ButtonIndex) {
					idx = i;
					break;
				}

			tape_buttons[idx].Button.Text = changeTapeValueForm.SelectedSymbol != '_' ?
				changeTapeValueForm.SelectedSymbol.ToString() : "";

			dictionary_tape[int.Parse(tape_buttons[idx].Label.Text)] = tape_buttons[idx].Button.Text;
			changeTapeValueForm.FormClosed -= ChangeTapeValueForm_FormClosed;
		}

		private void InitializeButtons() {
			button_left = new NotSelectableButton {
				Location = new Point(65, 57),
				Size = new Size(29, 57),
				Text = "<",
				UseVisualStyleBackColor = true
			};
			button_right = new NotSelectableButton {
				Location = new Point(697, 57),
				Size = new Size(29, 57),
				Text = ">",
				UseVisualStyleBackColor = true
			};
			button_left.Click += Button_left_Click;
			button_right.Click += Button_right_Click;
			Controls.Add(button_left);
			Controls.Add(button_right);
		}

		private void Button_right_Click(object sender, EventArgs e) => MoveTapeRight();
		private void Button_left_Click(object sender, EventArgs e) => MoveTapeLeft();

		private void MoveTapeRight() {
			foreach (var tape_button in tape_buttons) {
				int numberOfCell = int.Parse(tape_button.Label.Text) + 1;
				tape_button.Label.Text = numberOfCell.ToString();
				tape_button.Button.Text = dictionary_tape[numberOfCell];
			}
			RefreshTapeButtons();
			if (int.Parse(tape_buttons[TapeButtonsCount - 1].Label.Text) == dictionary_tape.Keys.Max())
				button_right.Enabled = false;
			button_left.Enabled = true;
			processor.PointedCell++;
		}

		private void MoveTapeLeft() {
			foreach (var tape_button in tape_buttons)
				tape_button.Label.Text = (int.Parse(tape_button.Label.Text) - 1).ToString();
			RefreshTapeButtons();
			if (int.Parse(tape_buttons[0].Label.Text) == dictionary_tape.Keys.Min())
				button_left.Enabled = false;
			button_right.Enabled = true;
			processor.PointedCell--;
		}

		public MainForm() {
			processor = new Processor(0, 0);
			processor.ExecutionStopped += Processor_ExecutionStopped;
			InitializeComponent();
			InitializeTape();
			InitializeButtons();
			alfabet = new List<char> { '_' };
			dataGridView.RowCount = 1;
			dataGridView.Rows[0].HeaderCell.Value = "_";
			dataGridView.CellValueChanged += DataGridView_CellValueChanged;
			timerForExecution.Tick += Timer_Tick;
			ToolStripsEnabled(start: true, pause: false, stop: false, byStep: true);
		}

		private void Processor_ExecutionStopped(object sender, EventArgs e) =>
				ToolStripsEnabled(start: true, pause: false, stop: false, byStep: true);

		private void HighlightCell(int columnIndex = -1, int rowIndex = -1) {
			foreach (DataGridViewRow row in dataGridView.Rows) {
				foreach (DataGridViewCell cell in row.Cells) {
					cell.Selected = false;
					cell.Style.BackColor = Color.White;
				}
			}
			if (!(columnIndex == -1 || rowIndex == -1))
				dataGridView[columnIndex, rowIndex].Style.BackColor = greenForHighliting;
		}



		private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex >= 0 && e.RowIndex >= 0) {
				var cellValue = dataGridView[e.ColumnIndex, e.RowIndex].Value;
				HighlightCell();
				if (cellValue != null) {
					var strs = cellValue.ToString().Trim().Split(' ');
					if (strs.Length == 2) {
						if (strs[1].ToUpper() != "H"
						|| strs[0].Length != 1
						|| !alfabet.Contains(strs[0][0])) {
							MessageBox.Show("Некорректный ввод");
							dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
							return;
						} else if (strs[1].ToLower() == strs[1]) {
							strs[1] = strs[1].ToUpper();
							dataGridView[e.ColumnIndex, e.RowIndex].Value = string.Join(" ", strs);
						}
					} else if (strs.Length == 3) {
						var needToJoin = strs[2][0].ToString().ToLower() != "q" && int.TryParse(strs[2], out int _);
						if (needToJoin) strs[2] = "Q" + strs[2];
						if (!(strs[1].ToUpper() == "L" || strs[1].ToUpper() == "R" || strs[1].ToUpper() == "S") || strs[0].Length != 1
							|| !alfabet.Contains(strs[0][0]) || strs[2].Length < 2
							|| !int.TryParse(strs[2].Substring(1), out int newState) || strs[2][0].ToString().ToLower() != "q" ||
							newState <= 0 || newState > dataGridView.ColumnCount) {
							MessageBox.Show("Некорректный ввод");
							dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
							return;
						} else {
							if (strs[1] == strs[1].ToLower()) {
								strs[1] = strs[1].ToUpper();
								needToJoin = true;
							}
							if (strs[2] == strs[2].ToLower()) {
								strs[2] = strs[2].ToUpper();
								needToJoin = true;
							}
						}
						if (needToJoin)
							dataGridView[e.ColumnIndex, e.RowIndex].Value = string.Join(" ", strs);
					} else {
						MessageBox.Show("Некорректный ввод");
						dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
						return;
					}
				}
			}
		}

		private void TextBox_alfabet_TextChanged(object sender, EventArgs e) {
			alfabet.Clear();
			alfabet.Add('_');
			var rowHeaders = new List<char>();
			var rowsToRemove = new List<DataGridViewRow>();
			foreach (var symbol in ((TextBox)sender).Text)
				if (!alfabet.Contains(symbol) && symbol != ' ') alfabet.Add(symbol);

			foreach (DataGridViewRow row in dataGridView.Rows)
				if (!alfabet.Contains(row.HeaderCell.Value.ToString()[0]))
					rowsToRemove.Add(row);
				else rowHeaders.Add(row.HeaderCell.Value.ToString()[0]);

			foreach (var row in rowsToRemove)
				dataGridView.Rows.Remove(row);

			if (alfabet.Count != rowHeaders.Count)
				foreach (var symbol in alfabet)
					if (!rowHeaders.Contains(symbol)) {
						dataGridView.RowCount++;
						dataGridView.Rows[dataGridView.RowCount - 1].HeaderCell.Value = symbol.ToString();
					}
		}

		private void Button_addState_Click(object sender, EventArgs e) {
			var newColumn = new DataGridViewTextBoxColumn {
				HeaderText = "Q" +
					(int.Parse(dataGridView.Columns[dataGridView.ColumnCount - 1].HeaderText.Substring(1)) + 1),
				Resizable = DataGridViewTriState.False,
				SortMode = DataGridViewColumnSortMode.NotSortable,
				Width = 60
			};
			newColumn.Name = newColumn.HeaderText;
			dataGridView.Columns.Add(newColumn);
		}

		private void RefreshTapeButtons() {
			foreach (var button in tape_buttons) {
				var newText = dictionary_tape[int.Parse(button.Label.Text)];
				button.Button.Text = newText == "_" ? "" : dictionary_tape[int.Parse(button.Label.Text)];
			}
		}

		private void MakeStep() {
			int rowIdx = 0;
			var symbolInPointedCell = dictionary_tape[processor.PointedCell];
			if (symbolInPointedCell == "") symbolInPointedCell = "_";
			if (!alfabet.Contains(symbolInPointedCell[0])) {
				timerForExecution.Stop();
				processor.CurrentMoving = Processor.Moving.Stop;
				MessageBox.Show("Этого символа нет в алфавите");
				return;
			}
			for (int i = 0; i < dataGridView.RowCount; i++)
				if (dataGridView.Rows[i].HeaderCell.Value.ToString() == symbolInPointedCell) {
					rowIdx = i;
					break;
				}
			HighlightCell(processor.State - 1, rowIdx);
			var dgvValue = dataGridView[processor.State - 1, rowIdx].Value;
			if (dgvValue is null) {
				processor.CurrentMoving = Processor.Moving.Stop;
				timerForExecution.Stop();
				MessageBox.Show("Нет команды");
			} else {
				processor.Process(dgvValue.ToString(), dictionary_tape);
				RefreshTapeButtons();
				switch (processor.CurrentMoving) {
					case Processor.Moving.Stop:
						HighlightCell();
						break;
					case Processor.Moving.Right:
						var maxKey = dictionary_tape.Keys.Max();
						if (tape_buttons[tape_buttons.Length - 1].Label.Text == maxKey.ToString())
							dictionary_tape.Add(maxKey + 1, "");
						MoveTapeRight();
						break;
					case Processor.Moving.Left:
						var minKey = dictionary_tape.Keys.Min();
						if (tape_buttons[tape_buttons.Length - 1].Label.Text == minKey.ToString())
							dictionary_tape.Add(minKey - 1, "");
						MoveTapeLeft();
						break;
					case Processor.Moving.Stay:
						break;
				}
				RefreshTapeButtons();
			}
		}

		private void Start_Click(object sender, EventArgs e) {
			processor.State = 1;
			processor.CurrentMoving = Processor.Moving.Stay;
			timerForExecution.Interval = 600;
			ToolStripsEnabled(start: false, pause: true, stop: true, byStep: false);
			timerForExecution.Start();
		}

		private void Timer_Tick(object sender, EventArgs e) {
			if (processor.CurrentMoving != Processor.Moving.Stop) {
				ToolStripsEnabled(start: false, pause: true, stop: true, byStep: false);
				MakeStep();
			} else {
				ToolStripsEnabled(start: true, pause: false, stop: false, byStep: true);
				timerForExecution.Stop();
			}
		}

		private void Pause_Click(object sender, EventArgs e) {
			if (toolStripMenuItem_pause.Text.Trim() == "Пауза") {
				timerForExecution.Stop();
				toolStripMenuItem_pause.Text = "Продолжить";
				ToolStripsEnabled(start: true, pause: true, stop: false, byStep: true);
			} else {
				timerForExecution.Start();
				toolStripMenuItem_pause.Text = "Пауза";
				ToolStripsEnabled(start: false, pause: true, stop: true, byStep: false);
			}
		}

		private void ByStep_Click(object sender, EventArgs e) {
			if (processor.State == 0)
				processor.State = 1;

			ToolStripsEnabled(start: true, pause: false, stop: false, byStep: true);
			toolStripMenuItem_pause.Text = "Пауза";
			MakeStep();
		}

		private void Stop_Click(object sender, EventArgs e) {
			timerForExecution.Stop();

			ToolStripsEnabled(start: true, pause: false, stop: false, byStep: true);
			HighlightCell();
			toolStripMenuItem_pause.Text = "Пауза";
		}

		private void SaveTape_Click(object sender, EventArgs e) {
			var saveFileDialog = new SaveFileDialog {
				AddExtension = true,
				Filter = "Text files (*.txt)|*.txt"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				StreamWriter sw;
				sw = new StreamWriter(saveFileDialog.FileName);
				try {
					foreach (var elem in dictionary_tape) {
						if (elem.Value != "" && elem.Value != "_")
							sw.Write(elem.Key.ToString() + " " + elem.Value + Environment.NewLine);
					}
					MessageBox.Show("Данные сохранены");
				} catch (Exception ex) {
					MessageBox.Show(ex.Message);
				} finally {
					sw.Close();
				}
			}
		}

		private void SaveProgram_Click(object sender, EventArgs e) {
			var saveFileDialog = new SaveFileDialog {
				AddExtension = true,
				Filter = "Turing Machine program files (*.tmpr)|*.tmpr"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				StreamWriter sw;
				sw = new StreamWriter(saveFileDialog.FileName);
				try {
					sw.WriteLine(dataGridView.ColumnCount.ToString() + " " + dataGridView.RowCount.ToString());
					foreach (DataGridViewRow row in dataGridView.Rows) {
						sw.WriteLine(row.HeaderCell.Value.ToString());
						foreach (DataGridViewCell cell in row.Cells)
							if (cell.Value != null)
								sw.WriteLine(cell.ColumnIndex.ToString() + " " + cell.Value.ToString());
					}
					MessageBox.Show("Данные сохранены");
				} catch (Exception ex) {
					MessageBox.Show(ex.Message);
				} finally {
					sw.Close();
				}
			}
		}

		private void LoadTape_Click(object sender, EventArgs e) {
			var openFileDialog = new OpenFileDialog {
				Filter = "Text files (*.txt)|*.txt",
				InitialDirectory = "c:\\"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				var sr = new StreamReader(openFileDialog.FileName);
				var lines = new List<string>();
				var pairs = new Dictionary<string, string>();
				try {
					while (!sr.EndOfStream) {
						lines.Add(sr.ReadLine());
						var pair = lines[lines.Count - 1].Split(' ');
						if (pair.Length != 2 || !int.TryParse(pair[0], out int _) || pair[1].Length != 1) {
							MessageBox.Show("Неверный формат файла");
							return;
						}
						pairs.Add(pair[0], pair[1]);
					}

				} catch (ArgumentException) {
					MessageBox.Show("Неверный формат файла");
					return;
				} catch {
					MessageBox.Show("Не удалось прочитать файл");
					return;
				} finally {
					sr.Close();
				}

				dictionary_tape.Clear();
				for (int i = -100; i <= 100; i++) dictionary_tape.Add(i, "");
				foreach (var pair in pairs) {
					var key = int.Parse(pair.Key);
					if (!dictionary_tape.ContainsKey(key)) {
						var max = dictionary_tape.Keys.Max();
						var min = dictionary_tape.Keys.Min();
						if (key < min)
							for (int j = key; j < min; j++) dictionary_tape.Add(j, "");
						else if (key > max)
							for (int j = max + 1; j <= key; j++) dictionary_tape.Add(j, "");
					}
					dictionary_tape[key] = pair.Value;

				}
				RefreshTapeButtons();
			}
		}

		private void LoadProgram_Click(object sender, EventArgs e) {
			dataGridView.CellValueChanged -= DataGridView_CellValueChanged;
			textBox_alfabet.TextChanged -= TextBox_alfabet_TextChanged;

			var openFileDialog = new OpenFileDialog {
				Filter = "Turing Machine program files (*.tmpr)|*.tmpr",
				InitialDirectory = "c:\\"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				var sr = new StreamReader(openFileDialog.FileName);
				var lines = new List<string>();
				int rows = 0, cols = 0;
				textBox_alfabet.Text = "";

				try {
					while (!sr.EndOfStream) {
						lines.Add(sr.ReadLine());
						if (lines.Count == 1) {
							var data = lines[0].Split(' ');
							cols = int.Parse(data[0]);
							rows = int.Parse(data[1]);
							dataGridView.Rows.Clear();
							dataGridView.RowCount = rows;
							dataGridView.ColumnCount = cols;
							for (int i = 0; i < dataGridView.ColumnCount; i++) {
								dataGridView.Columns[i].HeaderText = "Q" + (i + 1).ToString(); alfabet.Clear();
								dataGridView.Columns[i].Resizable = DataGridViewTriState.False;
								dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
								dataGridView.Columns[i].Width = 60;
							}
						} else if (lines[lines.Count - 1].Length > 0) {
							var data = lines[lines.Count - 1].Split(' ');

							if (data.Length == 1) {
								alfabet.Add(data[0][0]);
								dataGridView.Rows[alfabet.Count - 1].HeaderCell.Value = data[0][0].ToString();
								if (data[0][0] != '_') {
									textBox_alfabet.Text += data[0];
								}
							} else {
								var dataToJoin = data.ToList();
								dataToJoin.RemoveAt(0);
								dataGridView[int.Parse(data[0]), alfabet.Count - 1].Value = string.Join(" ", dataToJoin);
							}
						}
					}

				} catch {
					MessageBox.Show("Не удалось прочитать файл");
					return;
				} finally {
					sr.Close();
					dataGridView.CellValueChanged += DataGridView_CellValueChanged;
					textBox_alfabet.TextChanged += TextBox_alfabet_TextChanged;
				}
			}
		}

		private void Button_removeState_Click(object sender, EventArgs e) {
			var columnHeaders = new List<string>();
			foreach (DataGridViewCell cell in dataGridView.SelectedCells) {
				var str = dataGridView.Columns[cell.ColumnIndex].HeaderText;
				if (!columnHeaders.Contains(str)) columnHeaders.Add(str);
			}
			foreach (var header in columnHeaders) dataGridView.Columns.Remove(header);

			for (int i = 0; i < dataGridView.ColumnCount; i++)
				dataGridView.Columns[i].Name = dataGridView.Columns[i].HeaderText = "Q" + (i + 1).ToString();
		}
	}
}