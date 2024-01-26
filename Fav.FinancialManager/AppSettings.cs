namespace Fav.FinancialManager;

public class AppSettings
{
    private static readonly string DataBaseName = "fav.Db";
    private static readonly string DataBaseDirectory = FileSystem.AppDataDirectory;
    public static string DataBasePath = Path.Combine(DataBaseDirectory, DataBaseName);
}