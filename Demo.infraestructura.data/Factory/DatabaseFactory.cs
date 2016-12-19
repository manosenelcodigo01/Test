using System;
using System.Configuration;
using System.Reflection;

namespace Demo.infraestructura.data.Factory
{
    public static class DatabaseFactory
    {
        public static Database CreateDatabase()
        {
            var clase = ConfigurationManager.AppSettings["ClaseDatabase"];
            var connectionStringName = ConfigurationManager.AppSettings["ConnectionStringName"];
            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            if (string.IsNullOrEmpty(clase))
                throw new Exception("El nombre de la db no esta definida en el web.config.");
            try
            {
                Type database = Type.GetType(clase);
                ConstructorInfo constructor = database?.GetConstructor(new Type[] { });
                if (constructor != null)
                {
                    Database createdObject = (Database)constructor.Invoke(null);
                    createdObject.ConnectionString = connectionString;
                    return createdObject;
                }
            }
            catch (Exception excep)
            {
                throw new Exception("Error instantiating database " + excep.Message);
            }
            return null;
        }
    }
}
