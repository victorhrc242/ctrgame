using FrontEnd.inicio;
HttpClient cliente = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7007/")
};
sistema s=new sistema(cliente);
s.iniciarsistema();