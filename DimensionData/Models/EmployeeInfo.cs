using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DimensionData.Models
{
    public class EmployeeInfo
    {
        public int ID{ get; set;}
        [Required]
        public int Name{ get; set; }
        [Required]
        public int Gender{ get; set; }
        [Required]
        public int Company { get; set; }
        [Required]
        public int Department{ get; set; }

        public static implicit operator EmployeeInfo(EmployeeInfo v)
        {
            throw new NotImplementedException();
        }
    }
}
