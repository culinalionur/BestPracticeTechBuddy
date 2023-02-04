using BestPractice.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPractice.Api.Service
{
    public interface IContactService
    {
        public ContactDVO GetContactById(int id);
    }
}
