using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceOne
{
    public interface IAnimal
    {
        string Name { get; set; }

        string Habitat { get; set; }

        string Eating { get; set; }

        string Habit { get; set; }

    }
}