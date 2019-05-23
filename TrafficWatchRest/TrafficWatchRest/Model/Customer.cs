using System;
using System.Collections.Generic;

namespace TrafficWatchRest.Model
{
    public partial class Customer
    {
        private int _id;
        private string _googleId;
        private string _email;
        private string _firstName;
        private string _lastName;
        private bool _admin;
        public Customer(int Id, string GoogleId, string Email, string FirstName, string LastName, bool Admin)
        {
            _id = Id;
            _googleId = GoogleId;
            _email = Email;
            _firstName = FirstName;
            _lastName = LastName;
            _admin = Admin;
        }

        public int Id { get; set; }
        public string GoogleId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AddressId { get; set; }
        public int? AlarmId { get; set; }
        public int? RouteId { get; set; }
        public bool? Administrator { get; set; }
    }
}