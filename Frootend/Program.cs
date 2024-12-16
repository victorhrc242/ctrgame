using Frootend;
HttpClient cliente = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7007/")
};
Sistema sistema = new Sistema(cliente);
sistema.inicirasistema();