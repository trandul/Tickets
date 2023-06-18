namespace DAL.ConnectionSettings
{
    public class ConnectionSettingsModel
    {
        public string ConnectionString { get; }
        public ConnectionSettingsModel(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
