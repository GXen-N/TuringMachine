using System;
using System.Collections.Generic;

namespace TuringMachine {
	class Processor {
		public enum Moving { Stop, Right, Left, Stay }

		private Moving currentMoving;

		public Moving CurrentMoving {
			get => currentMoving;
			set {
				currentMoving = value;
				if (currentMoving == Moving.Stop) {
					State = 0;
					ExecutionStopped?.Invoke(this, new EventArgs());
				}
			}
		} 

		public int PointedCell { get; set; }
		public int State { get; set; }

		public void Process(string cellValue, Dictionary<int, string> tape) {
			cellValue = cellValue.Trim();
			var strs = cellValue.Split(' ');
			tape[PointedCell] = strs[0];

			switch (strs[1]) {
				case "L":
					CurrentMoving = Moving.Left;
					break;
				case "R":
					CurrentMoving = Moving.Right;
					break;
				case "S":
					CurrentMoving = Moving.Stay;
					break;
				case "H":
					CurrentMoving = Moving.Stop;
					break;
			}
			if (CurrentMoving != Moving.Stop)
				State = int.Parse(strs[2].Substring(1));
		}

		public event EventHandler ExecutionStopped;

		public Processor(int pointedCell, int initialState) {
			PointedCell = pointedCell;
			State = initialState;
			CurrentMoving = Moving.Stay;
		}

	}
}