using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLayer.Entity
{
    public class Entity
    {
        public int Id { get; set; }
        public string GuId { get; set; }

        public Entity()
		{
			GuId = Guid.NewGuid().ToString().Replace("-", "");
		}
    }
}