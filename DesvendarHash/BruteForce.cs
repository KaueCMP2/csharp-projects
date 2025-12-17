using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace DesvendarHash
{
    public class BruteForce
    {
        public string hashAlvo = @"5eda1700962fc6290390c7f84cdbd92c";
        public string url = @"https://forms.layers.education/xL9t*4sE0RzVp7KfG*QhU?answ=2804be6";
        public const string possibilidades = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public void VerificarHash()
        {
            foreach (var c1 in possibilidades) //? vai pegar a primeira letra e seguir
            {
                foreach (var c2 in possibilidades) //? vai percorrer por todas as letras e depois voltar para o foreach de cima
                {
                    string tentativa = substituirAsteristicos(url, c1, c2); //? guarda em tentativa a url com as letras modificadas
                    string hashGerado = gerarHash(tentativa); //? guarda e hash gerado o hash que foi gerado em cima da url da tentativa

                    //? IF
                    if (hashGerado.Equals(hashAlvo, StringComparison.CurrentCultureIgnoreCase)) //? o hash que foi gerado, for igual ao hashAlvo, 
                                                                                                //? com base no parametro stringComparison.CurrentCultureIgnoreCase
                    {
                        Console.WriteLine("Hash encontrado 🟩");
                        Console.WriteLine($"Url: {tentativa} ");
                        Console.WriteLine($"caracteres: {c1} & {c2}");
                        return;
                    }
                }
                //? ELSE
                Console.WriteLine("URl Nao encontrado");
            }
        }

        public string substituirAsteristicos(string url, char c1, char c2)
        {
            int primeiro = url.IndexOf('*'); //? identifica na url o primeiro asterisco
            int segundo = url.IndexOf('*', primeiro + 1); //? identifica na url o segundo asterisco

            char[] caracteres = url.ToCharArray(); //? separa a url em um array de caracteres
            caracteres[primeiro] = c1; //? substitui o primeiro asterisco pela letra desejada
            caracteres[segundo] = c2; //? substitui o segundo asterisco pela letra desejada
            return new string(caracteres); //? retorna a nova url modificada
        }

        public string gerarHash(string url)
        {
            using MD5 md5 = MD5.Create(); //? o using nesse caso garante que o md5 vai ser instanciado corretamente 
            byte[] byteUrl = md5.ComputeHash(Encoding.UTF8.GetBytes(url)); //?  primeiro converto a url em encoding.UTF8 que é a tabela que armazena cada caractere por numeros...
                                                                           //? em seguida tranformo o encoding.UTF8 em byte array

            StringBuilder sb = new StringBuilder(); //? instancio um objeto de StringBuilder que basicamente incrementa valores e caracteres em strings,
                                                    //? sem precisar criar uma nova... E bem mais rapido que o incremento normal com +=
            foreach (byte b in byteUrl) //? a variavel b, que foi instanciada como byte vai percorrer o byteUrl
                sb.Append(b.ToString("x2")); //? sb.append é igual o += só que mais rapido e mais seguro...
                                             //? ele vai pega cada caractere que for trazido a ele por meio do b, e tranformar em uma so string...
                                             //? o ("x2") é hex em minusculo, se fosse em maiusculo seria 'X'... e o 2 para gerar no minimo 2 caracteres

            return sb.ToString(); //? retorna o hash gerado
        }
    }
}