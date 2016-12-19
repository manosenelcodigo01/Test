using System;

namespace Demo.infraestructura.data.Factory
{
    public class DataWorker
    {
        private static readonly Database DataBase = null;
        static DataWorker()
        {
            try
            {
                DataBase = DatabaseFactory.CreateDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Database dataBase
        {
            get { return DataBase; }
        }
    }
}
