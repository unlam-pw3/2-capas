using System;
using System.Linq;
using CapaNegocioDatos.DTOs;

namespace CapaNegocioDatos.Servicios
{
    public class AnimalServicio
    {
        private readonly ZooEntities _contexto = new ZooEntities();

        public Resultado CoordinarPlanCuidado(DayOfWeek diaSemana, int idAnimal, int idCuidador)
        {
            Resultado resultado;

            if (!Validar(diaSemana, idAnimal, idCuidador, out resultado)) return resultado;

            Guardar(diaSemana, idAnimal, idCuidador);

            return Resultado.CrearResultadoExitoso();
        }

        private bool Validar(DayOfWeek diaSemana, int idAnimal, int idCuidador, out Resultado resultado)
        {
            var planAnimal = _contexto.PlanCuidadoes
                .Where(p => p.IdAnimal == idAnimal)
                .FirstOrDefault(p => p.DiaSemana == (byte)diaSemana);

            if (planAnimal != null && planAnimal.IdCuidador == idCuidador)
            {
                resultado = Resultado.CrearResultadoError("El cuidador ya está asignado para el día y el animal.");
                return false;
            }

            if (planAnimal!= null && planAnimal.IdCuidador != idCuidador)
            {
                resultado = Resultado.CrearResultadoError("El animal ya tiene cuidador asignado para el día.");
                return false;
            }

            var planCuidador = _contexto.PlanCuidadoes
                .Where(p => p.IdCuidador == idCuidador)
                .FirstOrDefault(p => p.DiaSemana == (byte)diaSemana);

            if (planCuidador !=null && planCuidador.IdAnimal != idAnimal)
            {
                resultado = Resultado.CrearResultadoError("El cuidador ya tiene animal asignado para el día.");
                return false;
            }

            resultado = null;
            return true;
        }
        private void Guardar(DayOfWeek diaSemana, int idAnimal, int idCuidador)
        {
            var plan = new PlanCuidado
            {
                DiaSemana = (byte) diaSemana,
                IdAnimal = idAnimal,
                IdCuidador = idCuidador
            };

            _contexto.PlanCuidadoes.Add(plan);
            _contexto.SaveChanges();
        }
    }
}
