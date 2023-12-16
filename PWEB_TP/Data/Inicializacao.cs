using Microsoft.AspNetCore.Identity;
using TP_PWEB.Models;
using PWEB_TP.Models;
using System;
using System.Threading.Tasks;
using System.Data;

namespace TP_PWEB.Data
{
    public enum Roles
    {
        Admin,
        Gestor,
        Funcionario,
        Cliente
    }
    public static class Inicializacao
    {
        public static async Task CriaDadosIniciais(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Adicionar default Roles
            await CriarRoleSeNaoExistir(roleManager, Roles.Admin.ToString());
            await CriarRoleSeNaoExistir(roleManager, Roles.Gestor.ToString());
            await CriarRoleSeNaoExistir(roleManager, Roles.Funcionario.ToString());
            await CriarRoleSeNaoExistir(roleManager, Roles.Cliente.ToString());

            // Adicionar Default User - Admin
            await CriarUsuarioSeNaoExistir(userManager, "admin@localhost.com", "Is3C..00", "Administrador", "Local", Roles.Admin, Roles.Gestor);

            // Adicionar Default User - Gestor
            await CriarUsuarioSeNaoExistir(userManager, "gestor@localhost.com", "Is3C..01", "Gestor", "Local", Roles.Gestor);

            // Adicionar Default User - Funcionario
            await CriarUsuarioSeNaoExistir(userManager, "funcionario@localhost.com", "Is3C..02", "Funcionario", "Local", Roles.Funcionario);

            // Adicionar Default User - Cliente
            await CriarUsuarioSeNaoExistir(userManager, "cliente@localhost.com", "Is3C..03", "Cliente", "Local", Roles.Cliente);
        }

        private static async Task CriarRoleSeNaoExistir(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        private static async Task CriarUsuarioSeNaoExistir(UserManager<ApplicationUser> userManager, string email, string senha, string primeiroNome, string ultimoNome, params Roles[] roles)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                var novoUsuario = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    PrimeiroNome = primeiroNome,
                    UltimoNome = ultimoNome,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                await userManager.CreateAsync(novoUsuario, senha);
                // Adiciona o usuário a cada uma das roles fornecidas
                foreach (var role in roles)
                {
                    await userManager.AddToRoleAsync(novoUsuario, role.ToString());
                }
            }
        }

    }
}
