using DemoEFCore2.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore2.Entites
{
    [Owned]
    public class Address
    {
       // public int Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Country { get; set; }

    }
}
