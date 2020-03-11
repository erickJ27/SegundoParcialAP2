using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SegundoParcialApli2.Models;
using SegundoParcialApli2.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SegundoParcialApli2.Controllers
{
    public class LlamadasController
    {
        public bool Guardar(Llamada llamada)
        {
            bool paso = false;
            if (llamada.LlamadaId == 0)
                paso = Insertar(llamada);
            else
                paso = Modificar(llamada);

            return paso;
        }

        public bool Insertar(Llamada llamada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            db.llamadas.Add(llamada);
            paso = db.SaveChanges() > 0;

            return paso;
        }
        public bool Modificar(Llamada llamada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            db.Database.ExecuteSqlRaw($"Delete from LlamadaDetalle where LLamadaId={llamada.LlamadaId}");

            foreach (var item in llamada.Detalle)
            {
                db.Entry(item).State = EntityState.Added;
            }
            db.Entry(llamada).State = EntityState.Modified;
            paso = db.SaveChanges() > 0;

            return paso;

        }
        public Llamada Buscar(int id)
        {
            Contexto db = new Contexto();
            Llamada llamada;

            llamada = db.llamadas.Where(i => i.LlamadaId == id).Include(i => i.Detalle).FirstOrDefault();


            return llamada;
        }
        public bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            Llamada llamada = db.llamadas.Find(Id);
            db.Entry(llamada).State = EntityState.Deleted;
            paso = db.SaveChanges() > 0;

            return paso;

        }
        public List<Llamada> GetList(Expression<Func<Llamada, bool>> expression)
        {
            List<Llamada> lista = new List<Llamada>();
            Contexto db = new Contexto();

            lista = db.llamadas.Where(expression).ToList();

            return lista;
        }

    }
}
