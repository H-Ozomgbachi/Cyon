using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyon.Infrastructure.Repositories
{
    public class YearProgrammeRepository : Repository<YearProgramme>, IYearProgrammeRepository
    {
        public YearProgrammeRepository(DbSet<YearProgramme> yearProgrammes) : base(yearProgrammes)
        {
        }
    }
}
