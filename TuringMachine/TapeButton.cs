using System;
using System.Windows.Forms;
using System.Drawing;

namespace TuringMachine {
	public class TapeButton {
		public NotSelectableButton Button { get; set; }
		public Label Label { get; set; }

		public delegate void TapeButtonClickHandler(object sender, MouseEventArgs e);
		public event TapeButtonClickHandler MouseDown;

		public TapeButton() {
			Button = new NotSelectableButton {
				Size = new Size(30, 30),
				UseVisualStyleBackColor = true,
				FlatStyle = FlatStyle.Flat,
				BackColor = Color.White,
				Text = ""
			};
			Button.MouseDown += Button_Click;
			Label = new Label { AutoSize = true };
		}

		private void Button_Click(object sender, MouseEventArgs e) {
			MouseDown(this, e);
		}
	}
}
