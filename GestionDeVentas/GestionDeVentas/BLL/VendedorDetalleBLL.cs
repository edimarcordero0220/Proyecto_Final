using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using GestionDeVentas.DAL;
using GestionDeVentas.Entidades;

namespace GestionDeVentas.BLL
{
    public class VendedorDetalleBLL
    {

        public static void Insertar(VendedoresDetalles vd)
        {
            try
            {
                GestionVentaDb db = new GestionVentaDb();
                db.VendedorDetalle.Add(vd);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static List<VendedoresDetalles> GetLista()
        {
            List<VendedoresDetalles> lista = new List<VendedoresDetalles>();
            GestionVentaDb db = new GestionVentaDb();
            lista = db.VendedorDetalle.ToList();
            return lista;

        }

        public static void Eliminar(int v)
        {
            GestionVentaDb db = new GestionVentaDb();
            VendedoresDetalles cl = db.VendedorDetalle.Find(v);

            db.VendedorDetalle.Remove(cl);
            db.SaveChanges();
        }
        public static VendedoresDetalles Buscar(int Id)
        {
            GestionVentaDb db = new GestionVentaDb();
            return db.VendedorDetalle.Find(Id);
        }
        public static List<VendedoresDetalles> GetListaVendedor(int tmp)
        {
            List<VendedoresDetalles> lista = new List<VendedoresDetalles>();
            GestionVentaDb db = new GestionVentaDb();
            lista = db.VendedorDetalle.Where(p => p.VendedorId == tmp).ToList();
            return lista;
        }

        public static List<VendedoresDetalles> GetCategoriaId(int categoriaid)
        {
            List<VendedoresDetalles> lista = new List<VendedoresDetalles>();
            GestionVentaDb db = new GestionVentaDb();
            lista = db.VendedorDetalle.Where(p => p.CategoriaId == categoriaid).ToList();
            return lista;
        }


        public static List<Entidades.VendedoresDetalles> GetList(Expression<Func<VendedoresDetalles, bool>> criterioBusqueda)
        {
            using (var repositorio = new Repositorio<VendedoresDetalles>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }
        public static List<VendedoresDetalles> GetListTodo()
        {
            List<VendedoresDetalles> lista = null;
            using (var conn = new Repositorio<VendedoresDetalles>())
            {
                lista = conn.GetListTodo().ToList();
            }

            return lista;
        }

    }
}