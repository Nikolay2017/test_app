using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;

namespace WebApi.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Здесь добавьте настраиваемые утверждения пользователя
            return userIdentity;
        }
    }
    public class MyUserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public double Mony { get; set; }
    }
    public class MyUserInfoHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public double Balans { get; set; }
        public double Summa_Perev { get; set; }
        public DateTime Date { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<WebApi.Models.MyUserInfo> MyUserInfoes { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.MyUserInfoHistory> MyUserInfoHistories { get; set; }
    }
}