using MIS442Store.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Interfaces
{
    public interface IRegistrationRepository
    {
        List<Registration> GetUserRegistrations(string username);
        List<Registration> GetRegistrations();
        Registration GetRegistration(int id);

        void SaveRegistration(Registration registration);
        
    }
}