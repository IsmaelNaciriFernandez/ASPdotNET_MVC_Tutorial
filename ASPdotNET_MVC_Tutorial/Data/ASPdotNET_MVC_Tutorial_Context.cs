using Microsoft.EntityFrameworkCore;
using ASPdotNET_MVC_Tutorial.Models;

namespace ASPdotNET_MVC_Tutorial.Data
{
    public class ASPdotNET_MVC_Tutorial_Context : DbContext
    {
        public ASPdotNET_MVC_Tutorial_Context(DbContextOptions<ASPdotNET_MVC_Tutorial_Context> options) : base(options)
        {

        }

        public DbSet<Item> Item { get; set; }


    }
}
