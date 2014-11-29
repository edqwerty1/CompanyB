using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosaic.Domain
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
    }
}
