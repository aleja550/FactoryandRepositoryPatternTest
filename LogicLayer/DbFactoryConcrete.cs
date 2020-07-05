using System;


namespace LogicLayer
{
    public class DbFactoryConcrete : DbFactory      //CONCRETE CREATOR: overrides the factory method to return an instance of a ConcreteProduct.
    {
        public override IDataBase GetDb(String op)
        {
            IDataBase dataBase;
            int i;

            do
            {
                do
                {

                    Console.WriteLine("|----------------------------------MENÚ---------------------------|");
                    Console.WriteLine("| Seleccione la opción que quiera realizar:                       |");
                    Console.WriteLine("| {1} Conectarse a SQL Server                                     |");
                    Console.WriteLine("| {2} Conectarse a PostgreSQL                                     |");
                    Console.WriteLine("| {3} Salir                                                       |");
                    Console.WriteLine("|-----------------------------------------------------------------|");
                    op = Console.ReadLine();

                    if (!int.TryParse(op, out i))
                    {
                        Console.WriteLine("Por favor ingrese una de las opciones que le fueron indicadas en el Menú. ");
                    }
                    else
                        if (string.IsNullOrEmpty(op))
                    {
                        Console.WriteLine("Por favor ingrese una de las opciones que le fueron indicadas en el Menú. ");
                    }



                } while (op != "1" && op != "2" && op != "3");


                switch (op)
                {
                    case "1":

                        dataBase = new MssqlDb();

                        do
                        {
                            do
                            {
                                Console.WriteLine("|----------------------------------MENÚ---------------------------|");
                                Console.WriteLine("| Seleccione la opción que quiera realizar:                       |");
                                Console.WriteLine("| {1} Guardar Contactos en un bloc de notas                       |");
                                Console.WriteLine("| {2} Consultar todos los contactos en Consola                    |");
                                Console.WriteLine("| {3} Agregar Nuevo Contacto                                      |");
                                Console.WriteLine("| {4} Modificar Contacto                                          |");
                                Console.WriteLine("| {5} Eliminar Contacto                                           |");
                                Console.WriteLine("| {6} Consultar un contacto en particular                         |");
                                Console.WriteLine("| {7} Volver                                                      |");
                                Console.WriteLine("|-----------------------------------------------------------------|");

                                op = Console.ReadLine();

                                if (!int.TryParse(op, out i))
                                {
                                    Console.WriteLine("Por favor ingrese una de las opciones que le fueron indicadas en el Menú. ");
                                }
                                else
                                    if (string.IsNullOrEmpty(op))
                                {
                                    Console.WriteLine("Por favor ingrese una de las opciones que le fueron indicadas en el Menú. ");
                                }

                            } while (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "6" && op != "7");

                            switch (op)
                            {
                                case "1":

                                    dataBase.Keep();


                                    Console.WriteLine("Se han guardado sus contactos en el Bloc de Notas " + "llamado ContactosSQLServer.txt en Documentos");
                                    Console.WriteLine(" \n");
                                    Console.WriteLine("¿Desea realizar otra acción?");


                                    break;

                                case "2":

                                    dataBase.Read();

                                    break;

                                case "3":

                                    dataBase.Add();

                                    break;

                                case "4":

                                    dataBase.Update();

                                    break;

                                case "5":

                                    dataBase.Delete();

                                    break;

                                case "6":

                                    dataBase.ReadContact();

                                    break;
                            }

                        } while (op != "7");

                        break;


                    case "2":

                        dataBase = new PostgresSqlDb();


                        do
                        {
                            do
                            {
                                Console.WriteLine("|----------------------------------MENÚ---------------------------|");
                                Console.WriteLine("| Seleccione la opción que quiera realizar:                       |");
                                Console.WriteLine("| {1} Guardar Contactos en un bloc de notas                       |");
                                Console.WriteLine("| {2} Consultar todos los contactos en Consola                    |");
                                Console.WriteLine("| {3} Agregar Nuevo Contacto                                      |");
                                Console.WriteLine("| {4} Modificar Contacto                                          |");
                                Console.WriteLine("| {5} Eliminar Contacto                                           |");
                                Console.WriteLine("| {6} Consultar un contacto en particular                         |");
                                Console.WriteLine("| {7} Volver                                                      |");
                                Console.WriteLine("|-----------------------------------------------------------------|");

                                op = Console.ReadLine();

                                if (!int.TryParse(op, out i))
                                {
                                    Console.WriteLine("Por favor ingrese una de las opciones que le fueron indicadas en el Menú. ");
                                }
                                else
                                    if (string.IsNullOrEmpty(op))
                                {
                                    Console.WriteLine("Por favor ingrese una de las opciones que le fueron indicadas en el Menú. ");
                                }

                            } while (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "6" && op != "7");

                            switch (op)
                            {
                                case "1":

                                    dataBase.Keep();


                                    Console.WriteLine("Se han guardado sus contactos en el Bloc de Notas " + "llamado ContactosPosgreSQL.txt en Documentos");
                                    Console.WriteLine(" \n");
                                    Console.WriteLine("¿Desea realizar otra acción?");


                                    break;

                                case "2":

                                    dataBase.Read();

                                    break;

                                case "3":

                                    dataBase.Add();

                                    break;

                                case "4":

                                    dataBase.Update();

                                    break;

                                case "5":

                                    dataBase.Delete();

                                    break;

                                case "6":

                                    dataBase.ReadContact();

                                    break;
                            }

                        } while (op != "7");

                    break;

                    default:
                        dataBase = null;
                        break;                      

                }

            } while (op != "3");

            return dataBase;

        }
    }
}
