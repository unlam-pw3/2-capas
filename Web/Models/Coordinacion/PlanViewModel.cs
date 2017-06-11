using System;
using System.ComponentModel.DataAnnotations;

namespace PW3.arq_2capas.Models.Coordinacion
{
    public class PlanViewModel
    {
        [Required]
        public DayOfWeek DiaDeLaSemana { get; set; }
        [Required]
        public int IdAnimal { get; set; }
        [Required]
        public int IdCuidador { get; set; }
    }
}