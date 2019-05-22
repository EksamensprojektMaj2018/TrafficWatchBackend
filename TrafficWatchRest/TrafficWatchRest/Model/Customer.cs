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
        public Customer(int id, string googleId, string email, string firstName, string lastName, bool admin)
        {
            _id = id;
            _googleId = googleId;
            _email = email;
            _firstName = firstName;
            _lastName = lastName;
            _admin = admin;
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