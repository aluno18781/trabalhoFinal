using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using noticiasAuto.Models;
using Owin;

namespace IdentitySample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            initApp();
        }
        private void initApp()
        {

            ApplicationDbContext db = new ApplicationDbContext();

            var adminUser = new utilizadores();
            var jornalistaUser = new utilizadores();
            var userComum = new utilizadores();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Admin'
            if (!roleManager.RoleExists("Admin"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Jornalista"))
            {
                
                var role = new IdentityRole();
                role.Name = "Jornalista";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("UserComum"))
            {
                
                var role = new IdentityRole();
                role.Name = "UserComum";
                roleManager.Create(role);
            }



            // criar um utilizador 'Admin'
            var admin = new ApplicationUser();
            admin.UserName = "admin@ipt.pt";
            admin.Email = "admin@ipt.pt";

            string userPWD = "123_Asd";
            var chkAdmin = userManager.Create(admin, userPWD);

            adminUser.Nome = "Administrador";
            adminUser.Email = "admin@ipt.pt";


            db.utilizadores.Add(adminUser);

            
            if (chkAdmin.Succeeded)
            {
                var result1 = userManager.AddToRole(admin.Id, "Admin");
            }

            // criar um utilizador 'Jornalista'
            var jornalista = new ApplicationUser();
            jornalista.UserName = "jornalista@ipt.pt";
            jornalista.Email = "jornalista@ipt.pt";

            string jornalistaPWD = "123_Asd";
            var chkJornalista = userManager.Create(jornalista, jornalistaPWD);

            jornalistaUser.Nome = "Jornalista";
            jornalistaUser.Email = "jornalista@ipt.pt";

            db.utilizadores.Add(jornalistaUser);

              
            if (chkJornalista.Succeeded)
            {
                var result2 = userManager.AddToRole(jornalista.Id, "Jornalista");
            }


            // criar um utilizador 'Jornalista'
            var utilizadorComum = new ApplicationUser();
            utilizadorComum.UserName = "userComum@ipt.pt";
            utilizadorComum.Email = "userComum@ipt.pt";

            string userComumPWD = "123_Asd";
            var chkUserComum = userManager.Create(utilizadorComum, userComumPWD);

            userComum.Nome = "Utilizador Comum";
            userComum.Email = "userComum@ipt.pt";

            db.utilizadores.Add(userComum);

            
            if (chkJornalista.Succeeded)
            {
                var result3 = userManager.AddToRole(utilizadorComum.Id, "UserComum");
            }
        }
    }
}
