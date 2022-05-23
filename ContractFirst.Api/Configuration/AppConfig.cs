namespace ContractFirst.Configuration;

public class AppConfig
{
   public string ApplicationName { get; set; }
   public string LogLevel { get; set; }
   public ConnectionInfo ConnectionInfo { get; set; }
   public string HelloMessage { get; set; }
}