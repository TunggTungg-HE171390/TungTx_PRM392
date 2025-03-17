using Microsoft.EntityFrameworkCore;
using Slot3_CodeFirst.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lib_data.Db
{
    public static class DbSeeder
    {
        //tạo data cho lớp để tái sử dụng trong context
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstrumentType>().HasData(
                new InstrumentType { InstrumentTypeId = 1, Name = "Acoustic Guita"},
                new InstrumentType { InstrumentTypeId = 2, Name = "Electric Guita" },
                new InstrumentType { InstrumentTypeId = 3, Name = "Drums" },
                new InstrumentType { InstrumentTypeId = 4, Name = "Bass" },
                new InstrumentType { InstrumentTypeId = 5, Name = "Keyboard" }
            );
        }
    }
}
