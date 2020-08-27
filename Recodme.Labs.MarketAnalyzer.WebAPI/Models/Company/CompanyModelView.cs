using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support;
using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Models.Company
{
    public class CompanyModelView
    {
        //        camada apresentação:
        //instanciar business no controller,
        //controller é instanciado em viewModel, viewModel  manda para a view,
        //view recebe e faz parte de graficos etc
        //camada de controller recebe pedidos(ex: utilizadores) manda para business, obtem resposta do business e manda para view, controller nao tem logica,

        //public CompanyModelView() { }
        public List<HomeDataPoco> HomeDataPoco { get; set; } 
    }
}
