using System;
using System.ComponentModel.DataAnnotations;

namespace RestApi.DataAccess.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public string ToDo { get; set; }
        public DateTime Time { get; set; }
        public int? UserId { get; set; }
    }
}