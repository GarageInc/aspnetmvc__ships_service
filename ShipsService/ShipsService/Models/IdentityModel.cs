
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipService.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using ShipsService.Models;

    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        
        [Display(Name = "Аватарка")]
        public virtual ICollection<Document> Avatar { get; set; }

        [Display(Name = "Документы")]
        public virtual ICollection<Document> ShipsDocuments { get; set; }

        [Display(Name = "Дата регистрации")]
        public virtual DateTime RegistrationDate { get; set; }

        [Display(Name = "О себе")]
        public virtual string UserInfo { get; set; }
        
        [Display(Name = "Заблокирован?")]
        public virtual bool IsBlocked { get; set; }

        [Display(Name = "Дата блокировки")]
        public virtual DateTime BlockDate { get; set; }

        [Display(Name = "Причина блокировки")]
        public virtual string BlockReason { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }


    }

}