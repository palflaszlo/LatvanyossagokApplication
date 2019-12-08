using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatvanyossagokApplication
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost; Port=3307; Database=latvanyossagokdb; Uid=root; Pwd=;");
            conn.Open();
            varosokKilistazasa();
           // kivalaszthatoVarosokListazasa();
        }

        void varosokKilistazasa()
        {
            listBoxfelvettVarosok.Items.Clear();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id, nev, lakossag FROM varosok ORDER BY nev";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32("id");
                    var nev = reader.GetString("nev");
                    var lakossag = reader.GetInt32("lakossag");
                    var varoska = new varosok(id, nev, lakossag);
                    listBoxfelvettVarosok.Items.Add(varoska);
                    listBoxLatvanyossagok.Items.Add(varoska);
                }
            }
        }

        private void varosTorles_Click(object sender, EventArgs e)
        {
            if (listBoxfelvettVarosok.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs város kiválasztva!");
                return;
            }

            listBoxLatvanyossagok.Items.Clear();           

            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM varosok where id = @id and (SELECT varos_id FROM latvanyossagok where varos_id = varosok.id)";

            var varos = (varosok)listBoxfelvettVarosok.SelectedItem;
            cmd.Parameters.AddWithValue("@id", varos.Id);

            var cmd2 = conn.CreateCommand();
            cmd2.CommandText = "SELECT id, nev, lakossag FROM varosok ORDER BY nev";

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32("id");
                    var nev = reader.GetString("nev");
                    var lakossag = reader.GetInt32("lakossag");
                    var varoska = new varosok(id, nev, lakossag);
                    listBoxfelvettVarosok.Items.Add(varoska);
                    listBoxLatvanyossagok.Items.Add(varoska);
                }

                //if (varos.Id == )
            }


           


            cmd.ExecuteNonQuery();

            varosokKilistazasa();
        }

        private void modositas_Click(object sender, EventArgs e)
        {/*
            var renewcmd = conn.CreateCommand();
            renewcmd.CommandText = "SELECT id, nev, lakossag FROM varosok where id = @id";
            var modositandoVaros = (varosok)listBoxLatvanyossagok.SelectedItem;
            renewcmd.Parameters.AddWithValue("@id", modositandoVaros.Id);
            inputVarosNev.Show();
            inputLakossagSzam.Show();


            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id, nev, lakossag FROM varosok ORDER BY nev";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32("id");
                    var nev = reader.GetString("nev");
                    var lakossag = reader.GetInt32("lakossag");
                    var varoska = new varosok(id, nev, lakossag);
                    listBoxfelvettVarosok.Items.Add(varoska);
                    listBoxLatvanyossagok.Items.Add(varoska);
                }
            }*/
        }

        void kivalaszthatoVarosokListazasa(int varosid)
        {
            listBoxLatvanyossagok.Items.Clear();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id, nev, leiras, ar, varos_id FROM latvanyossagok LEFT JOIN varosok ON latvanyossagok.varos_id = varosok.id WHERE varos_id = @varos_id";
            cmd.Parameters.AddWithValue("@varos_id", varosid);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32("id");
                    var nev = reader.GetString("nev");
                    var leiras = reader.GetString("leiras");
                    var ar = reader.GetInt32("ar");
                    var varos_id = reader.GetInt32("varos_id");
                    var varoska = new latvanyossagok(id, nev, leiras, ar, varos_id);
                    listBoxLatvanyossagok.Items.Add(varoska);
                }
            }
        }

        private void kivalaszthatoVarosTorlese_Click(object sender, EventArgs e)
        {
            if (listBoxLatvanyossagok.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs város kiválasztva!");
                return;
            }
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM latvanyossagok where id = @id";

            var latvanyossag = (latvanyossagok)listBoxLatvanyossagok.SelectedItem;
            cmd.Parameters.AddWithValue("@id", latvanyossag.Id);
            
            cmd.ExecuteNonQuery();

           // kivalaszthatoVarosokListazasa();
        }

        private void varosKuldes_Click(object sender, EventArgs e)
        {
            if (varosNev.Equals("") || lakossagSzam.Equals(0))
            {
                MessageBox.Show("Egy mező nincs kitöltve!");
                return;
            }
           /* if(inputLakossagSzam)
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO varosok (nev, lakossag) VALUES (@nev, @lakossag)";
            cmd.Parameters.AddWithValue("@nev", inputVarosNev.Text);
            cmd.Parameters.AddWithValue("@lakossag", inputLakossagSzam.Text);
           
            int erintettSorokSzama = cmd.ExecuteNonQuery();*/
            varosokKilistazasa();
        }

        private void latvanyossagKuldes_Click(object sender, EventArgs e)
        {
            if (latvanyossagNev.Equals("") || latvanyossagLeiras.Equals("") || latvanyossagAr.Equals(0) || listBoxLatvanyossagok.SelectedIndex == -1)
            {
                MessageBox.Show("Egy mező nincs kitöltve vagy a város nincs kiválasztva!");
                return;
            }
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO latvanyossagok (nev, leiras, ar, varos_id) VALUES (@nev, @leiras, @ar, @varos_id)";
            cmd.Parameters.AddWithValue("@nev", latvanyossagNev.Text);
            cmd.Parameters.AddWithValue("@leiras", latvanyossagLeiras.Text);
            cmd.Parameters.AddWithValue("@ar", latvanyossagAr.Text);
            cmd.Parameters.AddWithValue("@varos_id", listBoxLatvanyossagok.Text);

            int erintettSorokSzama = cmd.ExecuteNonQuery();
            //kivalaszthatoVarosokListazasa();
        }

        private void new_ablak_Click(object sender, EventArgs e)
        {
            Form2 settingsForm = new Form2();
            settingsForm.Show();

            //this.Close();
        }

        private void comboBoxVarosok_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}