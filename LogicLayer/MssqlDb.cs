using System;
using System.Data;
using System.IO;
using DataLayer;

namespace LogicLayer
{
    class MssqlDb : IDataBase // CONCRETE PRODUCT:implements the Product interface

    {
        // With the layers defined, I can put the Repository pattern in action in the logic layer
        //by creating an instance of the ContactosBusiness, and passing in the same
        //instance the concrete repository class that I want. 

        // Implementation ContactosBusiness' class with a concrete instance of the MSSQLRepository.
        // The business layer calls the MSSQL repository for the Contactos data.

        ContactosBusiness contactosMSSQL = new ContactosBusiness(new MssqlRepository());

        DataTable Contactos = new DataTable();

        Checks verify = new Checks();

        public void Keep()
        {
            Contactos = contactosMSSQL.Consultar();

            //Pass the file path and filename to the StreamWriter 
            StreamWriter sw = new StreamWriter("C:\\Users\\DESARROLLADOR 10\\Documents\\ContactosSQLServer.txt");

            sw.WriteLine("Sus contactos guardados son los siguientes: ");

            foreach (DataRow x in Contactos.Rows)
            {
                sw.WriteLine(" \n");
                sw.WriteLine($" Contacto  {x[0].ToString()}                   ");
                sw.WriteLine("____________________________________");
                sw.WriteLine($" Id: { x[0].ToString()}");
                sw.WriteLine($" Nombre: { x[1].ToString()}");
                sw.WriteLine($" Telefono: { x[2].ToString()}");
                sw.WriteLine($" Fecha de Nacimiento: { x[3].ToString()}");
                sw.WriteLine($" Correo: { x[4].ToString()}");
                sw.WriteLine("____________________________________");
                sw.WriteLine(" \n");
            }

            //Close the file
            sw.Close();
        }

        public void Read()
        {
            Contactos = contactosMSSQL.Consultar();

            foreach (DataRow x in Contactos.Rows)

            {
                Console.WriteLine(" __________________________________");
                Console.WriteLine($"  Contacto: { x[0].ToString()}                     ");
                Console.WriteLine(" \n");
                Console.WriteLine($" Id:  { x[0].ToString()}");
                Console.WriteLine($" Nombre: { x[1].ToString()}");
                Console.WriteLine($" Telefono: { x[2].ToString()}");
                Console.WriteLine($" Fecha de Nacimiento: { (x[3]).ToString() }");
                Console.WriteLine($" Correo: { x[4].ToString()}");
                Console.WriteLine(" __________________________________");

                Console.ReadLine();

            }
        }

        public void Add()
        {
            Contacto cn = new Contacto();

            Console.WriteLine("Ingrese el nombre del contacto: ");
            cn.Nombre = Console.ReadLine();

            bool verificar = verify.Name(cn.Nombre);

            while (!verificar)
            {

                Console.WriteLine("Ingrese el nombre del contacto de nuevo, recuerde solo letras: ");
                cn.Nombre = Console.ReadLine();
                verificar = verify.Name(cn.Nombre);

            }


            Console.WriteLine("Ingrese el telefono del contacto: ");
            cn.Telefono = Console.ReadLine();

            bool verificar1 = verify.Numeric(cn.Telefono);

            while (!verificar1)
            {
                Console.WriteLine("Ingrese el telefono nuevamente, recuerde solo números: ");
                cn.Telefono = Console.ReadLine();
                verificar1 = verify.Numeric(cn.Telefono);
            }



            Console.WriteLine("Ingrese la fecha de nacimiento del contacto (Dia/Mes/Año) : ");
            cn.Fechanac = Console.ReadLine();

            bool verificar2 = verify.Fecha(cn.Fechanac);

            while (!verificar2)
            {

                Console.WriteLine("Ingrese la fecha de nacimiento del contacto de nuevo, recuerde (Dia/Mes/Año) : ");
                cn.Fechanac = Console.ReadLine();
                verificar2 = verify.Fecha(cn.Fechanac);
            }

            Console.WriteLine("Ingrese el e-mail del contacto: ");
            cn.Correo = Console.ReadLine();

            bool verificar3 = verify.Mail(cn.Correo);

            while (!verificar3)
            {
                Console.WriteLine("Ingrese el e-mail de nuevo: ");
                cn.Correo = Console.ReadLine();
                verificar3 = verify.Mail(cn.Correo);
            }

            int insercion = contactosMSSQL.Insertar(cn.Nombre, cn.Telefono, cn.Fechanac, cn.Correo);

            if (insercion > 0)
            {
                Console.WriteLine(" \n");
                Console.WriteLine("El contacto ha sido agregado exitosamente.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(" \n");
                Console.WriteLine("El contacto no se ha podido agregar. ");
                Console.ReadLine();
            }

        }

        public void Update()
        {

            Contacto co = new Contacto();

            Console.WriteLine("Ingrese el id del contacto que desea Modificar: ");
            co.Id = Convert.ToInt32(Console.ReadLine());

            DataTable ConsultarContacto = contactosMSSQL.ConsultarContacto(co.Id);

            foreach (DataRow x in ConsultarContacto.Rows)

            {
                Console.WriteLine(" __________________________________");
                Console.WriteLine($" Informacion del contacto {co.Id}:         ");
                Console.WriteLine(" \n");
                Console.WriteLine($" Nombre: { x[0].ToString()}");
                Console.WriteLine($" Telefono; { x[1].ToString()}");
                Console.WriteLine($" Fecha de Nacimiento: { x[2].ToString()}");
                Console.WriteLine($" Correo: { x[3].ToString()}");
                Console.WriteLine(" __________________________________");
                Console.WriteLine(" \n");
            }

            Console.WriteLine("Ingrese el nuevo nombre del contacto: ");
            co.Nombre = Console.ReadLine();

            bool verificar4 = verify.Name(co.Nombre);

            while (!verificar4)
            {

                Console.WriteLine("Ingrese el nombre del contacto de nuevo, recuerde solo letras: ");
                co.Nombre = Console.ReadLine();
                verificar4 = verify.Name(co.Nombre);

            }


            Console.WriteLine("Ingrese el nuevo telefono del contacto: ");
            co.Telefono = Console.ReadLine();

            bool verificar5 = verify.Numeric(co.Telefono);

            while (!verificar5)
            {
                Console.WriteLine("Ingrese el telefono nuevamente, recuerde solo números: ");
                co.Telefono = Console.ReadLine();
                verificar5 = verify.Numeric(co.Telefono);
            }

            Console.WriteLine("Ingrese la nueva fecha de nacimiento del contacto (Dia/Mes/Año): ");
            co.Fechanac = Console.ReadLine();

            bool verificar6 = verify.Fecha(co.Fechanac);

            while (!verificar6)
            {

                Console.WriteLine("Ingrese la fecha de nacimiento del contacto de nuevo, recuerde (Dia/Mes/Año) : ");
                co.Fechanac = Console.ReadLine();
                verificar6 = verify.Fecha(co.Fechanac);
            }


            Console.WriteLine("Ingrese el nuevo e-mail del contacto: ");
            co.Correo = Console.ReadLine();

            bool verificar7 = verify.Mail(co.Correo);

            while (!verificar7)
            {
                Console.WriteLine("Ingrese el e-mail de nuevo: ");
                co.Correo = Console.ReadLine();
                verificar7 = verify.Mail(co.Correo);
            }


            int Modificar = contactosMSSQL.Modificar(co.Id, co.Nombre, co.Telefono, co.Fechanac, co.Correo);

            if (Modificar > 0)
            {
                Console.WriteLine(" \n");
                Console.WriteLine("El contacto ha sido modificado exitosamente.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(" \n");
                Console.WriteLine("El contacto no se ha podido modificar. ");
                Console.ReadLine();

            }
        }

        public void Delete()
        {
            Contacto cp = new Contacto();


            Console.WriteLine("Ingrese el id del contacto que desea eliminar: ");
            cp.Id = Convert.ToInt32(Console.ReadLine());

            int Eliminar = contactosMSSQL.Eliminar(cp.Id);

            if (Eliminar > 0)
            {
                Console.WriteLine(" \n");
                Console.WriteLine("El contacto ha sido eliminado exitosamente.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(" \n");
                Console.WriteLine("El contacto no se ha podido eliminar. ");
                Console.ReadLine();

            }
        }

        public void ReadContact()
        {
            Contacto con = new Contacto();

            Console.WriteLine("Introduzca el id del contacto: ");
            con.Id = Convert.ToInt32(Console.ReadLine());

            DataTable ConsultarContacto = contactosMSSQL.ConsultarContacto(con.Id);

            foreach (DataRow x in ConsultarContacto.Rows)

            {
                Console.WriteLine(" __________________________________");
                Console.WriteLine($" Informacion del contacto:         ");
                Console.WriteLine(" \n");
                Console.WriteLine($" Nombre: { x[0].ToString()}");
                Console.WriteLine($" Telefono; { x[1].ToString()}");
                Console.WriteLine($" Fecha de Nacimiento: { x[2].ToString()}");
                Console.WriteLine($" Correo: { x[3].ToString()}");
                Console.WriteLine(" __________________________________");

                Console.ReadLine();

            }
        }
    }
}
