using AutoMapper;
using BestPractice.Api.Data.Models;
using BestPractice.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BestPractice.Api.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _client;

        public ContactService(IMapper mapper, IHttpClientFactory client)
        {
            _mapper = mapper;
            _client = client;
        }


        public ContactDVO GetContactById(int id)
        {
            //Veri tabanından kaydın getirilmesi

            Contact dbContact = GetDummyContact();

            var client = _client.CreateClient("garantiapi");

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
