using System;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Entity;
using Microsoft.AspNet.Identity.Security;
using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;

namespace MusicStore.Models
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IServiceProvider services, IUserStore<ApplicationUser> store, IOptionsAccessor<IdentityOptions> optionsAccessor) : base(services, store, optionsAccessor) { }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IServiceProvider services, IRoleStore<IdentityRole> store) : base(services, store) { }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUserManager, ApplicationUser>
    {
        public ApplicationSignInManager(ApplicationUserManager manager, IContextAccessor<HttpContext> contextAccessor) : base(manager, contextAccessor) { }
    }

    public class ApplicationUser : User { }

    public class ApplicationDbContext : IdentitySqlContext<ApplicationUser> 
    {
        public ApplicationDbContext(IServiceProvider services) : base(services) { }

        protected override void OnConfiguring(DbContextOptions builder)
        {
            // TODO: pull connection string from config
            builder.UseSqlServer(@"Server=(localdb)\v11.0;Database=MusicStoreIdentity;Trusted_Connection=True;");
        }
    }
}