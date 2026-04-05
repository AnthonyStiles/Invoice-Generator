using System.Collections.ObjectModel;
using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Helpers;
using Invoice_Generator.Models;

namespace Invoice_Generator.Adapters;

internal static class WorkGroupAdapter
{
    internal static List<Work> ToWork(this ObservableCollection<WorkGroupModel> workGroups)
    {
        List<Work> work = [];

        foreach (var workGroup in workGroups)
        {
            foreach (var workItem in workGroup.Work)
            {
                work.Add(workItem.ToWork());
            }
        }

        return work;
    }

    internal static ObservableCollection<WorkGroupModel> ToWorkGroupModels(this List<Work> work)
    {
        ObservableCollection<WorkGroupModel> workGroups = [];

        foreach (var workItem in work)
        {
            WorkGroupHelper.GroupWorkItem(workGroups, workItem.ToWorkModel());
        }

        return workGroups;
    }
}