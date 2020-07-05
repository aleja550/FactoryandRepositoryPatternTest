using LogicLayer;

namespace PruebaFactoryRepo
{
    class Program
    {
        static void Main(string[] args)
        {
            DbFactory factory = new DbFactoryConcrete();

            IDataBase SQLServer = factory.GetDb("1");
            IDataBase PostgreSQL = factory.GetDb("2");

        }

        //In the above code I have created FactoryDesignPattern class which consists of main() method. 
        //In this main() method I have created DbFactory class object known as factory
        //Using this object I have called getDb() method for both Databases SQLServer and PostgreSQL.
    }
}

