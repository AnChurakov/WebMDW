using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace MobileMDW
{
    class AppViewModel
    {
        bool initialized = false;   // была ли начальная инициализация
        Project selectedProject;  // выбранный друг
        private bool isBusy;    // идет ли загрузка с сервера

        public ObservableCollection<Project> Project { get; set; }
        TestService testService = new TestService();
        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation { get; set; }

        public async Task GetProject()
        {
            IEnumerable<Project> projects = await testService.Get();

            foreach (Project p in projects)
            {
                Project.Add(p);
            };
        }
         
        
    }
}
