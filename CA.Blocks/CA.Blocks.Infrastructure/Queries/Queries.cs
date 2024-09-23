namespace CA.Blocks.Infrastructure;
public static class Queries
{

    internal static string GetEmployeeTotalCount = GetQuery(nameof(GetEmployeeTotalCount));
    internal static string GetJobTotalCount = GetQuery(nameof(GetJobTotalCount));

    private static string GetQuery(string name)
    {
#if DEBUG
        return File.ReadAllText($"../SampleProject.Infrastructure/QueryTexts/{name}.sql");
#else
        return File.ReadAllText($"QueryTexts/{name}.sql");
#endif
    }

}
