using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTraining.Models
{
    public class FoodPackage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PackageDetail> PackageDetails { get; set; }
    }
}
