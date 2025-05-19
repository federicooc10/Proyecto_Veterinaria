using System.ComponentModel.DataAnnotations.Schema;
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
        private IMascotasPresentacion? IMascotasPresentacion = null;
        private IClientesPresentacion? IClientesPresentacion = null;
        private IFormulasPresentacion? IFormulasPresentacion = null;
        private IVeterinariosPresentacion? IVeterinariosPresentacion = null;

        public Historiales_ClinicosModel(IHistoriales_ClinicosPresentacion iPresentacion,
            IMascotasPresentacion IMascotasPresentacion,
            IClientesPresentacion IClientesPresentacion,
            IFormulasPresentacion IFormulasPresentacion,
            IVeterinariosPresentacion IVeterinariosPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.IMascotasPresentacion = IMascotasPresentacion;
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
        [BindProperty] public List<Mascotas>? Mascotas { get; set; }
        [BindProperty] public List<Clientes>? Clientes { get; set; }
        [BindProperty] public List<Formulas>? Formulas { get; set; }
        [BindProperty] public List<Veterinarios>? Veterinarios { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

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

                Filtro!.Codigo = Filtro!.Codigo ?? "";

                Accion = Enumerables.Ventanas.Listas;

                var task = this.iPresentacion!.PorCodigo(Filtro!);
                task.Wait();
                Lista = task.Result;
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
                var task = this.IMascotasPresentacion!.Listar();
                task.Wait();
                Mascotas = task.Result;

                var task1 = this.IClientesPresentacion!.Listar();
                task1.Wait();
                Clientes = task1.Result;

                var task2 = this.IFormulasPresentacion!.Listar();
                task2.Wait();
                Formulas = task2.Result;

                var task3 = this.IVeterinariosPresentacion!.Listar();
                task3.Wait();
                Veterinarios = task3.Result;

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
    }
}