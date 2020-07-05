using System.Data;
using DataLayer;

namespace LogicLayer
/// <summary>
/// To optimally implement the Repository pattern, I’ll need to create our business logic layer. Because the correct implementation of IRepository is 
/// handled by ContactosBusiness.
/// 
/// The business layer sits between the user interface and the Repository pattern data class.
/// So, the business layer can be considered as a filter for the Repository pattern, calling the repository to obtain data and passing the processed results to the calling class.
/// </summary>  

// The idea is can implement any kind of repository, such as MSSQL, PostgreSQL, or anyone else.

//The remainer of ContactosBusiness models the repository interface, with regard to the functions that may want to use.

{
    public class ContactosBusiness
    {

        IRepository _repository;

        public ContactosBusiness(IRepository repository) // Builder
        {
            _repository = repository;
        }

        //CRUD

        public int Insertar(string nombre, string telefono, string fechanac, string correo)                  //  Create
        {
            return _repository.Insertar(nombre, telefono, fechanac, correo);
        }

        public DataTable Consultar()                                                                         //  Read
        {
            return _repository.Consultar();

        }

        public int Modificar(int id, string nombre, string telefono, string fechanac, string correo)        // Update
        {
            return _repository.Modificar(id, nombre, telefono, fechanac, correo);
        }

        public int Eliminar(int id)                                                                         //  Delete
        {
            return _repository.Eliminar(id);
        }

        public DataTable ConsultarContacto(int id)
        {
            return _repository.ConsultarContacto(id);

        }
    }
}
