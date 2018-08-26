using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HackMTY2018_Residencias_Emp
{
    public partial class Form5 : Form
    {
        private int vid;

        public Form5(int id)
        {
            InitializeComponent();
            CenterToScreen();
            MaximizeBox = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            button1.Enabled = false;
            vid = id;
            LoadInfo(id);
        }

        private void LoadInfo(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=tcp:hackmty18.database.windows.net, 1433;Initial Catalog=residencias;Persist Security Info=False;User ID = team7;Password = ZXC741asd852qwe963;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate = False;Connection Timeout=30;");
                con.Open();
                SqlDataReader read = new SqlCommand("SELECT estudiante.est_nombre, vacante.vac_titulo, estudiante.est_escuela, estudiante.est_email FROM estudiante JOIN estudiante_vacante ON (estudiante.est_id = estudiante_vacante.est_id) JOIN vacante ON (estudiante_vacante.vac_id = vacante.vac_id) WHERE vacante.vac_id = " + id, con).ExecuteReader();
                read.Read();
                textBox1.Text = read.GetString(0);
                textBox2.Text = read.GetString(1);
                textBox3.Text = read.GetString(2);
                textBox4.Text = read.GetString(3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
