using AutoMechanics.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMechanics.SRC.Models
{
    public class RepairModel
    {
        public int Id { get; set; }

        public string Mechanic { get; set; }

        public string Description { get; set; }
    }
}
