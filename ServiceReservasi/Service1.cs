using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string constring = "Data source=GUS-2681\\SQLEXPRESS; Initial catalog=WCFReservasi;Integrated Security=True";
        SqlConnection connection;
        SqlCommand com;


        //Pemesanan
        public List<Pemesanan> Pemesanan()
        {
            List<Pemesanan> pemesanans = new List<Pemesanan>();
            try
            {
                string sql = "SELECT ID_reservasi, Nama_customer, No_telpon, Jumlah_pemesanan, Nama_Lokasi FROM dbo.Pemesanan p join dbo. p.ID_lokasi = l.ID_lokasi";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Pemesanan data = new Pemesanan();
                    data.IDPemesanan = reader.GetString(0);
                    data.NamaCustomer = reader.GetString(1);
                    data.NoTelpon = reader.GetString(2);
                    data.JumlahPemesanan = reader.GetInt32(3);
                    data.Lokasi = reader.GetString(4);
                    pemesanans.Add(data);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return pemesanans;
        }


        //Detail
        public List<DetailLokasi> DetailLokasi()
        {
            List<DetailLokasi> LokasiFull = new List<DetailLokasi>();
            try
            {
                string sql = "SELECT ID_lokasi, Nama_lokasi, Deskripsi_full, Kuota from dbo.Lokasi";
                connection = new SqlConnection(constring);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DetailLokasi data = new DetailLokasi();
                    data.IDLokasi = reader.GetString(0);
                    data.NamaLokasi = reader.GetString(1);
                    data.DeskripsiFull = reader.GetString(2);
                    data.Kuota = reader.GetInt32(3);
                    LokasiFull.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return LokasiFull;
        }


        //Edit
        public string editPemesanan(string IDPemesanan, string NamaCustomer, string No_telpon, int JumlahPemesanan, string IDLokasi)
        {

            string n = "gagal";
            try
            {
                string sql = "INSERT INTO dbo.Pemesanan VALUES('" + IDPemesanan + "','" + NamaCustomer + "','" + No_telpon + "'," + JumlahPemesanan + ",'" + IDLokasi + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                string sql2 = "UPDATE dbo.Lokasi set Kuota = Kuota - " + JumlahPemesanan + " WHERE ID_lokasi = '" + IDLokasi + "' ";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                n = "Berhasil";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return n;

        }


        //Pemesanan
        public string Pemesanan(string IDPemesanan, string NamaCustomer, string NoTelpon, int JumlahPemesanan, string IDLokasi)
        {
            string n = "gagal";
            try
            {
                string sql = "INSERT INTO dbo.Pemesanan VALUES('" + IDPemesanan + "','" + NamaCustomer + "','" + NoTelpon + "'," + JumlahPemesanan + ",'" + IDLokasi + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                string sql2 = "UPDATE dbo.Lokasi set Kuota = Kuota - " + JumlahPemesanan + " WHERE ID_lokasi = '" + IDLokasi + "' ";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                n = "Berhasil";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return n;
        }

        //Delete
        public string deletePemesanan(string IDPemesanan)
        {

            string a = "Gagal";
            try
            {
                string sql = "delete from dbo.Pemesanann where ID_Reservasi = '" + IDPemesanan + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return a;
        }


    public List<CekLokasi> ReviewLokasi()
        {
            throw new NotImplementedException();
        }

        public string editPemesanan(string IDPemesanan, string NamaCustomer, string No_telpon)
        {
            throw new NotImplementedException();
        }
    }
}
