﻿
namespace ShipsService.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Document : BaseModel
    {
        [Display(Name = "Ссылка")]
        public virtual string Url { get; set; }

        [Display(Name = "Размер")]
        public virtual int Size { get; set; }

        [Display(Name = "Расширение")]
        public virtual string Type { get; set; }
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата создания")]
        public virtual DateTime Deadline { get; set; }

        [Display(Name = "Статус")]
        public int Status { get; set; }
        
        [Display(Name = "ID Автора")]
        public virtual string AuthorId { get; set; }

        [Display(Name = "Автор")]
        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }
    }


    // Перечисление для статуса задачи
    public enum DocumentStatus
    {
        Open = 1,
        Distributed = 2,
        Proccesing = 3,
        Closed = 4
    }


}