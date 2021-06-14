﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestApi.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public List<Entity> Entities { get; set; }
    }
}
