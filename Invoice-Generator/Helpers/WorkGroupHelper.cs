using System.Collections.ObjectModel;
using Invoice_Generator.Models;

namespace Invoice_Generator.Helpers;

internal static class WorkGroupHelper
{
    internal static void GroupWorkItem(ObservableCollection<WorkGroupModel> workGroups, WorkModel work)
    {
        var workGroup = workGroups.FirstOrDefault(group => group.Date.Date == work.Completed.Date);
        if (workGroup != null)
        {
            workGroup.Work.Add(work);
        }
        else
        {
            var newWorkGroup = new WorkGroupModel
            {
                Date = work.Completed.Date,
                Work = [work]
            };

            if (workGroups.Count == 0 || workGroups.Last().Date < newWorkGroup.Date)
            {
                workGroups.Add(newWorkGroup);
            }
            else
            {
                for (var i = 0; i < workGroups.Count; i++)
                {
                    var group = workGroups[i];
                    if (newWorkGroup.Date < group.Date)
                    {
                        workGroups.Insert(i, newWorkGroup);
                        break;
                    }
                }
            }
        }
    }
}