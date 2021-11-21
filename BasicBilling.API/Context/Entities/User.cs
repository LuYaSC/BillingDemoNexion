using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BasicBilling.API.Context.Entities
{
    public class User : BaseLogicalDelete, IDescription
    {
        [MaxLength(100), Required]
        public string Name { get; set; }
    }
}
