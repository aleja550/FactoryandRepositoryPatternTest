namespace DataLayer
{
    /// <summary>
    /// It's necessary to define a class. In this case I have a single type called "Contacto". 
    /// This one type has the required fields for working with information about
    /// a contact, the fields are most likely the same fields as the database table. 
    /// </summary>

    //MAIN IDEA

    //Since the Databases of MSSQL and POSTGRESQL in the layer logic deals with de "Contacto" class, the different repositories can populate the "Contacto" type
    // as they want.

    // Any repository that I would implement will populate the "Contacto" object with data in their own. Aand other layers in my application
    // never realize about details aboud how the repository actually populate the "Contacto" type. 
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public string Fechanac { get; set; }
        public string Correo { get; set; }

        public Contacto() { }
        public Contacto(int id, string nombre, string telefono, string fechanac, string correo)
        {
            Nombre = nombre;
            Telefono = telefono;
            Fechanac = fechanac;
            Correo = correo;
        }
    }
}
