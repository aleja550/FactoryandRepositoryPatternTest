using System;

namespace LogicLayer
{
    public abstract class DbFactory   //CREATOR:  declares the factory method, which returns an object of type Product. 
    {
        public abstract IDataBase GetDb(String op);
    }
}

/// <summary>
/// In Factory pattern, I create object without exposing the creation logic to the client and refer to newly created object using a common interface.
/// This type of design pattern comes under creational pattern as this pattern provides one of the best ways to create an object.
/// </summary>

