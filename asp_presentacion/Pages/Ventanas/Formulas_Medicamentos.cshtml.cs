using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class Formulas_MedicamentosModel : PageModel
    {
        private IFormulas_MedicamentosPresentacion? iPresentacion = null;
        private IFormulasPresentacion? IFormulasPresentacion = null;
        private IMedicamentosPresentacion? IMedicamentosPresentacion = null;
        public bool EstaLogueado = false;

        public Formulas_MedicamentosModel(
            IFormulas_MedicamentosPresentacion iPresentacion,
            IFormulasPresentacion IFormulasPresentacion,
            IMedicamentosPresentacion IMedicamentosPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.IFormulasPresentacion = IFormulasPresentacion;
                this.IMedicamentosPresentacion = IMedicamentosPresentacion;
                Filtro = new Formulas_Medicamentos
                {
                    _Formula = new Formulas()
                };


            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Formulas_Medicamentos? Actual { get; set; }
        [BindProperty] public Formulas_Medicamentos? Filtro { get; set; }
        [BindProperty] public List<Formulas_Medicamentos>? Lista { get; set; }
        [BindProperty] public List<Formulas>? Formulas { get; set; }
        [BindProperty] public List<Medicamentos>? Medicamentos { get; set; }

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

                var task = this.iPresentacion!.Listar();
                task.Wait();
                var listaCompleta = task.Result;

                if (!string.IsNullOrWhiteSpace(Filtro!._Formula?.Codigo))
                {
                    listaCompleta = listaCompleta
                        .Where(x => x._Formula != null &&
                                    x._Formula.Codigo != null &&
                                    x._Formula.Codigo.Contains(Filtro._Formula.Codigo, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                Lista = listaCompleta;


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
                var taskFormulas = this.IFormulasPresentacion!.Listar();
                var taskMedicamentos = this.IMedicamentosPresentacion!.Listar();

                Task.WaitAll(taskFormulas, taskMedicamentos);

                Formulas = taskFormulas.Result;
                Medicamentos = taskMedicamentos.Result;
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
                Actual = new Formulas_Medicamentos();
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

                Task<Formulas_Medicamentos>? task = null;
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
