using AutoMapper;
using BestPractice.Api.Data.Models;
using BestPractice.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPractice.Api.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper)
        {
            _mapper = mapper;
        }

     
        public ContactDVO GetContactById(int id)
        {
            //Veri tabanından kaydın getirilmesi

            Contact dbContact = GetDummyContact();

            ContactDVO resultContact = _mapper.Map<ContactDVO>(dbContact);


            //return new ContactDVO()
            //{
            //    Id = dbContact.Id,
            //    FullName = $"{dbContact.FirstName} {dbContact.LastName}",
            //};
            return resultContact;
        }
        private Contact GetDummyContact()
        {
            return new Contact()
            {
                Id = 1,
                FirstName = "Onur",
                LastName = "Akıncı"
            };
        }
    }
}
