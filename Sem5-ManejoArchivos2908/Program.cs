using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sem5_ManejoArchivos2908
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool mostrarMenu = true;

            while (mostrarMenu)
            {
                mostrarMenu = Menu();

            }
            Console.ReadKey();
        }

        private static bool Menu()
        {
            //crear el menu para mostrar al usuario

            Console.WriteLine("Registro Médico, selecciona la operación a realizar: ");
            Console.WriteLine("1. Registrar nuevo paciente");
            Console.WriteLine("2. Actualizar datos de paciente");
            Console.WriteLine("3. Eliminar datos de ");
            Console.WriteLine("4. Mostrar listado de pacientes");
            Console.WriteLine("5. Salir");
            Console.Write("\nOpcion: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ingresarDatos(); //llamado al metodo registrar
                    return true;

                case "2":
                    //llamdo al metodo para actualizar
                    //updateData();
                    return true;
                case "3"://llamado para eliminar

                    Console.ReadKey();
                    return true;
                case "4":
                    //mostrar el contenido del archivo
                    Console.WriteLine("LISTADO DE PACIENTES");
                    readFile();

                    Console.ReadKey();
                    return true;
                case "5":
                    return false;
                default:
                    return false;
            }
        }
        private static string getPath()//metodos para obtener la ruta
        {
            string path = @"C:\Users\harol\source\repos\EjerciciosPrimerComputoC#\Sem5-ManejoArchivos2908\registrosMedicos.txt";
            return path;
        }

        private static void ingresarDatos()//Metodo para registrar los datos 
        {
            object[] datos = new object[6];
            object[] palabras = new object[6];

            palabras[0] = "Nombre: ";
            palabras[1] = "Edad: ";
            palabras[2] = "Sexo: ";
            palabras[3] = "Tipo de sangre: ";
            palabras[4] = "Enfermedad hereditaria(Si/No): ";
            palabras[5] = "Residencia: ";


            for (int i = 0; i < 6; i = i + 1)
            {
                Console.Write(palabras[i]);

                datos[i] = Console.ReadLine();

            }

            using (StreamWriter sw = File.AppendText(getPath()))
            {
                sw.WriteLine("{0}; {1}; {2}; {3}; {4}; {5};", datos[0], datos[1], datos[2], datos[3], datos[4], datos[5]);

                sw.WriteLine("------------------");
                sw.Close();
            }

        }

        //metodo para leer el contenido del archivo
        private static void readFile()
        {

            String line;
            {

                StreamReader sr = new StreamReader(getPath());

                line = sr.ReadLine();

                while (line != null)
                {

                    Console.WriteLine(line);

                    line = sr.ReadLine();
                }

                sr.Close();
                Console.ReadLine();
            }

        }

        private static bool readF(string name)
        {


            //declarar el diccionario
            string[] listData = new string[6];

            //uso del StreamReader para leer el archivo
            using (var reader = new StreamReader(getPath()))
            {
                //variable para almacenar el contenido del archivo
                string lines;

                while ((lines = reader.ReadLine()) != null) //mientras no se encuentre una linea vacia se ejecuta el ciclo
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 6)
                    {
                        listData[0] = keyvalue[0];
                        listData[1] = keyvalue[1];
                        listData[2] = keyvalue[2];
                        listData[3] = keyvalue[3];
                        listData[4] = keyvalue[4];
                        listData[5] = keyvalue[5];
                    }
                }

            }

            if (!listData.Contains(name))
            {
                return false;
            }

            return true;

        }

        private static void updateData()
        {
            string name;
            Console.Write("Escriba el nombre del paciente a actualizar: ");
            name = Console.ReadLine();

            if (readF(name) == true)
            {
                Console.WriteLine("existe");
            }
            else
            {
                Console.WriteLine("no existe");
            }


        }

        private static void deleteData()
        {
            //solicitar el elemnto a eliminar
            Console.Write("Escriba el nombre del estudiante a eliminar: ");
            var name = Console.ReadLine();

            //realizar la busqueda
            if (readF(name)) //llamado al metodo search(), utilizado para realizar una busqueda
                             //dentro del archivo
            {

            }
            else
            {
                Console.WriteLine("El registro no se encontro!");
            }



        }

    }
}
