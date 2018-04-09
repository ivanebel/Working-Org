using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Working_Org
{
    public class Extras
    {
        //private proveedorEntities _entities;
        public Color COLOR_BLUE_REGULAR = Color.FromArgb(33, 150, 243);
        public Color COLOR_BLUE_DARK = Color.FromArgb(0, 105, 192);
        public Color COLOR_BLUE_LIGHT = Color.FromArgb(110, 198, 255);

        public Color COLOR_RED_REGULAR = Color.FromArgb(244, 67, 54);
        public Color COLOR_RED_DARK = Color.FromArgb(186, 0, 13);
        public Color COLOR_RED_LIGHT = Color.FromArgb(255, 121, 97);

        public Extras()
        {

        }

        #region FUNCIONES

        public long GetId(string str)
        {
            string[] s = str.Split('.');
            return long.Parse(s[0]);
        }

        public DateTime GetFecha_Dia(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        public string GetCD_Direccion(long index)
        {
            switch (index)
            {
                case 501:
                    return "AV. SAN MARTIN 4901, FLORIDA, V. LÓPEZ, BA";
                case 503:
                    return "GUATAMBÚ 1841, BURZACO, BA";
                case 506:
                    return "CANILLITA S/N, MANZ. 2, B° TORINO, CDAD. DE SALTA, SALTA";
                case 509:
                    return "CARLOS B. PATAT 1350, CNIA. AVELLANEDA, PARANÁ, ER";
                case 510:
                    return "CNEL. BOSCH 302, AVELLANEDA, BA";
                case 511:
                    return "ING. EIFEL 4250, ÁREA EL TRIÁNGULO, TORTUGUITAS, BA";
                default:
                    return "";
            }
        }

        public void LoopControls(bool val, Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is Panel || c is GroupBox)
                {
                    LoopControls(val, c);
                }
                else
                {
                    //c.Enabled = val;
                    c.BackColor = Color.FromArgb(33, 150, 243);
                }
            }
        }

        public List<Tipos> GetTipos(string clasificacion)
        {
            using (var db = new proveedorEntities())
            {
                List<Tipos> lista = new List<Tipos>();

                try
                {
                    lista = (from t in db.Tipos
                             where t.Clasificacion == clasificacion
                             select t).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }

        //public Tipos GetTipo(Proveedor proveedor)
        //{

        //}
        public void TryConnection()
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    int i = db.Productoes.Count();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region PRODUCTO
        public List<Producto> GetProductos()
        {
            using (var db = new proveedorEntities())
            {
                List<Producto> lista = new List<Producto>();

                try
                {
                    lista = (from producto in db.Productoes
                             select producto).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Producto> GetProductos(string tipo, bool isNegative)
        {
            using (var db = new proveedorEntities())
            {
                List<Producto> lista = new List<Producto>();

                try
                {
                    if (!isNegative)
                        lista = (from producto in db.Productoes
                                 where producto.TipoProducto == tipo
                                 select producto).ToList();

                    else if (isNegative)
                        lista = (from producto in db.Productoes
                                 where producto.TipoProducto != tipo
                                 select producto).ToList();

                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Producto> GetProductos(Proveedor proveedor)
        {
            using (var db = new proveedorEntities())
            {
                List<Producto> lista = new List<Producto>();

                List<ProductoProveedor> listaPP = new List<ProductoProveedor>();


                try
                {
                    listaPP = (from pp in db.ProductoProveedors
                               where pp.IdProveedor == proveedor.Id
                               select pp).ToList();

                    foreach (ProductoProveedor ppx in listaPP)
                    {
                        Producto producto = new Producto();
                        producto = (from prod in db.Productoes
                                    where prod.Id == ppx.IdProducto
                                    select prod).SingleOrDefault();
                        lista.Add(producto);
                    }

                    db.Dispose();


                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public Producto GetProducto(Producto producto)
        {
            using (var db = new proveedorEntities())
            {
                Producto prod = new Producto();

                try
                {
                    prod = (from p in db.Productoes
                            where p.Id == producto.Id
                            select p).SingleOrDefault();
                    db.Dispose();

                    return prod;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return prod;
                }
            }
        }
        public string GetProducto_Nombre(Producto producto)
        {
            using (var db = new proveedorEntities())
            {
                Producto prod = new Producto();

                try
                {
                    prod = (from p in db.Productoes
                            where p.Id == producto.Id
                            select p).SingleOrDefault();
                    db.Dispose();

                    return prod.Nombre;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }
            }
        }
        public long GetProducto_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.Productoes.Count() != 0)
                    {
                        maxId = db.Productoes.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddProducto(Producto producto)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.Productoes.Add(producto);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditProducto(Producto producto) { }

        public decimal GetProducto_Stock(Producto producto)
        {
            using (var db = new proveedorEntities())
            {
                decimal stock = 0;
                List<MovimientoProducto> list;

                try
                {
                    list = (from mov in db.MovimientoProductoes
                            where mov.IdProducto == producto.Id
                            select mov).ToList();
                    db.Dispose();

                    foreach (MovimientoProducto movimiento in list)
                    {
                        stock += movimiento.Cantidad;
                    }

                    return stock;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return stock;
                }
            }
        }
        public decimal GetProducto_Peso(Producto producto)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    Producto oProducto = (from p in db.Productoes
                                          where p.Id == producto.Id
                                          select p).SingleOrDefault();
                    db.Dispose();

                    return oProducto.PesoNeto;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public PrecioProducto GetProducto_UltimoPrecio(Producto producto)
        {
            using (var db = new proveedorEntities())
            {
                List<PrecioProducto> list;
                PrecioProducto precio = new PrecioProducto() { Precio = 0 };

                try
                {
                    if (db.PrecioProductoes.Count() != 0)
                    {
                        list = (from p in db.PrecioProductoes
                                where p.IdProducto == producto.Id
                                orderby p.Fecha descending
                                select p).ToList();
                        db.Dispose();

                        if (list.Count != 0)
                            precio = list[0];
                        else
                            precio = null;
                    }

                    return precio;

                    
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return precio;
                }
            }
        }
        public List<PrecioProducto> GetProducto_ListaPrecios(Producto producto)
        {
            using (var db = new proveedorEntities())
            {
                List<PrecioProducto> list = new List<PrecioProducto>();
                
                try
                {
                    if (db.PrecioProductoes.Count() != 0)
                    {
                        list = (from p in db.PrecioProductoes
                                where p.IdProducto == producto.Id
                                orderby p.Fecha descending
                                select p).ToList();
                        db.Dispose();

                    }

                    return list;


                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return list;
                }
            }
        }
        public decimal GetProducto_RelacionProducto(Producto materiaPrima, Producto producto)
        {
            using (var db = new proveedorEntities())
            {
                List<ListaFabricacion> listaFabricacion = new List<ListaFabricacion>();

                try
                {
                    listaFabricacion = (from l in db.ListaFabricacions
                                        where l.IdProducto == producto.Id && l.Estado == "VIGENTE" && l.IdMateriaPrima == materiaPrima.Id
                                        orderby l.Fecha descending
                                        select l).ToList();

                    ListaFabricacion lista = listaFabricacion[0];
                    DetalleListaFabricacion detalle = new DetalleListaFabricacion();

                    detalle = (from d in db.DetalleListaFabricacions
                               where d.IdListaFabricacion == lista.Id && d.IdProducto == materiaPrima.Id
                               select d).SingleOrDefault();

                    db.Dispose();

                    return detalle.Cantidad;

                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }

        public ListaFabricacion GetListaComponentes(Producto materiaPrima, Producto producto)
        {
            using (var db = new proveedorEntities())
            {
                List<ListaFabricacion> listaFabricacion = new List<ListaFabricacion>();

                try
                {
                    listaFabricacion = (from l in db.ListaFabricacions
                                        where l.IdProducto == producto.Id && l.Estado == "VIGENTE" && l.IdMateriaPrima == materiaPrima.Id
                                        orderby l.Fecha descending
                                        select l).ToList();
                    db.Dispose();

                    return listaFabricacion[0];
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return new ListaFabricacion();
                }
            }
        }

        public List<DetalleListaFabricacion> GetProducto_DetalleFabricacion(ListaFabricacion listaFabricacion)
        {
            using (var db = new proveedorEntities())
            {
                List<DetalleListaFabricacion> list = new List<DetalleListaFabricacion>();

                try
                {
                    list = (from l in db.DetalleListaFabricacions
                            where l.IdListaFabricacion == listaFabricacion.Id
                            select l).ToList();
                    db.Dispose();

                    return list;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return list;
                }
            }
        }
        #endregion

        #region MOVIMIENTOPRODUCTO
        public List<MovimientoProducto> GetMovimientosProductos()
        {
            using (var db = new proveedorEntities())
            {
                List<MovimientoProducto> lista = new List<MovimientoProducto>();

                try
                {
                    lista = (from mov in db.MovimientoProductoes
                             orderby mov.Fecha descending
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<MovimientoProducto> GetMovimientosProductos(Producto producto)
        {
            using (var db = new proveedorEntities())
            {
                IList<MovimientoProducto> lista = new List<MovimientoProducto>();

                try
                {
                    lista = (from mov in db.MovimientoProductoes
                             where mov.IdProducto == producto.Id
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<MovimientoProducto> GetMovimientosProductos(string tipoMovimiento)
        {
            using (var db = new proveedorEntities())
            {
                IList<MovimientoProducto> lista = new List<MovimientoProducto>();

                try
                {
                    lista = (from mov in db.MovimientoProductoes
                             where mov.TipoMovimiento == tipoMovimiento
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<MovimientoProducto> GetMovimientosProductos(DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                IList<MovimientoProducto> lista = new List<MovimientoProducto>();

                try
                {
                    lista = (from mov in db.MovimientoProductoes
                             where DateTime.Parse(mov.Fecha) >= fechaini && DateTime.Parse(mov.Fecha) <= fechafin
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<MovimientoProducto> GetMovimientosProductos(Producto producto, DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                IList<MovimientoProducto> lista = new List<MovimientoProducto>();

                try
                {
                    lista = (from mov in db.MovimientoProductoes
                             where mov.IdProducto == producto.Id && DateTime.Parse(mov.Fecha) >= fechaini && DateTime.Parse(mov.Fecha) <= fechafin
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<MovimientoProducto> GetMovimientosProductos(Producto producto, string tipoMovimiento)
        {
            using (var db = new proveedorEntities())
            {
                IList<MovimientoProducto> lista = new List<MovimientoProducto>();

                try
                {
                    lista = (from mov in db.MovimientoProductoes
                             where mov.IdProducto == producto.Id && mov.TipoMovimiento == tipoMovimiento
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public MovimientoProducto GetMovimientoProducto(MovimientoProducto movimiento)
        {
            using (var db = new proveedorEntities())
            {
                MovimientoProducto oMovimiento = new MovimientoProducto();

                try
                {
                    oMovimiento = (from mov in db.MovimientoProductoes
                                   where mov.Id == movimiento.Id
                                   select mov).SingleOrDefault();
                    db.Dispose();

                    return oMovimiento;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oMovimiento;
                }
            }
        }
        public long GetMovimientoProducto_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.MovimientoProductoes.Count() != 0)
                    {
                        maxId = db.MovimientoProductoes.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddMovimientoProducto(MovimientoProducto movimiento)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.MovimientoProductoes.Add(movimiento);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void AddMovimientoProducto(List<MovimientoProducto> listaMovimientos)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    foreach (MovimientoProducto mov in listaMovimientos)
                    {
                        db.MovimientoProductoes.Add(mov);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditMovimientoProducto(MovimientoProducto movimiento) { }
        #endregion


        #region PRODUCCION

        //public List<ProduccionDiaria> GetProducciones() { }
        //public List<ProduccionDiaria> GetProducciones(Producto producto) { }
        //public List<ProduccionDiaria> GetProducciones(DateTime fechaini, DateTime fechafin) { }
        //public ProduccionDiaria GetProduccion(ProduccionDiaria produccion) { }
        public long GetProduccion_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.ProduccionDiarias.Count() != 0)
                    {
                        maxId = db.ProduccionDiarias.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddProduccion(ProduccionDiaria produccion)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.ProduccionDiarias.Add(produccion);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditProduccion(ProduccionDiaria produccion) { }


        #endregion

        #region PROVEEDOR
        public List<Proveedor> GetProveedores()
        {
            using (var db = new proveedorEntities())
            {
                List<Proveedor> lista = new List<Proveedor>();

                try
                {
                    lista = (from p in db.Proveedors
                             select p).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Proveedor> GetProveedores(Producto producto)
        {
            using (var db = new proveedorEntities())
            {
                List<Proveedor> lista = new List<Proveedor>();

                try
                {
                    lista = (from p in db.Proveedors join pp in db.ProductoProveedors on p.Id equals pp.IdProveedor
                             where pp.IdProducto == producto.Id
                             select p).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Proveedor> GetProveedores(string tipo, bool isNegative)
        {
            using (var db = new proveedorEntities())
            {
                List<Proveedor> lista = new List<Proveedor>();

                try
                {
                    if (!isNegative)
                        lista = (from p in db.Proveedors
                                 where p.TipoProveedor == tipo
                                 select p).ToList();

                    else if (isNegative)
                        lista = (from p in db.Proveedors
                                 where p.TipoProveedor != tipo
                                 select p).ToList();

                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public Proveedor GetProveedor(Proveedor proveedor)
        {
            using (var db = new proveedorEntities())
            {
                Proveedor oProveedor = new Proveedor();

                try
                {
                    oProveedor = (from p in db.Proveedors
                                  where p.Id == proveedor.Id
                                  select p).SingleOrDefault();
                    db.Dispose();

                    return oProveedor;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oProveedor;
                }
            }
        }
        public long GetProveedor_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.Proveedors.Count() != 0)
                    {
                        maxId = db.Proveedors.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }

        public void AddProveedor(Proveedor proveedor)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.Proveedors.Add(proveedor);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditProveedor(Proveedor proveedor)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    Proveedor oProveedor = (from p in db.Proveedors
                                            where p.Id == proveedor.Id
                                            select p).SingleOrDefault();

                    oProveedor.Id = proveedor.Id;
                    oProveedor.Nombre = proveedor.Nombre;
                    oProveedor.CUIT = proveedor.CUIT;
                    oProveedor.TipoProveedor = proveedor.TipoProveedor;
                    oProveedor.Email = proveedor.Email;
                    oProveedor.Telefono = proveedor.Telefono;
                    oProveedor.Observaciones = proveedor.Observaciones;

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public decimal GetProveedor_Saldo(Proveedor proveedor)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    List<MovimientoProveedor> listaMovimientos = new List<MovimientoProveedor>();

                    listaMovimientos = (from mov in db.MovimientoProveedors
                                        where mov.IdProveedor == proveedor.Id
                                        select mov).ToList();

                    db.Dispose();

                    decimal credito = 0;
                    decimal debito = 0;

                    foreach(MovimientoProveedor movimiento in listaMovimientos)
                    {
                        if (movimiento.CreditoDebito == "DEBITO")
                            debito += movimiento.Monto;
                        else if (movimiento.CreditoDebito == "CREDITO")
                            credito += movimiento.Monto;
                    }


                    return (debito - credito);
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
                catch (InvalidCastException ex)
                {
                    //MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        #endregion

        #region MOVIMIENTOPROVEEDOR
        public List<MovimientoProveedor> GetMovimientoProveedores()
        {
            using (var db = new proveedorEntities())
            {
                List<MovimientoProveedor> lista = new List<MovimientoProveedor>();

                try
                {
                    lista = (from mov in db.MovimientoProveedors
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<MovimientoProveedor> GetMovimientoProveedores(Proveedor proveedor)
        {
            using (var db = new proveedorEntities())
            {
                List<MovimientoProveedor> lista = new List<MovimientoProveedor>();

                try
                {
                    lista = (from mov in db.MovimientoProveedors
                             where mov.IdProveedor == proveedor.Id
                             orderby mov.Fecha descending
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<MovimientoProveedor> GetMovimientoProveedores(DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<MovimientoProveedor> lista = new List<MovimientoProveedor>();

                try
                {
                    lista = (from mov in db.MovimientoProveedors
                             where DateTime.Parse(mov.Fecha) >= fechaini && DateTime.Parse(mov.Fecha) <= fechafin
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<MovimientoProveedor> GetMovimientoProveedores(Proveedor proveedor, DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<MovimientoProveedor> lista = new List<MovimientoProveedor>();

                try
                {
                    lista = (from mov in db.MovimientoProveedors
                             where mov.IdProveedor == proveedor.Id && DateTime.Parse(mov.Fecha) >= fechaini && DateTime.Parse(mov.Fecha) <= fechafin
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public MovimientoProveedor GetMovimientoProveedor(MovimientoProveedor movimiento)
        {
            using (var db = new proveedorEntities())
            {
                MovimientoProveedor oMovimiento = new MovimientoProveedor();

                try
                {
                    oMovimiento = (from mov in db.MovimientoProveedors
                                   where mov.Id == movimiento.Id
                                   select mov).SingleOrDefault();
                    db.Dispose();

                    return oMovimiento;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oMovimiento;
                }
            }
        }
        public long GetMovimientoProveedor_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.MovimientoProveedors.Count() != 0)
                    {
                        maxId = db.MovimientoProveedors.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddMovimientoProveedor(MovimientoProveedor movimiento)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.MovimientoProveedors.Add(movimiento);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch(System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void AddMovimientoProveedor(List<MovimientoProveedor> listaMovimientos)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    foreach (MovimientoProveedor mov in listaMovimientos)
                    {
                        db.MovimientoProveedors.Add(mov);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditMovimientoProveedor(MovimientoProveedor movimiento) { }
        #endregion

        #region CLIENTE
        public List<Cliente> GetClientes()
        {
            using (var db = new proveedorEntities())
            {
                List<Cliente> lista = new List<Cliente>();

                try
                {
                    lista = (from c in db.Clientes
                             select c).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<Cliente> GetClientes(string tipo)
        {
            using (var db = new proveedorEntities())
            {
                IList<Cliente> lista = new List<Cliente>();

                try
                {
                    lista = (from c in db.Clientes
                             where c.TipoCliente==tipo
                             select c).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public Cliente GetCliente(Cliente cliente)
        {
            using (var db = new proveedorEntities())
            {
                Cliente oCliente = new Cliente();

                try
                {
                    oCliente = (from c in db.Clientes
                                   where c.Id==cliente.Id
                                   select c).SingleOrDefault();
                    db.Dispose();

                    return oCliente;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oCliente;
                }
            }
        }
        public long GetCliente_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.Clientes.Count() != 0)
                    {
                        maxId = db.Clientes.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddCliente(Cliente cliente)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditCliente(Cliente cliente) { }
        #endregion


        #region MOVIMIENTOCLIENTE

        public List<MovimientoCliente> GetMovimientoClientes()
        {
            using (var db = new proveedorEntities())
            {
                List<MovimientoCliente> lista = new List<MovimientoCliente>();

                try
                {
                    lista = (from mov in db.MovimientoClientes
                             orderby mov.Fecha descending
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<MovimientoCliente> GetMovimientoClientes(Cliente cliente)
        {
            using (var db = new proveedorEntities())
            {
                List<MovimientoCliente> lista = new List<MovimientoCliente>();

                try
                {
                    lista = (from mov in db.MovimientoClientes
                             where mov.IdCliente == cliente.Id
                             orderby mov.Fecha descending
                             select mov).ToList();

                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<MovimientoCliente> GetMovimientoClientes(DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<MovimientoCliente> lista = new List<MovimientoCliente>();

                try
                {
                    lista = (from mov in db.MovimientoClientes
                             where DateTime.Parse(mov.Fecha) >= fechaini && DateTime.Parse(mov.Fecha) <= fechafin
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<MovimientoCliente> GeMovimientoClientes(Cliente cliente, DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<MovimientoCliente> lista = new List<MovimientoCliente>();

                try
                {
                    lista = (from mov in db.MovimientoClientes
                             where mov.IdCliente == cliente.Id && DateTime.Parse(mov.Fecha) >= fechaini && DateTime.Parse(mov.Fecha) <= fechafin
                             orderby mov.Fecha descending
                             select mov).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public MovimientoCliente GetMovimientoCliente(MovimientoCliente movimiento)
        {
            using (var db = new proveedorEntities())
            {
                MovimientoCliente oMovimiento = new MovimientoCliente();

                try
                {
                    oMovimiento = (from mov in db.MovimientoClientes
                                   where mov.Id == movimiento.Id
                                   select mov).SingleOrDefault();
                    db.Dispose();

                    return oMovimiento;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oMovimiento;
                }
            }
        }
        public long GetMovimientoCliente_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.MovimientoClientes.Count() != 0)
                    {
                        maxId = db.MovimientoClientes.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddMovimientoCliente(MovimientoCliente movimiento)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.MovimientoClientes.Add(movimiento);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void AddMovimientoCliente(List<MovimientoCliente> listaMovimientos)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    foreach (MovimientoCliente mov in listaMovimientos)
                    {
                        db.MovimientoClientes.Add(mov);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditMovimientoCliente(MovimientoProveedor movimiento) { }


        #endregion
        #region PEDIDO
        public List<Pedido> GetPedidos()
        {
            using (var db = new proveedorEntities())
            {
                List<Pedido> lista = new List<Pedido>();

                try
                {
                    lista = (from pedido in db.Pedidoes
                            orderby pedido.FechaEmision descending
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Pedido> GetPedidos(string estado, bool isNegative)
        {
            using (var db = new proveedorEntities())
            {
                List<Pedido> lista = new List<Pedido>();

                try
                {
                    if (!isNegative)
                        lista = (from pedido in db.Pedidoes
                                where pedido.Estado == estado
                                orderby pedido.FechaEmision descending
                                select pedido).ToList();

                    else if(isNegative)
                        lista = (from pedido in db.Pedidoes
                                 where pedido.Estado != estado
                                 select pedido).ToList();

                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Pedido> GetPedidos(DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<Pedido> lista = new List<Pedido>();

                try
                {
                    lista = (from pedido in db.Pedidoes
                             where DateTime.Parse(pedido.FechaEntrega) >= fechaini && DateTime.Parse(pedido.FechaEntrega) <= fechafin
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Pedido> GetPedidos(Cliente cliente)
        {
            using (var db = new proveedorEntities())
            {
                List<Pedido> lista = new List<Pedido>();

                try
                {
                    lista = (from pedido in db.Pedidoes
                             where pedido.IdCliente == cliente.Id
                             orderby pedido.FechaEmision descending
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Pedido> GetPedidos(Cliente cliente, string estado)
        {
            using (var db = new proveedorEntities())
            {
                List<Pedido> lista = new List<Pedido>();

                try
                {
                    lista = (from pedido in db.Pedidoes
                             where pedido.IdCliente == cliente.Id && pedido.Estado == estado
                             orderby pedido.FechaEmision descending
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Pedido> GetPedidos(Cliente cliente, DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<Pedido> lista = new List<Pedido>();

                try
                {
                    lista = (from pedido in db.Pedidoes
                             where pedido.IdCliente == cliente.Id && DateTime.Parse(pedido.FechaEntrega) >= fechaini && DateTime.Parse(pedido.FechaEntrega) <= fechafin
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Pedido> GetPedidos(Cliente cliente, string estado, DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<Pedido> lista = new List<Pedido>();

                try
                {
                    lista = (from pedido in db.Pedidoes
                             where pedido.IdCliente == cliente.Id && 
                             pedido.Estado==estado && 
                             DateTime.Parse(pedido.FechaEntrega) >= fechaini && 
                             DateTime.Parse(pedido.FechaEntrega) <= fechafin
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public Pedido GetPedido(Pedido pedido)
        {
            using (var db = new proveedorEntities())
            {
                Pedido oPedido = new Pedido();

                try
                {
                    oPedido = (from p in db.Pedidoes
                            where p.Id == pedido.Id
                            select p).SingleOrDefault();
                    db.Dispose();

                    return oPedido;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oPedido;
                }
            }
        }
        public long GetPedido_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.Pedidoes.Count() != 0)
                    {
                        maxId = db.Pedidoes.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        //public List<decimal> GetCantidadPedida(Pedido pedido)
        //{
        //    using (var db = new proveedorEntities())
        //    {
        //        IList<LineaPedido> lista = new List<LineaPedido>();

        //        List<decimal> cantidades = new List<decimal>();

        //        decimal bultos = 0;
        //        decimal unidades = 0;
        //        decimal kilos = 0;

        //        try
        //        {
        //            lista = (from linea in db.LineaPedidoes
        //                     where linea.IdPedido == pedido.Id
        //                     select linea).ToList();
        //            db.Dispose();
                    
        //            foreach (LineaPedido l in lista)
        //            {
        //                bultos += l.BultosPedidos;
        //                unidades += l.UnidadesPedidas;
        //                kilos += l.KilosPedidos;
        //            }

                    
        //            cantidades.Add(bultos);
        //            cantidades.Add(unidades);
        //            cantidades.Add(kilos);

        //            return cantidades;

        //        }
        //        catch (EntityException ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return cantidades;
        //        }
        //    }
        //}

        //public decimal GetPedido_TotalBultosPedids(Pedido pedido)
        //{
        //    using (var db = new proveedorEntities())
        //    {
        //        List<LineaPedido> lista = new List<LineaPedido>();
                
        //        decimal bultos = 0;
                
        //        try
        //        {
        //            lista = (from linea in db.LineaPedidoes
        //                     where linea.IdPedido == pedido.Id
        //                     select linea).ToList();
        //            db.Dispose();

        //            foreach (LineaPedido l in lista)
        //            {
        //                ////bultos += l.BultosPedidos;
        //            }
                    
        //            return bultos;

        //        }
        //        catch (EntityException ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return bultos;
        //        }
        //    }
        //}

        public void AddPedido(Pedido pedido)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.Pedidoes.Add(pedido);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditPedido(Pedido pedido, bool isReprogramado)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    Pedido oPedido = (from p in db.Pedidoes
                                            where p.Id == pedido.Id
                                            select p).SingleOrDefault();
                    oPedido.Id = pedido.Id;
                    oPedido.IdCliente = pedido.IdCliente;
                    oPedido.OC = pedido.OC;
                    oPedido.CD = pedido.CD;
                    oPedido.FechaEmision = pedido.FechaEmision;
                    oPedido.FechaEntrega = pedido.FechaEntrega;
                    oPedido.HoraEntrega = pedido.HoraEntrega;
                    oPedido.MuelleEntrega = pedido.MuelleEntrega;
                    oPedido.Estado = pedido.Estado;
                    oPedido.Reprogramaciones = pedido.Reprogramaciones;
                    oPedido.Observaciones = pedido.Observaciones;
                    oPedido.Total = pedido.Total;
                    oPedido.Pendiente = pedido.Pendiente;


                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region LINEAPEDIDO
        public List<LineaPedido> GetLineasPedido(Pedido pedido)
        {
            using (var db = new proveedorEntities())
            {
                List<LineaPedido> lista = new List<LineaPedido>();

                try
                {
                    lista = (from l in db.LineaPedidoes
                             where l.IdPedido==pedido.Id
                             select l).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public LineaPedido GetLineaPedido(LineaPedido linea)
        {
            using (var db = new proveedorEntities())
            {
                LineaPedido oLineaPedido = new LineaPedido();

                try
                {
                    oLineaPedido = (from l in db.LineaPedidoes
                               where l.Id == linea.Id
                               select l).SingleOrDefault();
                    db.Dispose();

                    return oLineaPedido;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oLineaPedido;
                }
            }
        }
        public long GetLineaPedido_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.LineaPedidoes.Count() != 0)
                    {
                        maxId = db.LineaPedidoes.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddLineaPedido(LineaPedido linea)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.LineaPedidoes.Add(linea);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void AddLineaPedido(List<LineaPedido> lineas)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    foreach (LineaPedido mov in lineas)
                    {
                        db.LineaPedidoes.Add(mov);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditLineaPedido(LineaPedido linea)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    LineaPedido oLinea = (from l in db.LineaPedidoes
                                          where l.Id == linea.Id
                                          select l).SingleOrDefault();

                    oLinea.Id = linea.Id;
                    oLinea.IdPedido = linea.IdPedido;
                    oLinea.IdProducto = linea.IdProducto;
                    oLinea.Cantidad = linea.Cantidad;
                    oLinea.Pendiente = linea.Pendiente;
                    oLinea.Otro = linea.Otro;
                    //oLinea.BultosPedidos = linea.BultosPedidos;
                    //oLinea.UnidadesPedidas = linea.UnidadesPedidas;
                    //oLinea.KilosPedidos = linea.KilosPedidos;
                    //oLinea.BultosEntregados = linea.BultosEntregados;
                    //oLinea.UnidadesEntregadas = linea.UnidadesEntregadas;
                    //oLinea.KilosEntregados = linea.KilosEntregados;
                    //oLinea.Observaciones = linea.Observaciones;

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        #endregion

        #region ORDENDECOMPRA
        public List<OrdenDeCompra> GetOrdenesDeCompra()
        {
            using (var db = new proveedorEntities())
            {
                List<OrdenDeCompra> lista = new List<OrdenDeCompra>();

                try
                {
                    lista = (from o in db.OrdenDeCompras
                             select o).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<OrdenDeCompra> GetOrdenesDeCompra(Proveedor proveedor)
        {
            using (var db = new proveedorEntities())
            {
                List<OrdenDeCompra> lista = new List<OrdenDeCompra>();

                try
                {
                    lista = (from o in db.OrdenDeCompras
                             where o.IdProveedor == proveedor.Id
                             select o).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<OrdenDeCompra> GetOrdenesDeCompra(string estado)
        {
            using (var db = new proveedorEntities())
            {
                List<OrdenDeCompra> lista = new List<OrdenDeCompra>();

                try
                {
                    lista = (from o in db.OrdenDeCompras
                             where o.Estado == estado
                             select o).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<OrdenDeCompra> GetOrdenesDeCompra(DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<OrdenDeCompra> lista = new List<OrdenDeCompra>();

                try
                {
                    lista = (from o in db.OrdenDeCompras
                             where DateTime.Parse(o.FechaCreacion) >= fechaini && DateTime.Parse(o.FechaCreacion) <= fechafin
                             select o).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<OrdenDeCompra> GetOrdenesDeCompra(Proveedor proveedor, DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<OrdenDeCompra> lista = new List<OrdenDeCompra>();

                try
                {
                    lista = (from o in db.OrdenDeCompras
                             where o.IdProveedor == proveedor.Id && DateTime.Parse(o.FechaCreacion) >= fechaini && DateTime.Parse(o.FechaCreacion) <= fechafin
                             select o).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<OrdenDeCompra> GetOrdenesDeCompra(Proveedor proveedor, string estado)
        {
            using (var db = new proveedorEntities())
            {
                List<OrdenDeCompra> lista = new List<OrdenDeCompra>();

                try
                {
                    lista = (from o in db.OrdenDeCompras
                             where o.IdProveedor == proveedor.Id && o.Estado == estado
                             select o).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<OrdenDeCompra> GetOrdenesDeCompra(Proveedor proveedor, string estado, DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<OrdenDeCompra> lista = new List<OrdenDeCompra>();

                try
                {
                    lista = (from o in db.OrdenDeCompras
                             where o.IdProveedor == proveedor.Id && o.Estado == estado && DateTime.Parse(o.FechaCreacion) >= fechaini && DateTime.Parse(o.FechaCreacion) <= fechafin
                             select o).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public OrdenDeCompra GetOrdenDeCompra(OrdenDeCompra orden)
        {
            using (var db = new proveedorEntities())
            {
                OrdenDeCompra oOrdenDeCompra = new OrdenDeCompra();

                try
                {
                    oOrdenDeCompra = (from o in db.OrdenDeCompras
                               where o.Id == orden.Id
                               select o).SingleOrDefault();
                    db.Dispose();

                    return oOrdenDeCompra;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oOrdenDeCompra;
                }
            }
        }
        public long GetOrdenDeCompra_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.OrdenDeCompras.Count() != 0)
                    {
                        maxId = db.OrdenDeCompras.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddOrdenDeCompra(OrdenDeCompra orden)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.OrdenDeCompras.Add(orden);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditOrdenDeCompra(OrdenDeCompra orden)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    OrdenDeCompra oOrden = (from o in db.OrdenDeCompras
                                            where o.Id == orden.Id
                                            select o).SingleOrDefault();

                    oOrden.Id = orden.Id;
                    oOrden.IdProveedor = orden.IdProveedor;
                    oOrden.IdPresupuesto = orden.IdPresupuesto;
                    oOrden.FechaCreacion = orden.FechaCreacion;
                    oOrden.FechaEntrega = orden.FechaEntrega;
                    oOrden.Estado = orden.Estado;
                    oOrden.Observaciones = orden.Observaciones;

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region LINEAORDENDECOMPRA
        public List<LineaOrdenDeCompra> GetLineasOrdenDeCompra(OrdenDeCompra orden)
        {
            using (var db = new proveedorEntities())
            {
                List<LineaOrdenDeCompra> lista = new List<LineaOrdenDeCompra>();

                try
                {
                    lista = (from l in db.LineaOrdenDeCompras
                             where l.IdOrden == orden.Id
                             select l).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }

        public List<LineaOrdenDeCompra> GetLineasOrdenDeCompra(OrdenDeCompra orden, string estado)
        {
            using (var db = new proveedorEntities())
            {
                List<LineaOrdenDeCompra> lista = new List<LineaOrdenDeCompra>();

                try
                {
                    lista = (from l in db.LineaOrdenDeCompras
                             where l.IdOrden == orden.Id && l.Estado==estado
                             select l).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }

        public LineaOrdenDeCompra GetLineaOrdenDeCompra(LineaOrdenDeCompra linea)
        {
            using (var db = new proveedorEntities())
            {
                LineaOrdenDeCompra oLineaOrdenDeCompra = new LineaOrdenDeCompra();

                try
                {
                    oLineaOrdenDeCompra = (from l in db.LineaOrdenDeCompras
                                           where l.Id == linea.Id
                                    select l).SingleOrDefault();
                    db.Dispose();

                    return oLineaOrdenDeCompra;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oLineaOrdenDeCompra;
                }
            }
        }
        public long GetLineaOrdenDeCompra_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.LineaOrdenDeCompras.Count() != 0)
                    {
                        maxId = db.LineaOrdenDeCompras.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddLineaOrdenDeCompra(LineaOrdenDeCompra linea) { }
        public void AddLineaOrdenDeCompra(List<LineaOrdenDeCompra> lineas)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    foreach (LineaOrdenDeCompra l in lineas)
                    {
                        db.LineaOrdenDeCompras.Add(l);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditLineaOrdenDeCompra(LineaOrdenDeCompra linea) { }
        #endregion

        #region VENTA
        public List<Venta> GetVentas()
        {
            using (var db = new proveedorEntities())
            {
                List<Venta> lista = new List<Venta>();

                try
                {
                    lista = (from pedido in db.Ventas
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<Venta> GetVentas(string estado)
        {
            using (var db = new proveedorEntities())
            {
                IList<Venta> lista = new List<Venta>();

                try
                {
                    lista = (from pedido in db.Ventas
                             where pedido.Estado == estado
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<Venta> GetVentas(DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                IList<Venta> lista = new List<Venta>();

                try
                {
                    lista = (from pedido in db.Ventas
                             where DateTime.Parse(pedido.Fecha) >= fechaini && DateTime.Parse(pedido.Fecha) <= fechafin
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<Venta> GetVentas(Cliente cliente)
        {
            using (var db = new proveedorEntities())
            {
                IList<Venta> lista = new List<Venta>();

                try
                {
                    lista = (from pedido in db.Ventas
                             where pedido.IdCliente == cliente.Id
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<Venta> GetVentas(Cliente cliente, string estado)
        {
            using (var db = new proveedorEntities())
            {
                IList<Venta> lista = new List<Venta>();

                try
                {
                    lista = (from pedido in db.Ventas
                             where pedido.IdCliente == cliente.Id && pedido.Estado == estado
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<Venta> GetVentas(Cliente cliente, DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                IList<Venta> lista = new List<Venta>();

                try
                {
                    lista = (from pedido in db.Ventas
                             where pedido.IdCliente == cliente.Id && DateTime.Parse(pedido.Fecha) >= fechaini && DateTime.Parse(pedido.Fecha) <= fechafin
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<Venta> GetVentas(Cliente cliente, string estado, DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                IList<Venta> lista = new List<Venta>();

                try
                {
                    lista = (from pedido in db.Ventas
                             where pedido.IdCliente == cliente.Id &&
                             pedido.Estado == estado &&
                             DateTime.Parse(pedido.Fecha) >= fechaini &&
                             DateTime.Parse(pedido.Fecha) <= fechafin
                             select pedido).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public Venta GetVenta(Venta venta)
        {
            using (var db = new proveedorEntities())
            {
                Venta oVenta = new Venta();

                try
                {
                    oVenta = (from p in db.Ventas
                              where p.Id == venta.Id
                               select p).SingleOrDefault();
                    db.Dispose();

                    return oVenta;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oVenta;
                }
            }
        }
        public long GetVenta_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.Ventas.Count() != 0)
                    {
                        maxId = db.Ventas.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public decimal GetCantidadVendida(Venta venta)
        {
            using (var db = new proveedorEntities())
            {
                IList<LineaVenta> lista = new List<LineaVenta>();


                decimal bultos = 0;


                try
                {
                    lista = (from linea in db.LineaVentas
                             where linea.IdVenta == venta.Id
                             select linea).ToList();
                    db.Dispose();

                    foreach (LineaVenta l in lista)
                    {
                        bultos += l.Cantidad;
                        //unidades += l.UnidadesPedidas;
                        //kilos += l.KilosPedidos;
                    }


                    

                    return bultos;

                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return bultos;
                }
            }
        }
        public void AddVenta(Venta venta)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.Ventas.Add(venta);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditVenta(Venta pedido) { }
        #endregion

        #region LINEAVENTA
        public IList<LineaVenta> GetLineasVentas(Venta venta)
        {
            using (var db = new proveedorEntities())
            {
                IList<LineaVenta> lista = new List<LineaVenta>();

                try
                {
                    lista = (from l in db.LineaVentas
                             where l.IdVenta == venta.Id
                             select l).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public LineaVenta GetLineaVenta(LineaVenta linea)
        {
            using (var db = new proveedorEntities())
            {
                LineaVenta oLineaVenta = new LineaVenta();

                try
                {
                    oLineaVenta = (from l in db.LineaVentas
                                   where l.Id == linea.Id
                                    select l).SingleOrDefault();
                    db.Dispose();

                    return oLineaVenta;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oLineaVenta;
                }
            }
        }
        public long GetLineaVenta_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.LineaVentas.Count() != 0)
                    {
                        maxId = db.LineaVentas.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddLineaVenta(LineaVenta linea)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.LineaVentas.Add(linea);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void AddLineaVenta(List<LineaVenta> lineas)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    foreach (LineaVenta mov in lineas)
                    {
                        db.LineaVentas.Add(mov);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditLineaVenta(LineaPedido linea) { }
        #endregion

        #region COBRANZA
        public IList<Cobranza> GetCobranzas()
        {
            using (var db = new proveedorEntities())
            {
                IList<Cobranza> lista = new List<Cobranza>();

                try
                {
                    lista = (from c in db.Cobranzas
                             select c).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<Cobranza> GetCobranza(Cliente cliente)
        {
            using (var db = new proveedorEntities())
            {
                IList<Cobranza> lista = new List<Cobranza>();

                try
                {
                    lista = (from c in db.Cobranzas
                             where c.IdCliente == cliente.Id
                             select c).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<Cobranza> GetCobranzas(DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                IList<Cobranza> lista = new List<Cobranza>();

                try
                {
                    lista = (from c in db.Cobranzas
                             where DateTime.Parse(c.Fecha) >= fechaini && DateTime.Parse(c.Fecha) <= fechafin
                             select c).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public IList<Cobranza> GetCobranzas(Cliente cliente, DateTime fechaini, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                IList<Cobranza> lista = new List<Cobranza>();

                try
                {
                    lista = (from c in db.Cobranzas
                             where c.IdCliente == cliente.Id && DateTime.Parse(c.Fecha) >= fechaini && DateTime.Parse(c.Fecha) <= fechafin
                             select c).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public Cobranza GetCobranza(Cobranza cobranza)
        {
            using (var db = new proveedorEntities())
            {
                Cobranza oCobranza = new Cobranza();

                try
                {
                    oCobranza = (from c in db.Cobranzas
                                 where c.Id == cobranza.Id
                              select c).SingleOrDefault();
                    db.Dispose();

                    return oCobranza;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oCobranza;
                }
            }
        }
        public long GetCobranza_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.Cobranzas.Count() != 0)
                    {
                        maxId = db.Cobranzas.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddCobranza(Cobranza cobranza)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.Cobranzas.Add(cobranza);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditCobranza(Cobranza cobranza) { }
        #endregion

        #region LINEACOBRANZA
        public IList<LineaCobranza> GetLineaCobranza(Cobranza cobranza)
        {
            using (var db = new proveedorEntities())
            {
                IList<LineaCobranza> lista = new List<LineaCobranza>();

                try
                {
                    lista = (from l in db.LineaCobranzas
                             where l.IdCobranza == cobranza.Id
                             select l).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public LineaCobranza GetLineaCobranza(LineaCobranza linea)
        {
            using (var db = new proveedorEntities())
            {
                LineaCobranza oLineaCobranza = new LineaCobranza();

                try
                {
                    oLineaCobranza = (from l in db.LineaCobranzas
                                   where l.Id == linea.Id
                                   select l).SingleOrDefault();
                    db.Dispose();

                    return oLineaCobranza;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oLineaCobranza;
                }
            }
        }
        public long GetLineaCobranza_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.LineaCobranzas.Count() != 0)
                    {
                        maxId = db.LineaCobranzas.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddLineaCobranza(LineaCobranza linea)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.LineaCobranzas.Add(linea);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void AddLineaCobranza(List<LineaCobranza> lineas)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    foreach (LineaCobranza mov in lineas)
                    {
                        db.LineaCobranzas.Add(mov);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditLineaCobranza(LineaCobranza linea) { }
        #endregion

        #region REMITO

        public List<Remito> GetRemitos()
        {
            using (var db = new proveedorEntities())
            {
                List<Remito> lista = new List<Remito>();

                try
                {
                    lista = (from r in db.Remitoes
                             select r).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Remito> GetRemitos(Proveedor proveedor)
        {
            using (var db = new proveedorEntities())
            {
                List<Remito> lista = new List<Remito>();

                try
                {
                    lista = (from r in db.Remitoes
                             where r.IdEmisor == proveedor.Id
                             select r).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Remito> GetRemitos(Cliente cliente)
        {
            using (var db = new proveedorEntities())
            {
                List<Remito> lista = new List<Remito>();

                try
                {
                    lista = (from r in db.Remitoes
                             where r.IdDestinatario == cliente.Id
                             select r).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public Remito GetRemito(Remito remito)
        {
            using (var db = new proveedorEntities())
            {
                Remito oRemito = new Remito();

                try
                {
                    oRemito = (from r in db.Remitoes
                               where r.Id == remito.Id
                               select r).SingleOrDefault();
                    db.Dispose();

                    return oRemito;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oRemito;
                }
            }
        }
        public long GetRemito_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.Remitoes.Count() != 0)
                    {
                        maxId = db.Remitoes.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddRemito(Remito remito)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.Remitoes.Add(remito);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region LINEAREMITO


        public long GetLineaRemito_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.LineaRemitoes.Count() != 0)
                    {
                        maxId = db.LineaRemitoes.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddLineaRemito(List<LineaRemito> lineas)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    foreach (LineaRemito l in lineas)
                    {
                        db.LineaRemitoes.Add(l);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region FACTURA
        public List<Factura> GetFacturas()
        {
            using (var db = new proveedorEntities())
            {
                List<Factura> lista = new List<Factura>();

                try
                {
                    lista = (from r in db.Facturas
                             select r).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Factura> GetFacturas(Proveedor proveedor)
        {
            using (var db = new proveedorEntities())
            {
                List<Factura> lista = new List<Factura>();

                try
                {
                    lista = (from f in db.Facturas
                             where f.CompraVenta == "COMPRA" && f.IdEmisor == proveedor.Id
                             select f).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Factura> GetFacturas(Cliente cliente)
        {
            using (var db = new proveedorEntities())
            {
                List<Factura> lista = new List<Factura>();

                try
                {
                    lista = (from f in db.Facturas
                             where f.CompraVenta == "VENTA" && f.IdDestinatario == cliente.Id
                             select f).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Factura> GetFacturas(Cliente cliente, string estado)
        {
            using (var db = new proveedorEntities())
            {
                List<Factura> lista = new List<Factura>();

                try
                {
                    lista = (from f in db.Facturas
                             where f.CompraVenta == "VENTA" && f.IdDestinatario == cliente.Id && f.Estado == estado
                             select f).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Factura> GetFacturas(string compraVenta)
        {
            using (var db = new proveedorEntities())
            {
                List<Factura> lista = new List<Factura>();

                try
                {
                    lista = (from f in db.Facturas
                             where f.CompraVenta == compraVenta
                             select f).ToList();

                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public Factura GetFactura(Factura factura)
        {
            using (var db = new proveedorEntities())
            {
                Factura oFactura = new Factura() { Id = 0 };

                try
                {
                    oFactura = (from f in db.Facturas
                                where f.Id == factura.Id
                               select f).SingleOrDefault();
                    db.Dispose();

                    return oFactura;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oFactura;
                }
            }
        }
        public long GetFactura_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.Facturas.Count() != 0)
                    {
                        maxId = db.Facturas.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddFactura(Factura factura)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.Facturas.Add(factura);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditFactura(Factura factura)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    Factura oFactura = (from f in db.Facturas
                                        where f.Id == factura.Id
                                        select f).SingleOrDefault();

                    oFactura.Id = factura.Id;
                    oFactura.CompraVenta = factura.CompraVenta;
                    oFactura.IdEmisor = factura.IdEmisor;
                    oFactura.IdDestinatario = factura.IdDestinatario;
                    oFactura.FechaEmision = factura.FechaEmision;
                    oFactura.FechaVencimiento = factura.FechaVencimiento;
                    oFactura.Numero = factura.Numero;
                    oFactura.ImporteNeto = factura.ImporteNeto;
                    oFactura.ImporteTotal = factura.ImporteTotal;
                    oFactura.Estado = factura.Estado;
                    oFactura.Observaciones = factura.Observaciones;
                    oFactura.Iva = factura.Iva;

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region LINEAFACTURA
        public List<LineaFactura> GetLineasFactura(Factura factura)
        {
            using (var db = new proveedorEntities())
            {
                List<LineaFactura> lista = new List<LineaFactura>();

                try
                {
                    lista = (from l in db.LineaFacturas
                             where l.IdFactura == factura.Id
                             select l).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public long GetLineaFactura_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.LineaFacturas.Count() != 0)
                    {
                        maxId = db.LineaFacturas.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddLineaFactura(List<LineaFactura> lineas)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    foreach (LineaFactura l in lineas)
                    {
                        db.LineaFacturas.Add(l);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region CHEQUES
        public List<Cheque> GetCheques()
        {
            using (var db = new proveedorEntities())
            {
                List<Cheque> lista = new List<Cheque>();

                try
                {
                    lista = (from c in db.Cheques
                             select c).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public List<Cheque> GetCheques(string ubicacion)
        {
            using (var db = new proveedorEntities())
            {
                List<Cheque> lista = new List<Cheque>();

                try
                {
                    lista = (from c in db.Cheques
                             where c.Ubicacion == ubicacion
                             orderby c.FechaCobro ascending
                             select c).ToList();
                    db.Dispose();

                    return lista;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return lista;
                }
            }
        }
        public Cheque GetCheque(Cheque cheque)
        {
            using (var db = new proveedorEntities())
            {
                Cheque oCheque = new Cheque();

                try
                {
                    oCheque = (from c in db.Cheques
                               where c.Id == cheque.Id
                               select c).SingleOrDefault();
                    db.Dispose();

                    return oCheque;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return oCheque;
                }
            }
        }
        public long GetCheque_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.Cheques.Count() != 0)
                    {
                        maxId = db.Cheques.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddCheque(Cheque cheque)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.Cheques.Add(cheque);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void AddCheque(List<Cheque> cheques)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    foreach (Cheque cheque in cheques)
                    {
                        db.Cheques.Add(cheque);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void EditCheque(Cheque cheque)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    Cheque oCheque = (from c in db.Cheques
                                      where c.Id == cheque.Id
                                      select c).SingleOrDefault();

                    oCheque.Id = cheque.Id;
                    oCheque.Numero = cheque.Numero;
                    oCheque.Banco = cheque.Banco;
                    oCheque.Tipo = cheque.Tipo;
                    oCheque.FechaEmision = cheque.FechaEmision;
                    oCheque.FechaCobro = cheque.FechaCobro;
                    oCheque.IdCliente = cheque.IdCliente;
                    oCheque.Monto = cheque.Monto;
                    oCheque.Ubicacion = cheque.Ubicacion;
                    oCheque.Observaciones = cheque.Observaciones;

                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region PRECIOPRODUCTO

        public long GetPrecioProducto_Id()
        {
            long maxId = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.PrecioProductoes.Count() != 0)
                    {
                        maxId = db.PrecioProductoes.Max(p => p.Id);
                        db.Dispose();
                    }

                    return maxId;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void AddPrecioProducto(PrecioProducto precio)
        {
            using (var db = new proveedorEntities())
            {
                try
                {
                    db.PrecioProductoes.Add(precio);
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion





        #region CHEQUEOS

        public bool CkConfirmacion(string str)
        {
            DialogResult dialogResult = MessageBox.Show("Está seguro de que desea " + str + "?", "WORKING SRL", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else if (dialogResult == DialogResult.No)
            {
                return false;
            }

            return false;
        }

        public void Validate_textBox(TextBox _text, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            //check if '.' , ',' pressed
            char sepratorChar = 's';

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // check if it's in the beginning of text not accept
                if (_text.Text.Length == 0)
                    e.Handled = true;
                // check if it's in the beginning of text not accept
                if (_text.SelectionStart == 0)
                    e.Handled = true;
                // check if there is already exist a '.' , ','
                if (alreadyExist(_text.Text, ref sepratorChar))
                    e.Handled = true;
                //check if '.' or ',' is in middle of a number and after it is not a number greater than 99
                if (_text.SelectionStart != _text.Text.Length && e.Handled == false)
                {
                    // '.' or ',' is in the middle
                    string AfterDotString = _text.Text.Substring(_text.SelectionStart);

                    if (AfterDotString.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            //check if a number pressed

            if (Char.IsDigit(e.KeyChar))
            {
                //check if a coma or dot exist
                if (alreadyExist(_text.Text, ref sepratorChar))
                {
                    int sepratorPosition = _text.Text.IndexOf(sepratorChar);

                    string afterSepratorString = _text.Text.Substring(sepratorPosition + 1);

                    if (_text.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        private bool alreadyExist(string _text, ref char KeyChar)
        {
            if (_text.IndexOf('.') > -1)
            {
                KeyChar = '.';
                return true;
            }

            if (_text.IndexOf(',') > -1)
            {
                KeyChar = ',';
                return true;
            }

            return false;
        }

        #endregion


        #region IMPUESTOS/FINANCIERO

        public decimal GetImpuestos_IVA(DateTime fechainicio, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<Venta> listaVentas = new List<Venta>();
                List<Factura> listaCompras = new List<Factura>();

                try
                {
                    listaVentas = (from venta in db.Ventas
                                   where DateTime.Parse(venta.Fecha) >= fechainicio && DateTime.Parse(venta.Fecha) <= fechafin
                                   select venta).ToList();

                    listaCompras = (from compra in db.Facturas
                                    where DateTime.Parse(compra.FechaEmision) >= fechainicio && DateTime.Parse(compra.FechaEmision) <= fechafin
                                    select compra).ToList();

                    db.Dispose();

                    decimal ivaFavor = 0;
                    decimal ivaContra = 0;

                    foreach(Factura factura in listaCompras)
                    {
                        ivaFavor += factura.Iva;
                    }

                    foreach(Venta venta in listaVentas)
                    {
                        ivaContra += (venta.MontoTotal - venta.Monto);
                    }

                    return (ivaContra - ivaFavor);
                    
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }

        public decimal GetImpuestos_IIBB(DateTime fechainicio, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<Factura> listaVentas = new List<Factura>();

                try
                {
                    listaVentas = (from factura in db.Facturas
                                   where factura.CompraVenta=="VENTA" && DateTime.Parse(factura.FechaEmision) >= fechainicio && DateTime.Parse(factura.FechaEmision) <= fechafin
                                   select factura).ToList();
                    var x = db.Facturas.Where(f => f.CompraVenta == "VENTA" && DateTime.Parse(f.FechaEmision) >= fechainicio && DateTime.Parse(f.FechaEmision) <= fechafin).ToList();
                    db.Dispose();

                    decimal totalIIBB = 0;

                    foreach (Factura factura in x)
                    {
                        totalIIBB += (factura.ImporteNeto * 0.05m);
                    }

                    return totalIIBB/2;

                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }

        public decimal GetImpuestos_Municipal(DateTime fechainicio, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<Venta> listaVentas = new List<Venta>();

                try
                {
                    listaVentas = (from venta in db.Ventas
                                   where DateTime.Parse(venta.Fecha) >= fechainicio && DateTime.Parse(venta.Fecha) <= fechafin
                                   select venta).ToList();

                    db.Dispose();

                    decimal totalIIBB = 0;

                    foreach (Venta venta in listaVentas)
                    {
                        totalIIBB += (venta.Monto * 0.02m);
                    }

                    return totalIIBB;

                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }

        //public decimal GetFinanzas_Costos() { }
        //public decimal GetFinanzas_Costos(Producto producto) { }
        //public decimal GetFinanzas_Costos(DateTime fechainicio, DateTime fechafin) { }
        //public decimal GetFinanzas_Costos(Producto producto, DateTime fechainicio, DateTime fechafin) { }

        public decimal GetFinanzas_TotalVentasNetas(DateTime fechainicio, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<Factura> listaFacturasVenta = new List<Factura>();

                try
                {
                    listaFacturasVenta = (from factura in db.Facturas
                                   where factura.CompraVenta=="VENTA" && DateTime.Parse(factura.FechaEmision) >= fechainicio && DateTime.Parse(factura.FechaEmision) <= fechafin
                                   select factura).ToList();


                    db.Dispose();

                    decimal ventasNetas = 0;
                    
                    foreach (Factura factura in listaFacturasVenta)
                    {
                        ventasNetas += factura.ImporteNeto;
                    }

                    return (ventasNetas);

                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }
        public decimal GetFinanzas_TotalCompras(DateTime fechainicio, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<Factura> listaFacturasCompra = new List<Factura>();

                try
                {
                    var x = db.Facturas.SqlQuery("SELECT * FROM Factura WHERE CompraVenta == \"VENTA\" AND FechaEmision >= \"" + fechainicio.ToString("yyyy-MM-dd") + "\" AND FechaEmision <= \"" + fechafin.ToString("yyyy-MM-dd") + "\"").ToList();

                    db.Dispose();

                    decimal costoCompras = 0;

                    foreach (Factura factura in x)
                    {
                        costoCompras += factura.ImporteNeto;
                    }

                    costoCompras += 90000;

                    return (costoCompras);

                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }
        public decimal GetFinanzas_TotalKgProducido(DateTime fechainicio, DateTime fechafin)
        {
            using (var db = new proveedorEntities())
            {
                List<Factura> listaFacturasVenta = new List<Factura>();

                try
                {
                    //listaFacturasVenta = (from factura in db.Facturas
                    //                      where factura.CompraVenta == "VENTA" && DateTime.Parse(factura.FechaEmision) >= fechainicio && DateTime.Parse(factura.FechaEmision) <= fechafin
                    //                      select factura).ToList();

                    var x = db.Facturas.SqlQuery("SELECT * FROM Factura WHERE CompraVenta == \"VENTA\" AND FechaEmision >= \"" + fechainicio.ToString("yyyy-MM-dd") + "\" AND FechaEmision <= \"" + fechafin.ToString("yyyy-MM-dd") + "\"").ToList();

                    decimal kilosProducidos = 0;

                    foreach (Factura factura in x)
                    {
                        List<LineaFactura> lineasFactura = this.GetLineasFactura(factura);

                        foreach(LineaFactura linea in lineasFactura)
                        {
                            kilosProducidos += linea.Cantidad;
                        }

                    }

                    db.Dispose();

                    return (kilosProducidos);

                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }

        #endregion



        #region SCRIPTS

        public void Script_ProgramarCargaPedidos()
        {
            //Chequeo si hay pedidos pendiente de envío
            //Si hay, los agrupo por fecha de entrega y creo (o algo) una TAREA que sea la de Pedir Autoelevador, con fecha = fechaEntrega - 1
            // También necesito la TAREA Pedir Camión.

            //Al mismo tiempo, si ya existe la tarea de pedir autoelevador para determinados pedidos, no hay que volver a generarla.



        }

        public void Script_CompletarLineaPedido()
        {
            using (var db = new proveedorEntities())
            {
                List<Pedido> listaPedidos = new List<Pedido>();

                try
                {
                    listaPedidos = (from pedido in db.Pedidoes
                             select pedido).ToList();

                    db.Dispose();

                    if (listaPedidos.Count != 0)
                    {
                        foreach (Pedido pedido in listaPedidos)
                        {
                            LineaPedido linea = new LineaPedido()
                            {
                                Id = pedido.Id,
                                IdPedido = pedido.Id,
                                IdProducto = 1,
                                Cantidad = pedido.Total,
                                Pendiente = pedido.Pendiente,
                                Otro = ""
                            };

                            this.AddLineaPedido(linea);
                        }
                    }
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }





        }


        #endregion
    }
}
