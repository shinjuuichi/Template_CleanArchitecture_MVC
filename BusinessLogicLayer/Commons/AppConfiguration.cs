namespace BusinessLogicLayer.Commons
{
    public class AppConfiguration
    {
        public DatabaseConfig DatabaseConfig { get; set; } = null!;
        public EmailConfig EmailConfig { get; set; } = null!;
        public SqlServerCacheConfig SqlServerCacheConfig { get; set; } = null!;
        public DropboxConfig DropboxConfig { get; set; } = null!;

    }

    #region DatabaseConfig
    public class DatabaseConfig
    {
        public string ConnectionString { get; set; } = string.Empty;
        public bool IsMemoryDB { get; set; } = false;
    }
    #endregion

    #region EmailConfig
    public class EmailConfig
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    #endregion

    #region SqlServerCacheConfig
    public class SqlServerCacheConfig
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string InstanceName { get; set; } = string.Empty;
    }
    #endregion

    #region DropboxConfig
    public class DropboxConfig
    {
        public string AccessToken { get; set; } = string.Empty;
        public string AppName { get; set; } = string.Empty;
    }
    #endregion
}
