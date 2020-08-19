using CadastroWPF.DAL;
using CadastroWPF.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CadastroWPF.ViewModel
{
    public class UserViewModel : ObservableCollection<User>
    {
        private static DAL_SERVICES service;

        public UserViewModel()
        {
            PreparaUserCollection();
        }

        private async void PreparaUserCollection()
        {
            service = new DAL_SERVICES();
            IEnumerable<User> users = await service.GetAll();

            if (users != null)
            {
                foreach (User item in users)
                {
                    Add(item);
                }
            }
        }
    }
}
