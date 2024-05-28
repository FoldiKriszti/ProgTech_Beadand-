using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterManagementSys
{
    internal class AnimalsDataProxy : IAnimalsData
    {
        private static AnimalsData animalsData;

        public List<AnimalsData> animalsListData()
        {
            if (animalsData == null)
            {
                animalsData = new AnimalsData();
            }

            return animalsData.animalsListData();
        }
    }
}
