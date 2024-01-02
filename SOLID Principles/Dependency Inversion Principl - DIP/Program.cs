
    //Dependency Inversion Principle (DIP) :
    
    /*This C# code follows the Dependency Inversion Principle (DIP)
     by introducing the IDataHarbor interface,defining methods for 
     saving and retrieving data.Concrete implementations, such as 
     Database and CloudStorage, conform to this interface. 
     
     The DataManager class, relying on the abstraction (IDataHarbor), exemplifies DIP, 
     allowing flexibility in choosing data storage methods without altering the high-level module. 
     The Test class demonstrates this principle by creating instances of Database and CloudStorage and 
     seamlessly integrating them with DataManager. This adherence to DIP enhances code modularity and 
     supports future extensibility in data storage implementations.
     */

using System;
using System.Collections.Generic;

namespace DIP
{
    //Interface
    public interface IDataHarbor
    {
        void Save(string data);
        string Retrieve(int id);
    }

    //Concrete implementations
    public class Database : IDataHarbor
    {
        public void Save(string data) => Console.WriteLine($"[[{data}]]\nSaving note to Database...");
        public string Retrieve(int id) => $"Note {id} from Database";
    }

    public class CloudStorage : IDataHarbor
    {
        public void Save(string data) => Console.WriteLine($"[[{data}]]\nSaving note to Cloud...");
        public string Retrieve(int id) => $"Note {id} from Cloud.";
    }
    //The DataManager now relies on an abstraction

    public class DataManager
    {
        private readonly IDataHarbor _dataHarbor;

        public DataManager(IDataHarbor dataHarbor)
        {
            _dataHarbor = dataHarbor;
        }

        public void SendData(string note)
        {
            _dataHarbor.Save(note);
        }

        public string GetData(int id)
        {
            return _dataHarbor.Retrieve(id);
        }
    }

    public class Test
    {
        public static void Main(string[] args)
        {
            var dataBase = new Database();
            var noteManagerDB = new DataManager(dataBase);
            noteManagerDB.SendData(
                "O my Lord! I am indeed needy of whatever good You may send to me..[Surah Qassas; 28:24]");

            var Cloud = new CloudStorage();
            var noteManagerCloud = new DataManager(Cloud);
            noteManagerCloud.SendData("So, surely with hardship comes ease” (Quran 94:5)");

            Console.WriteLine(noteManagerCloud.GetData(94));
            Console.WriteLine(noteManagerDB.GetData(28));
        }
    }
}