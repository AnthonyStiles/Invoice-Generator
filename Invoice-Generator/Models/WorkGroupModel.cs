using System.Collections.ObjectModel;

namespace Invoice_Generator.Models;

public class WorkGroupModel
{
    public DateTime Date { get; set; }
    public ObservableCollection<WorkModel> Work { get; set; } = [];
}