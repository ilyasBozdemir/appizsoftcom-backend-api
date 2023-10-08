namespace AppizsoftApp.Application.Constants
{
    public class DBConnectionString
    {
        public static string GetConnectionString(DeveloperName developerName, DBType DBType)
            => new Developer(developerName).Connections.FirstOrDefault(connection => connection.DbType == DBType)
            .ConnectionString;
    }
    public class DatabaseConnection { public DBType DbType { get; set; } public string ConnectionString { get; set; } }
    public enum DBType { SQLServer, PostgreSQL }
    [Flags]
    public enum DeveloperName { Ilyas, Murat }
    public class Developer
    {
        public DeveloperName Name { get; set; }
        public List<DatabaseConnection> Connections { get; set; }
        public Developer(DeveloperName DeveloperName)
        {
            Name = DeveloperName;
            Connections = new List<DatabaseConnection>();
            InitializationDBConnectionStrings(DeveloperName);
        }
        public void InitializationDBConnectionStrings(DeveloperName DeveloperName)
        {
            if (DeveloperName == DeveloperName.Ilyas)
            {
                Connections.Add(new DatabaseConnection
                {
                    DbType = DBType.PostgreSQL,
                    ConnectionString = ""
                });
                Connections.Add(new DatabaseConnection
                {
                    DbType = DBType.SQLServer,
                    ConnectionString = "Server=DESKTOP-R4UP5K6\\SQLEXPRESS;Database=AppizsoftAppDB;Integrated Security=True;"
                });
            }
            else if (DeveloperName == DeveloperName.Murat)
            {
                Connections.Add(new DatabaseConnection
                {
                    DbType = DBType.PostgreSQL,
                    ConnectionString = "Murat'ın PostgreSQL bağlantı dizesi buraya gelecek."
                });
                Connections.Add(new DatabaseConnection
                {
                    DbType = DBType.SQLServer,
                    ConnectionString = "Murat'ın SQLServer bağlantı dizesi buraya gelecek."
                });
            }
        }
    }
}
