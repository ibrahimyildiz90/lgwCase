using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string CourseCollectionName { get; set; }
        public string CategortyCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }       
    }
}
