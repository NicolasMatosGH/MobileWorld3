using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MobileWorld.Core.DomainObjects;





namespace MobileWorld.Domain.Entities
{
    public class Client : Entity
    {
        protected Client() { }
        public Client(string name,
            Email email,
            Cpf cpf,
            bool active,
            PhoneNumber phoneNumber,
            string password)
        {
            Name = name;
            Email = email.Address;
            Cpf = cpf.Number;
            Active = active;
            PhoneNumber = phoneNumber.Number;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Cpf { get; private set; }
        public bool Active { get; private set; }
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }

        public void SetAddress(Address address)
        {
            Address = address;
            AddressId = address.Id;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }

    }
}
