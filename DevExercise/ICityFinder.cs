using System;
using System.Collections.Generic;
using System.Text;

namespace DevExercise
{
    public interface ICityFinder
    {
        ICityResult Search(string searchString);
    }

}
