using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFO_104_Practica_Semana_04
{
    internal class clsMetodos
    {
        public int Busqueda(string busq, clsEstudiante[] estudiantes)
        {
            int retVal = -1;
            for (int i = 0; i < estudiantes.Length; i++)
            {
                if (busq == estudiantes[i].cedula)
                {
                    retVal = i;
                    return retVal;
                    
                }
            }
            return retVal;
        }


    }
}
