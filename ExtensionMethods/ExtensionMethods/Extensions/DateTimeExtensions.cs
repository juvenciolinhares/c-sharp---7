
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace System//digo que minha classe é do namespacesystem e não preciso importar no programa principal
{
    static class DateTimeExtensions
    {
        //extension metodo p extender o tipo datetime:
        public static string ElapsedTime(this DateTime thisObj)//o this no parametro é que diz é um metodo de extensao de datetime
        {
            //transformar a data numa duração em horas ou dias,dependendo do tempo atual
            TimeSpan duration = DateTime.Now.Subtract(thisObj);
            if(duration.TotalHours< 24.0)
            {
                return duration.TotalHours.ToString("F1", CultureInfo.InvariantCulture) + " hours";
            }
            else
            {
                return duration.Days.ToString("F1", CultureInfo.InvariantCulture) + " days";
            }
        }
    }
}
/*
 * quando vou fazer um extension method p uma certa classe ou struct
 * ja coloca a classe no smm namespace do tipo que eu estou extendendo: namespace System(linha 6)
 * 
 * public static string ElapsedTime(this DateTime thisObj) o this é apenas uma referencia ao objeto.
 * não é usado como um parametro de forma tradicional e tbm nao vou precisar colocar nos () da classe principal
 * 
 */