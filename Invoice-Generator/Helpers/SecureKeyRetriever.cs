namespace Invoice_Generator.Helpers;

public static class SecureKeyRetriever
{
    public static async Task<string> GetKeyAsync(string name)
    {
        var key = await SecureStorage.Default.GetAsync(name);

        if (string.IsNullOrEmpty(key))
        {
            key = Guid.NewGuid().ToString();
            await SecureStorage.Default.SetAsync(name, key);
        }

        return key;
    }
}