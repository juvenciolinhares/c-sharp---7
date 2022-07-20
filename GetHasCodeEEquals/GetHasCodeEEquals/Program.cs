using System;
using GetHasCodeEEquals.Entities;

namespace GetHasCodeEEquals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client a = new Client() { Name = "maria", Email = "maria@gmail.com" };
            Client b = new Client() { Name = "Alex", Email = "maria@gmail.com" };

            //teste: se o email for igual, mesmo com nomes diferentes va dar true.
            Console.WriteLine(a.Equals(b));

            /*comparação de igualdade(==) da false(independente de email igual ou não)
             * O == compara a referencia do ponteiro de memoria do obj
             * */
            Console.WriteLine("comparação de igualdade(==): " + (a == b));

            //teste por gethashcode: email diferentes = gethashcode diferentes, emails iguais: gethashcode iguais
            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());

        }
    }
}
/*
 * operações da classe object utilizada p comprar objs
diferenças:
equals: mais lenta, porém 100% de certeza na resposta
GetHasCode: mais rápido, porém a resposta não é 100% segura
os tipos pre-definidos ja possuem implementação para essas operações, porém se eu faço classes ou structs personalizados preciso sobrepor essas operações p costumiza-los

equals:
retorna true ou false
cwtabtab a.equals(b)=> false

gethashcode:
retorna um int representando um código gerado a partir das informações do objeto

regra de ouro do .GetHashCode();

se o código de 2 objs for diferente, os 2 objs sao diferentes

se o código de 2 obj for igual, muito provavelmente os obj são iguais, mas não é 100% de certeza, o código GetHashCode pode ter dado o mesmo valor por coincidencia, visto que são gerados aleatoriamente.
quando usar cada um?
exemplo:
numa lista de 10000000 de objetos, uso o GetHashCode pra encontrar, quando encontrar o obj que gerou o msm GetHashCode, uso o equals p comparar esses e ter 100% de certeza

 */