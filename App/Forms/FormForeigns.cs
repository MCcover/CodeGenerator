using Domain.Model.Table;

namespace CodeGenerator.Forms {
	public partial class FormForeigns : Form {

		public List<Foreign> Foreings { get; private set; }

		private FormForeigns() => InitializeComponent();


		public FormForeigns(List<Foreign> foreings) : this() {
			Foreings = foreings;
		}

		private void FormForeigns_Load(object sender, EventArgs e) {
			foreach (var foreign in Foreings) {
				var index = dgvForeigns.Rows.Add(foreign.Table, foreign.Column, foreign.Table);
				dgvForeigns.Rows[index].Tag = foreign;
			}
		}

		private void BtnAccept_Click(object sender, EventArgs e) {
			var data = dgvForeigns.Rows.OfType<DataGridViewRow>().Select(x => x.Tag as Foreign).ToList();

			var i = 0;
			foreach (DataGridViewRow row in dgvForeigns.Rows) {
				if (row.Tag == null || row.Tag is not Foreign) {
					continue;
				}

				var foreign = row.Tag as Foreign;

				foreign.ClassName = row.Cells[ColClassName.Index].Value.ToString();

				Foreings[i] = foreign;

				i++;
			}

			DialogResult = DialogResult.OK;
		}
	}
}
