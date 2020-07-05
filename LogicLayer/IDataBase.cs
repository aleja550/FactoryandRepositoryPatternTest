namespace LogicLayer
{
    public interface IDataBase //PRODUCT

    //The PRODUCT defines the interface of objects the factory method creates
    {
        void Keep();

        void Read();

        void Add();

        void Update();

        void Delete();

        void ReadContact();
    }
}
