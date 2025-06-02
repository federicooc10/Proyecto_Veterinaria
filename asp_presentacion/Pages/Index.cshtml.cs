using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lib_presentaciones.Interfaces;
namespace asp_presentacion.Pages
{

    public class IndexModel : PageModel
    {
        // Estado de sesi�n del usuario
        public bool EstaLogueado = false;


        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Contrasena { get; set; }

        private IUsuariosPresentacion? iUsuariosPresentacion = null;
        public IndexModel(IUsuariosPresentacion iUsuariosPresentacion)
        {
            try
            {
                this.iUsuariosPresentacion = iUsuariosPresentacion;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }


        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");

            if (!string.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        // Acci�n para limpiar los campos del formulario
        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contrasena = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        // Acci�n que se ejecuta al presionar el bot�n "Entrar"
        public void OnPostBtEnter()
        {
            try
            {

                if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Contrasena))
                {
                    OnPostBtClean();
                    return;
                }

                var task = iUsuariosPresentacion!.PorEmail(new lib_dominio.Entidades.Usuarios()
                {
                    Email = Email
                });
                task.Wait();
                var usuario = task.Result.FirstOrDefault();


                if (usuario == null || usuario.Contrase�a != Contrasena)
                {
                    OnPostBtClean();
                    return;
                }

                // Si todo es correcto, guardar sesi�n
                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", usuario.Id.ToString());
                HttpContext.Session.SetString("Rol", usuario._Rol!.Nombre!);
                EstaLogueado = true;

                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        // Acci�n que se ejecuta al presionar el bot�n "Cerrar sesi�n"
        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}