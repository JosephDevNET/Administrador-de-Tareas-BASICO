using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionTareas.Dtos;
using AplicacionTareas.Models;

namespace AplicacionTareas.Acciones
{
    public class AccionesCRUD
    {
        public AccionesCRUD()
        {
            
        }

        public async Task<List<Notas>> Mostrar()
        {
            try
            {
                using (DbRecordatoriosEntities db = new DbRecordatoriosEntities())
                {
                   return await db.Notas.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Agregar(NotasAgregarDto notasAgregar)
        {
            try
            {
                //Existe una tarea con el mismo nombre
                var notas = await Mostrar();
                if(notas.Any(p => p.Nombre == notasAgregar.Nombre))
                {
                    return false;
                }
                //No existe una tarea con el nombre
                else
                {
                    if (notasAgregar == null)
                    {
                        throw new ArgumentNullException(nameof(notasAgregar), "Los datos de la nota no pueden ser nulos.");
                    }
                    using (DbRecordatoriosEntities db = new DbRecordatoriosEntities())
                    {
                        var Nota = new Notas();
                        Nota.Nombre = notasAgregar.Nombre;
                        Nota.Fecha_Inicio = notasAgregar.Fecha_Inicio ?? DateTime.Now;
                        Nota.Fecha_Final = notasAgregar.Fecha_Final;
                        Nota.Estado = notasAgregar.Estado?.ToString() ?? Estado.Pendiente.ToString();
                        Nota.Cuerpo = notasAgregar.Cuerpo;

                        db.Notas.Add(Nota);

                        await db.SaveChangesAsync();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool> Actualizar(NotasActualizarDto notasActualizar)
        {
            try
            {
                if (notasActualizar == null)
                {
                    throw new ArgumentNullException(nameof(notasActualizar), "Los datos de la nota no pueden ser nulos.");
                }
                using (DbRecordatoriosEntities db = new DbRecordatoriosEntities())
                {
                    var Nota = await db.Notas.FindAsync(notasActualizar.ID);
                    if (Nota == null)
                    {
                        return false;
                    }
                    Nota.Nombre = notasActualizar.Nombre;
                    Nota.Fecha_Inicio = notasActualizar.Fecha_Inicio ?? DateTime.Now;
                    Nota.Fecha_Final = notasActualizar.Fecha_Final;
                    Nota.Estado = notasActualizar.Estado?.ToString() ?? Estado.Pendiente.ToString();
                    Nota.Cuerpo = notasActualizar.Cuerpo;

                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (DbRecordatoriosEntities db = new DbRecordatoriosEntities())
                {
                    var Nota = await db.Notas.FindAsync(id);
                    if (Nota == null)
                    {
                        return false;
                    }

                    db.Notas.Remove(Nota);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
