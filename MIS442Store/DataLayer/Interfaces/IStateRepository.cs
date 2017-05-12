using MIS442Store.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Interfaces
{
    interface IStateRepository
    {
      List<USState> GetStates();
    }
}