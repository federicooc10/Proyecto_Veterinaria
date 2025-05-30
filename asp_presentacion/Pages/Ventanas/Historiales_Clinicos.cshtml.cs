using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class Historiales_ClinicosModel : PageModel
    {
        private IHistoriales_ClinicosPresentacion? iPresentacion = null;
        private IClientesPresentacion? IClientesPresentacion = null;
        private IFormulasPresentacion? IFormulasPresentacion = null;
        private IVeterinariosPresentacion? IVeterinariosPresentacion = null;
        public bool EstaLogueado = false;

        public Historiales_ClinicosModel(
            IHistoriales_ClinicosPresentacion iPresentacion,
            IClientesPresentacion IClientesPresentacion,
            IFormulasPresentacion IFormulasPresentacion,
            IVeterinariosPresentacion IVeterinariosPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.IClientesPresentacion = IClientesPresentacion;
                this.IFormulasPresentacion = IFormulasPresentacion;
                this.IVeterinariosPresentacion = IVeterinariosPresentacion;
                Filtro = new Historiales_Clinicos();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Historiales_Clinicos? Actual { get; set; }
        [BindProperty] public Historiales_Clinicos? Filtro { get; set; }
        [BindProperty] public List<Historiales_Clinicos>? Lista { get; set; }
        [BindProperty] public List<Clientes>? Clientes { get; set; }
        [BindProperty] public List<Formulas>? Formulas { get; set; }
        [BindProperty] public List<Veterinarios>? Veterinarios{ get; set; }

        public virtual void OnGet()
        {

            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Accion = Enumerables.Ventanas.Listas;

                    if (Filtro == null || string.IsNullOrWhiteSpace(Filtro.Codigo))
                    {
                    var task = this.iPresentacion!.Listar();
                    task.Wait();
                    Lista = task.Result;
                }
                else
                {
                    var task = this.iPresentacion!.PorCodigo(Filtro);
                    task.Wait();
                    Lista = task.Result;
                }

                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }


        private void CargarCombox()
        {
            try
            {
                var taskClientes = this.IClientesPresentacion!.Listar();
                var taskFormulas = this.IFormulasPresentacion!.Listar();
                var taskVeterinarios = this.IVeterinariosPresentacion!.Listar();

                Task.WaitAll(taskClientes, taskFormulas, taskVeterinarios);

                Clientes = taskClientes.Result;
                Formulas = taskFormulas.Result;
                Veterinarios = taskVeterinarios.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new Historiales_Clinicos();
                CargarCombox();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                CargarCombox();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;

                Task<Historiales_Clinicos>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!)!;
                else
                    task = this.iPresentacion!.Modificar(Actual!)!;
                task.Wait();

                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = this.iPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

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
