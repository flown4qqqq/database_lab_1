using System.Collections.ObjectModel;
using dblaba.DataModel;
using dblaba.Database;

namespace dblaba.ViewModels;

public class CompetitionsViewModel : SubViewModel
{
	public ObservableCollection<Competition> Competitions { get; } = null!;

	public CompetitionsViewModel()
	{   
        var x = QueryComposer.JoinCompetitions();

        System.Console.WriteLine("GOO");
        foreach (var competition in x) {
            System.Console.WriteLine(competition.Name + " " + competition.Date + " " + competition.NameOfSport + " " + competition.Place);
        }

		Competitions = new ObservableCollection<Competition>(QueryComposer.JoinCompetitions());
	}

	// public void AddDoctor()
	// {
	// 	NewDoctorViewModel newDoctor = new NewDoctorViewModel(App.DB.GetNextId("tblDoctor"), Doctors.Count);

	// 	Observable.Merge(
	// 		newDoctor.Add,
	// 		newDoctor.Back.Select(_ => (Doctor?)null))
	// 		.Take(1)
	// 		.Subscribe(newItem =>
	// 		{
	// 			if (newItem != null)
	// 			{
	// 				Doctors.Add(newItem);
	// 				App.DB.AddDoctor(newItem);
	// 			}

	// 			App.TopWindow.RemoveTopView();
	// 		});

	// 	App.TopWindow.AddView(newDoctor);
	// }

	// public void OpenDoctorReceptions(int idx)
	// {
	// 	App.TopWindow.AddView(new DoctorReceptionsViewModel(Doctors[idx]));
	// }
}
