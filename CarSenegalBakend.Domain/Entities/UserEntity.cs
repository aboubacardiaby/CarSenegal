using CarSenegalBakend.Domain.Common;
using CarSenegalBakend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Entities
{
    public class UserEntity : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string  UserName { get; set; }
        public string  Password { get; set; }
        public string  Token { get; set; }
        public Address Address {  get; set; }
    }
}
