using Front_End_ADM.Inicio;
HttpClient cliente = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7007/")
};
Sistema s=new Sistema(cliente);
s.iniciarsistema();
