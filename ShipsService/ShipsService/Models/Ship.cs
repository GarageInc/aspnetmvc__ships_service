
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipsService.Models
{
    using ShipsService.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Ship : BaseModel
    {
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        public virtual string Name { get; set; }

        [Display(Name = "Описание")]
        public virtual string Description { get; set; }
        
        [Display(Name = "Файлы")]
        public virtual ICollection<Document> ShipsDocuments { get; set; }
        
        [Display(Name = "ID Автора")]
        public virtual string AuthorId { get; set; }

        [Display(Name = "Автор")]
        public virtual ApplicationUser Author { get; set; }
             
    }


}