using System;
using System.Data;
using System.Data.SqlClient;


namespace DataLayer
{
    // First One Repository

    // To create a repository I just have to implement the Repository pattern Interface and write the required code for accessing the MSSQL Database and 
    // populate the "Contacto" types.
    public class MssqlRepository : IRepository
    {

        //    SQLConnection specifies the database's source and set the properties wich I'm going to connect the basedata with.

        SqlConnection conexion = new SqlConnection("Data Source=AZDESAR10;Initial Catalog=ChicharronesSA;Persist Security Info=True;User ID=sa; Password=123");

        //    Create a method that returns a table

        public DataTable Consultar()
        {

            //     I need a table because this method needs to returns one. So I create it.

            DataTable Cliente = new DataTable();

            //Protecting query with try

            try
            {
                conexion.Open();

                //     Initializes a new instance of the SqlClient.SqlCommand class with the text of the query and a SqlClient.SqlConnection.
                //     Se inicializa una nueva instancia de la clase sql command con el texto del query y la conexión
                //     SqlCommand es una clase la cual ejecuta comandos a una fuente de datos

                SqlCommand comando = new SqlCommand("Select id, nombre, telefono, fechanac, correo from Cliente", conexion)
                {

                    //     If it is going to execute a query, it's necessary to specify with "CommandType Text". This one specifies how a command string is interpreted.
                    //     CommandType.Text is an SQL text command.
                    //     Si se va a ejecutar una consulta, se especifica con CommandType Text. Esto especifica como un comando es interpretado.

                    CommandType = CommandType.Text
                };

                //     Sqladapter populate the DataTable. For this is necessary to create an instance. 

                SqlDataAdapter adaptador = new SqlDataAdapter()
                {

                    //     The SelectCommand is a method of the DataAdapter is a command that retrieves data from data source. This command represents a select sentence.

                    SelectCommand = comando
                };

                //     The Fill method of the Data Adapter is used to populate a DataTable with the results of the SelectCommand. 

                adaptador.Fill(Cliente);
            }

            // Catch capture the  exceptions that can take place when querys are working on.

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conexion.Close();   //Closing the conection to release memory space.
            }
            return Cliente;

        }

        public int Insertar(string nombre, string telefono, string fechanac, string correo)
        {
            // Query contiene la instruccion SQL. Query keeps the SQL instruction

            // The "at" symbol says the parameters that I'm going to give it.

            string query = "INSERT INTO Cliente (Nombre, Telefono, FechaNac, Correo) VALUES (@nombre, @telefono, @fechanac, @correo)";

            conexion.Open();

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@fechanac", fechanac);
            comando.Parameters.AddWithValue("@correo", correo);

            //comando.ExecuteNonQuery() returns the affected rows' number.

            int filas = comando.ExecuteNonQuery();

            conexion.Close();
            return filas;
        }

        public int Modificar(int id, string nombre, string telefono, string fechanac, string correo)
        {

            string query = "UPDATE Cliente Set Nombre=@nombre , Telefono=@telefono, FechaNac=@fechanac, Correo=@correo WHERE Id=@id";




            SqlCommand comando = new SqlCommand(query, conexion);


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

            SqlCommand comando = new SqlCommand(query, conexion);

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

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.CommandType = CommandType.Text;

                SqlDataAdapter adaptador = new SqlDataAdapter();

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
