﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void vissza_gomb_Click(object sender, EventArgs e)
        {

            Form regi = Form1.ActiveForm;

            this.Close();
            
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



    }
}
