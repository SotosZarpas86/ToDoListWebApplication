using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class TasksModel
    {
        public int ID { get; set; }
        public Guid TaskID { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "A title is required")]
        public string Title { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "A description is required")]
        public string Description { get; set; }

        [DisplayName("Date Added")]
        public DateTime DateAdded { get; set; }

        [DisplayName("Date Updated")]
        public DateTime DateUpdated { get; set; }

        public bool Status { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
