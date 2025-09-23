using System;
using System.ComponentModel.DataAnnotations;

namespace NoteWiki.Models
{
    public class UserModel
    {

        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        [Key]
        public Guid UserID { get; set; }
        public UserModel() { }

        public UserModel(string email, string name)
        {
            Email = email;
            Name = name;
            UserID = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }


    }
}
