using System.Windows.Forms;

namespace TuringMachine {
	public class NotSelectableButton : Button {
		public NotSelectableButton() => SetStyle(ControlStyles.Selectable, false);
	}
}
