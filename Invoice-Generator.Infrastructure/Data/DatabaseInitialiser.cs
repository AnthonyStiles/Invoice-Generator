using SQLitePCL;

namespace Invoice_Generator.Infrastructure.Data;

public static class DatabaseInitialiser
{
    public static void Initialise()
    {
        Batteries_V2.Init();
    }
}