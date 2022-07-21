
using System.Collections.Generic;
using System.Text;

namespace System
{
    static class StringExtensions
    {
        
        public static string Cut(this string ThisObj, int count)//n precisa ser, obrigatoriamente ThisObj, pode ser outro, o importante é a referencia
        {
            //metodo p recortar o string:

            if(ThisObj.Length <= count)//se o string original ja tiver do tamanho que eu quero cortar, n vou precisar cortar
            {
                return ThisObj;
            }
            else
            {
                return ThisObj.Substring(0, count) + "...";
            }
        }
    }
}
