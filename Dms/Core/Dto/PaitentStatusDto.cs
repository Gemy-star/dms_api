using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dms.Core.Dto
{
    public class CreatePaitentStatusDto
    {
        [StringLength(maximumLength: 50, ErrorMessage = "Name Is Too Long")]
        public string Name { get; set; }
    }
    public class PaitentStatusDto:CreatePaitentStatusDto
    {
        public byte Id { get; set; }
 
    }


 
}
