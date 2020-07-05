using System.Data;

namespace DataLayer

{
    //Interface

    // An interface contains definitions for a group of related functionalities that a class or a struct can implement.

    /// <summary>
    /// The Repository pattern begins with an interface, which outlines the methods that the data repository class will be able to perform. 

    /// </summary>
    public interface IRepository
    {
        int Insertar(string nombre, string telefono, string fechanac, string correo);                  //   C
        DataTable Consultar();                                                                         //   R                                     

        int Modificar(int id, string nombre, string telefono, string fechanac, string correo);         //   U

        int Eliminar(int id);                                                                          //   D

        DataTable ConsultarContacto(int id);
    }
}
