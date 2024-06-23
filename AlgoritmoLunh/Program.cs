using System.Text.RegularExpressions;

string cadena;
bool ban;
do
{
    Console.WriteLine("Ingrese los 16 dígitos de la Tarjeta de crédito");
    //cadena = Console.ReadLine();
    cadena = "6978680553203203";
    ban = Regex.IsMatch(cadena, "^[0-9]{16}$");
} while (!ban);
if (lunh(cadena))
{
    Console.WriteLine("tarjeta de credito valida");
}
else
{
    Console.WriteLine("tarjeta de credito invalida");
}
Console.ReadLine();


static bool lunh(string cadena)
{
    List<string> lista = new List<string>();
    string newCadena = new string(cadena.Reverse().ToArray());

    Console.WriteLine($"original: {cadena}\ninvertida: {newCadena}");

    for (int i = 0; i < newCadena.Length; i++)
    {
        //Console.WriteLine(newCadena[i]);
        if (i % 2 == 0)
        {
            lista.Add(Convert.ToString(newCadena[i]));
        }
        else
        {
            lista.Add(Convert.ToString(int.Parse(newCadena[i].ToString()) * 2));
        }
    }
    int restLunh = 0;
    var aux = "";
    foreach (var item in lista)
    {
        if (int.Parse(item) >= 10)
        {
            aux = Convert.ToString(item);
            restLunh += int.Parse(aux[0].ToString()) + int.Parse(aux[1].ToString());
        }
        else
        {
            restLunh += int.Parse(item);
        }
    }
    Console.WriteLine($"resultado {restLunh}\top:{restLunh % 10}");
    return (restLunh % 10==0)?  true:  false;
    //Console.ReadLine();
}