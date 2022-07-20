using System;
using System.Collections.Generic;
using System.Text;

namespace GetHasCodeEEquals.Entities
{
    //gethashcode personalizado: quando um cliente vai ser igual a outro:
    internal class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }

        /*cusmotizar a comparação entre clientes:
         * qual a regra? eu defino, por exemplo:
         * clinte = clinte qnd email for igual
         * clinte = clinte qnd cpf for igual
         * clinte = clinte qnd id for igual
         */

        //Equals para comparar o cliente(classe) com o cliente que vai vir como argumento(obj) 
        public override bool Equals(object obj)
        {
            if(!(obj is Client))//testo primeiro se obj é do tipo client.
            {
                return false;
            }

            //downcast :
            Client other = obj as Client;
           
            //comparar por email:
            return Email.Equals(other.Email);//comparando o email do client com other
        }

        //GetHashCode para comparar o cliente(classe) com o cliente que vai vir como argumento(obj) 
        public override int GetHashCode()
        {
            //o GetHashCode do email vai ser o GetHashCode do cliente
            return Email.GetHashCode();
        }
    }
}
/*
 * se eu nao implementar os dois metodos:
 *public override bool Equals(object obj)
 *public override int GetHashCode()
 *o compilador reclama na no nome da classe: Client(linha 8)
 */