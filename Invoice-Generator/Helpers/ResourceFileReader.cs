namespace Invoice_Generator.Helpers;

internal static class ResourceFileReader
{
    internal static async Task<string> Read(string fileName, string errorText)
    {
        try
        {
            await using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
        catch
        {
            return errorText;
        }
    }
}