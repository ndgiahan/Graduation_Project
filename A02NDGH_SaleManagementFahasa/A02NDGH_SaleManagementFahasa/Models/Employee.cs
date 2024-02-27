using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahasa.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public bool Sex { get; set; }
        public string Name { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CitizenIdentity { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int BranchId { get; set; }
        public int PositionId { get; set; }
        public Employee() { }
        public Employee(string name, string username)
        {
            Name = name;
            Username = username;
        }
        public Employee(int id, bool sex, string name, DateTime dayOfBirth, string address,
            string phoneNumber, string citizenIdentity, int branchId, int positionId)
        {
            Id = id;
            Sex = sex;
            Name = name;
            DayOfBirth = dayOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            CitizenIdentity = citizenIdentity;
            BranchId = branchId;
            PositionId = positionId;
        }
    }
}
