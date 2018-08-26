using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HackMTY2018_Residencias_Emp
{
    public partial class Form2 : Form
    {
        private string[] datavec;
        private Form5 _f5;
        
        public Form2(string [] datavec)
        {
            InitializeComponent();
            CenterToScreen();
            this.datavec = datavec;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string[] head = { "ID de estudiante", "ID de vacante", "Nombre", "Universidad", "Carrera" };
            for (int i = 0; i < head.Length; i++)
                dataGridView1.Columns.Add(head[i], head[i]);
            LoadDB("");
            button1.Enabled = dataGridView1.Rows.Count > 0;
        }

        private void OpenInfo()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (_f5 == null || _f5.IsDisposed)
                {
                    _f5 = new Form5(Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value));
                    _f5.Show();
                }
            }
        }

        private void LoadDB(string str)
        {
            try
            {
                dataGridView1.Rows.Clear();
                SqlConnection con = new SqlConnection("Server=tcp:hackmty18.database.windows.net, 1433;Initial Catalog=residencias;Persist Security Info=False;User ID = team7;Password = ZXC741asd852qwe963;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate = False;Connection Timeout=30;");
                con.Open();
                string send = "SELECT estudiante.est_id, vacante.vac_id, estudiante.est_nombre, estudiante.est_escuela, estudiante.est_carrera FROM estudiante JOIN estudiante_vacante ON (estudiante.est_id = estudiante_vacante.est_id) JOIN vacante ON (estudiante_vacante.vac_id = vacante.vac_id) JOIN empresa ON (empresa.emp_id = vacante.emp_id) WHERE ";
                send += radioButton2.Checked ? ("estudiante.est_carrera LIKE '" + str + "%'") : ("estudiante.est_escuela '" + str + "%'");
                send += string.Format(" AND vacante.emp_id = '{0}'", datavec[0]);
                SqlDataReader read = new SqlCommand(send, con).ExecuteReader();
                while (read.Read())
                {
                    string[] vec = new string[read.FieldCount];
                    for (int i = 0; i < read.FieldCount; i++)
                        vec[i] = read.GetValue(i).ToString();
                    dataGridView1.Rows.Add(vec);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 41;
            this.dataGridView1.Height = this.Height - 119;
            this.button1.Left = this.Width - 128;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenInfo();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenInfo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadDB(textBox1.Text);
        }
    }
}
