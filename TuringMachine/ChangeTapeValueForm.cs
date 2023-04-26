using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachine {
	public partial class ChangeTapeValueForm : Form {
		NotSelectableButton[] buttons;
		readonly char[] alfabet;
		public char SelectedSymbol { get; private set; }
		public string ButtonIndex { get; private set; }
		private void InitializeButtons() {
			buttons = new NotSelectableButton[alfabet.Length];
			for (int i = 0; i < buttons.Length; i++) {
				buttons[i] = new NotSelectableButton {
					Size = new Size(30, 30),
					UseVisualStyleBackColor = true,
					FlatStyle = FlatStyle.Flat,
					BackColor = Color.White,
					Text = alfabet[i].ToString(),
					Location = new Point(i % 6 * 29, i / 6 * 29)
				};
				buttons[i].Click += Button_Click;
				Controls.Add(buttons[i]);
			}
			Width = 6 * 35;
			Height = 68 + buttons.Length * 30 / 6;
		}

		private void UnregisterEvents() {
			for (int i = 0; i < buttons.Length; i++)
				buttons[i].Click -= Button_Click;
		}

		private void Button_Click(object sender, EventArgs e) {
			SelectedSymbol = ((Button)sender).Text[0];
			UnregisterEvents();
			Close();
		}

		public ChangeTapeValueForm(List<char> alfabet, string selectedSymbol, string buttonIndex) {
			InitializeComponent();
			this.alfabet = alfabet.ToArray();
			InitializeButtons();
			try {
				SelectedSymbol = selectedSymbol[0];
			}
			catch (IndexOutOfRangeException) {
				SelectedSymbol = '_';
			}
			ButtonIndex = buttonIndex;
		}
	}
}
