using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFO_104_Practica_Semana_04
{
    internal class Program
    {
        static clsEstudiante[] estudiantes = new clsEstudiante[3]; 
        static bool estadoMain = true;
        static bool control = true;
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            while (estadoMain)
            {
                Console.WriteLine("-Manejo de datos de estudiantes-");
                Console.WriteLine("--Menu Principal--");
                Console.WriteLine("1. Incluir Estudiantes");
                Console.WriteLine("2. Consultar Estudiantes");
                Console.WriteLine("3. Modificar Estudiantes");
                Console.WriteLine("4. Eliminar Estudiantes");
                Console.WriteLine("5. Submenú Reportes");
                Console.WriteLine("6. Salida");
                Console.WriteLine("Ingrese seleccion: ");
                int.TryParse(Console.ReadLine(), out int opc);
                if(opc == 1) { Incluir(); }
                else if(opc == 2) { Consulta(); }
                else if (opc == 3) { Modificar(); }
                else if (opc == 4) { Eliminar(); }
                else if (opc == 5) { Submenu(); }
                else if (opc == 6) { estadoMain = false; }
                else { Console.WriteLine("Dato invalido. Intente de nuevo"); }
            }
        }

        static void Incluir()
        {
            if(control == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"Datos del estudiante {i + 1}");
                    Console.WriteLine("Cedula: ");
                    string temp1 = Console.ReadLine();
                    Console.WriteLine("Nombre: ");
                    string temp2 = Console.ReadLine();
                    Console.WriteLine("Promedio: ");
                    float.TryParse(Console.ReadLine(), out float temp3);
                    string temp4 = "Nulo";
                    if(temp3<0 || temp3 > 100) {  temp4 = "Nulo"; }
                    else if( temp3 >=70) {  temp4 = "Aprobado"; }
                    else if (temp3 < 60) { temp4 = "Aplazado"; }
                    else if (temp3 >= 60 || temp3 <70) {  temp4 = "Reprobado"; }

                    estudiantes[i] = new clsEstudiante { cedula = temp1, nombre = temp2, promedio = temp3, condicion = temp4 };

                }
                control = false;
            }
            else
            {
                Console.WriteLine("Estudiantes ya fueron incluidos.");
            }
        }

        static void Submenu()
        {
            bool estadoSub = true;
            while( estadoSub ) 
            {
                Console.WriteLine("--Submenú Reportes--");
                Console.WriteLine("1. Reporte Estudiantes por Condición");
                Console.WriteLine("2. Reporte Todos los datos");
                Console.WriteLine("3. Regresar Menu Principal");
                Console.WriteLine("Ingrese seleccion: ");
                int.TryParse(Console.ReadLine(), out int opc);
                if( opc ==1 ) 
                {
                    Console.WriteLine("1. Aprobado");
                    Console.WriteLine("2. Reprobado");
                    Console.WriteLine("3. Aplazado");
                    int.TryParse(Console.ReadLine(), out int busq);
                    if(busq < 0 || busq > 3) { Console.WriteLine("Seleccion invalida");  }
                    else
                    {
                        reporteCondicion(busq);
                    }
                }
                else if (opc == 2 ) { reporteTodo(); }
                else if (opc == 3 ) { estadoSub = false; }
                else { Console.WriteLine("Opcion invalida. Intente de nuevo"); }
            }
        }
    
        static void reporteTodo()
        {
            Console.WriteLine("Estudiante #\t\t\t\t\tNombre\t\t\t\t\tPromedio\t\t\t\t\tCondicion\t\t\t\t\tCedula");
            Console.WriteLine("\t\t\t\t=========================================================================");
            for (int i = 0;i< estudiantes.Length; i++)
            {
                Console.WriteLine($"{i + 1}\t\t\t\t\t{estudiantes[i].nombre}\t\t\t\t\t{estudiantes[i].promedio}\t\t\t\t\t{estudiantes[i].condicion}\t\t\t\t\t{estudiantes[i].cedula}");
            }
            Console.WriteLine("\t\t\t\t=========================================================================");
            Console.WriteLine("\t\t\t\t<PULSE CUALQUIER TECLA PARA ABANDONAR>");
            Console.ReadLine();
        }

        static void reporteCondicion(int busq)
        {
            int valor = 0;
            if(busq == 1)
            {
                for (int i = 0; i< estudiantes.Length; i++)
                {
                    if (estudiantes[i].condicion == "Aprobado")
                    {
                        valor++;
                    }
                }
                if (valor > 0) 
                {
                    Console.WriteLine($"Estudiantes encontrados {valor}");
                    Console.WriteLine("Estudiante #\t\t\t\t\tNombre\t\t\t\t\tPromedio\t\t\t\t\tCondicion\t\t\t\t\tCedula");
                    Console.WriteLine("\t\t\t\t=========================================================================");
                    for (int i = 0; i < estudiantes.Length; i++)
                    {
                        if (estudiantes[i].condicion == "Aprobado")
                        {
                            Console.WriteLine($"{i + 1}\t\t\t\t\t{estudiantes[i].nombre}\t\t\t\t\t{estudiantes[i].promedio}\t\t\t\t\t{estudiantes[i].condicion}\t\t\t\t\t{estudiantes[i].cedula}");
                        }
                    }
                }
            }
            ///////////////////
            if (busq == 2)
            {
                for (int i = 0; i < estudiantes.Length; i++)
                {
                    if (estudiantes[i].condicion == "Reprobado")
                    {
                        valor++;
                    }
                }
                if (valor > 0)
                {
                    Console.WriteLine($"Estudiantes encontrados {valor}");
                    Console.WriteLine("Estudiante #\t\t\t\t\tNombre\t\t\t\t\tPromedio\t\t\t\t\tCondicion\t\t\t\t\tCedula");
                    Console.WriteLine("\t\t\t\t=========================================================================");
                    for (int i = 0; i < estudiantes.Length; i++)
                    {
                        if (estudiantes[i].condicion == "Reprobado")
                        {
                            Console.WriteLine($"{i + 1}\t\t\t\t\t{estudiantes[i].nombre}\t\t\t\t\t{estudiantes[i].promedio}\t\t\t\t\t{estudiantes[i].condicion}\t\t\t\t\t{estudiantes[i].cedula}");
                        }
                    }
                }
            }
            ////////////////////
            if (busq == 3)
            {
                for (int i = 0; i < estudiantes.Length; i++)
                {
                    if (estudiantes[i].condicion == "Aplazado")
                    {
                        valor++;
                    }
                }
                if (valor > 0)
                {
                    Console.WriteLine($"Estudiantes encontrados {valor}");
                    Console.WriteLine("Estudiante #\t\t\t\t\tNombre\t\t\t\t\tPromedio\t\t\t\t\tCondicion\t\t\t\t\tCedula");
                    Console.WriteLine("\t\t\t\t=========================================================================");
                    for (int i = 0; i < estudiantes.Length; i++)
                    {
                        if (estudiantes[i].condicion == "Aplazado")
                        {
                            Console.WriteLine($"{i + 1}\t\t\t\t\t{estudiantes[i].nombre}\t\t\t\t\t{estudiantes[i].promedio}\t\t\t\t\t{estudiantes[i].condicion}\t\t\t\t\t{estudiantes[i].cedula}");
                        }
                    }
                }
            }
            ////////////////////
        }

        static void Consulta()
        {
            bool estadoSub = true;
            while (estadoSub)
            {
                Console.WriteLine("--Consulta--");
                Console.WriteLine("1. Buscar por cedula");
                Console.WriteLine("2. Regresar Menu Principal");
                Console.WriteLine("Ingrese seleccion: ");
                int.TryParse(Console.ReadLine(), out int opc);
                if (opc == 1) 
                {
                    clsMetodos busqueda;
                    busqueda = new clsMetodos();
                    Console.WriteLine("Ingrese la cedula a buscar: ");
                    string busq = Console.ReadLine();
                    int valor = busqueda.Busqueda(busq,estudiantes);
                    if(valor != -1)
                    {
                        Console.WriteLine("Estudiante encontrado");
                        Console.WriteLine($"{estudiantes[valor].nombre}\t\t\t\t\t{estudiantes[valor].promedio}\t\t\t\t\t{estudiantes[valor].condicion}\t\t\t\t\t{estudiantes[valor].cedula}");
                    }
                    else { Console.WriteLine("Estudiante no encontrado."); }
                }
                else if (opc == 2) { estadoSub = false; }
                else { Console.WriteLine("Opcion invalida. Intente de nuevo"); }
            }
        }

        static void Modificar()
        {
            bool estadoSub = true;
            while (estadoSub)
            {
                Console.WriteLine("--Opciones de Modificacion--");
                Console.WriteLine("1. Buscar por cedula para modificacion");
                Console.WriteLine("2. Regresar Menu Principal");
                Console.WriteLine("Ingrese seleccion: ");
                int.TryParse(Console.ReadLine(), out int opc);
                if (opc == 1)
                {
                    clsMetodos busqueda;
                    busqueda = new clsMetodos();
                    Console.WriteLine("Ingrese la cedula a buscar: ");
                    string busq = Console.ReadLine();
                    int valor = busqueda.Busqueda(busq, estudiantes);
                    if (valor != -1)
                    {
                        Console.WriteLine("Estudiante Encontrado");
                        Console.WriteLine($"{estudiantes[valor].nombre}\t\t\t\t\t{estudiantes[valor].promedio}\t\t\t\t\t{estudiantes[valor].condicion}\t\t\t\t\t{estudiantes[valor].cedula}");
                        Console.WriteLine("Cedula: ");
                        string temp1 = Console.ReadLine();
                        Console.WriteLine("Nombre: ");
                        string temp2 = Console.ReadLine();
                        Console.WriteLine("Promedio: ");
                        float.TryParse(Console.ReadLine(), out float temp3);
                        string temp4 = "Nulo";
                        if (temp3 < 0 || temp3 > 100) { temp4 = "Nulo"; }
                        else if (temp3 >= 70) { temp4 = "Aprobado"; }
                        else if (temp3 < 60) { temp4 = "Aplazado"; }
                        else if (temp3 >= 60 || temp3 < 70) { temp4 = "Reprobado"; }

                        Console.WriteLine("Confirmar Cambios? 1. Si");
                        int.TryParse(Console.ReadLine(), out int opc2);
                        if(opc2 == 1) { estudiantes[valor] = new clsEstudiante { cedula = temp1, nombre = temp2, promedio = temp3, condicion = temp4 }; }
                        else { Console.WriteLine("Cambios cancelados"); }
                    }
                    else { Console.WriteLine("Estudiante no encontrado."); }
                }
                else if (opc == 2) { estadoSub = false; }
                else { Console.WriteLine("Opcion invalida. Intente de nuevo"); }
            }
        }

        static void Eliminar()
        {
            bool estadoSub = true;
            while (estadoSub)
            {
                Console.WriteLine("--Opciones de Eliminacion--");
                Console.WriteLine("1. Buscar por cedula para modificacion");
                Console.WriteLine("2. Regresar Menu Principal");
                Console.WriteLine("Ingrese seleccion: ");
                int.TryParse(Console.ReadLine(), out int opc);
                if (opc == 1)
                {
                    clsMetodos busqueda;
                    busqueda = new clsMetodos();
                    Console.WriteLine("Ingrese la cedula a buscar: ");
                    string busq = Console.ReadLine();
                    int valor = busqueda.Busqueda(busq, estudiantes);
                    if (valor != -1)
                    {
                        Console.WriteLine("Estudiante Encontrado");
                        Console.WriteLine($"{estudiantes[valor].nombre}\t\t\t\t\t{estudiantes[valor].promedio}\t\t\t\t\t{estudiantes[valor].condicion}\t\t\t\t\t{estudiantes[valor].cedula}");

                        Console.WriteLine("Confirmar eliminacion? 1. Si");
                        int.TryParse(Console.ReadLine(), out int opc2);
                        if (opc2 == 1) { estudiantes[valor] = new clsEstudiante { cedula = "", nombre = "", promedio = 0, condicion = "" }; }
                        else { Console.WriteLine("Cambios cancelados"); }
                    }
                    else { Console.WriteLine("Estudiante no encontrado."); }
                }
                else if (opc == 2) { estadoSub = false; }
                else { Console.WriteLine("Opcion invalida. Intente de nuevo"); }
            }
        }
    }
}
