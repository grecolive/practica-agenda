using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;

namespace Datos
{
    public class ClassDatos
    {
        SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ConnectionString);


        public void Create(Contacto contacto){
            SqlCommand cmd = new SqlCommand("AgregarContacto", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", contacto.Nombre);
            cmd.Parameters.AddWithValue("@telefono", contacto.Telefono);
            cmd.Parameters.AddWithValue("@email", contacto.Email);
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
        }

        public DataTable Read()
        {
            SqlCommand cmd = new SqlCommand("ObtenerContactos", sql);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public void Update(Contacto contacto){
            SqlCommand cmd = new SqlCommand("ActualizarContacto", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", contacto.ID);
            cmd.Parameters.AddWithValue("@nombre", contacto.Nombre);
            cmd.Parameters.AddWithValue("@telefono", contacto.Telefono);
            cmd.Parameters.AddWithValue("@email", contacto.Email);
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
        }
        public void Delete(int id){
            SqlCommand cmd = new SqlCommand("EliminarContacto", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
        }

        public DataTable Search(string criterio){
            SqlCommand cmd = new SqlCommand("BuscarContactoPorEmailONombre", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param", criterio);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
