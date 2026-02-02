using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Models;

namespace Invoice_Generator.Adapters;

internal static class WorkAdapter
{
    internal static List<Work> ToWork(this List<WorkModel> workModels)
    {
        return workModels.ConvertAll(workModel => workModel.ToWork());
    }

    internal static List<WorkModel> ToWorkModels(this List<Work> work)
    {
        return work.ConvertAll(item => item.ToWorkModel());
    }

    private static Work ToWork(this WorkModel workModel)
    {
        return new Work()
        {
            Id = workModel.Id,
            Completed = workModel.Completed,
            Description = workModel.Description,
            Amount = workModel?.Amount ?? 0,
            Hours = workModel?.Hours ?? 0
        };
    }

    private static WorkModel ToWorkModel(this Work work)
    {
        return new WorkModel()
        {
            Id = work.Id,
            Completed = work.Completed,
            Description = work.Description,
            Amount = work.Amount,
            Hours = work.Hours
        };
    }
}