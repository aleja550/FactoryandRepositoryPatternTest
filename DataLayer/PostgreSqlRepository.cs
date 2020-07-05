using System;
using System.Data;
using Npgsql;


namespace DataLayer
// Second One Repository

// I can actually create another Contactos repository quite easily, effectively allowing me to change data sources, 
// without touching any other areas of the application. This is an extremely powerful feature and the main reason to use the repository pattern. 
// This one repository working with a PostgreSQL Database.
{
    public class PostgreSqlRepository : IRepository
    {

        NpgsqlConnection conexion = new NpgsqlConnection("Host=127.0.0.1; Username=postgres; Password=1234;  Port=5432; Database=Chicharrones");

        public DataTable Consultar()
        {

            DataTable Cliente = new DataTable();

            try
            {
                conexion.Open();



                NpgsqlCommand comando = new NpgsqlCommand("Select id, nombre, telefono, fechanac, correo from Cliente", conexion)
                {
                    CommandType = CommandType.Text
                };

                NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter
                {
                    SelectCommand = comando
                };

                adaptador.Fill(Cliente);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conexion.Close();
            }
            return Cliente;

        }

        public int Insertar(string nombre, string telefono, string fechanac, string correo)

        {

            string query = "INSERT INTO Cliente (Nombre, Telefono, FechaNac, Correo) VALUES (@nombre, @telefono, @fechanac, @correo)";

            conexion.Open();


            NpgsqlCommand comando = new NpgsqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@fechanac", fechanac);
            comando.Parameters.AddWithValue("@correo", correo);

            int filas = comando.ExecuteNonQuery();

            conexion.Close();
            return filas;
        }

        public int Modificar(int id, string nombre, string telefono, string fechanac, string correo)
        {

            string query = "UPDATE Cliente Set Nombre=@nombre , Telefono=@telefono, FechaNac=@fechanac, Correo=@correo WHERE Id=@id";


            NpgsqlCommand comando = new NpgsqlCommand(query, conexion);


            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@fechanac", fechanac);
            comando.Parameters.AddWithValue("@correo", correo);

            conexion.Open();

            int filas = comando.ExecuteNonQuery();

            conexion.Close();

            return filas;

        }

        public int Eliminar(int id)
        {

            string query = "DELETE FROM Cliente where Id = (@id)";

            conexion.Open();

            NpgsqlCommand comando = new NpgsqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@id", id);


            int filas = comando.ExecuteNonQuery();

            conexion.Close();

            return filas;

        }

        public DataTable ConsultarContacto(int id)
        {

            DataTable Contacto = new DataTable();

            try
            {

                string query = "SELECT Nombre, Telefono, FechaNac, Correo FROM Cliente WHERE Id=@id";

                conexion.Open();

                NpgsqlCommand comando = new NpgsqlCommand(query, conexion);

                comando.CommandType = CommandType.Text;

                NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter();

                comando.Parameters.AddWithValue("@id", id);

                adaptador.SelectCommand = comando;

                adaptador.Fill(Contacto);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conexion.Close();
            }
            return Contacto;

        }
    }
}
