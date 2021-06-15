using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_Dashboard.Data;
using System.Collections.Generic;
using Project_Dashboard.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;
using System;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Collections;
using DocumentFormat.OpenXml.Office2010.ExcelAc;

namespace Project_Dashboard.Controllers
{
  
    public class AdminsController : Controller
    {

   
        private readonly ApplicationDbContext _context;
        

        public AdminsController(ApplicationDbContext context)
        {
            _context = context;
        }

  
        
        public IActionResult Dashboard()
        {
            var totale_prix_article = _context.articles.AsQueryable().Select(x => x.Prix).Sum();
            //var prix_par_month = _context.articles.AsQueryable().Select(x => x.facture.prix_facture).OrderBy(s =>);
            var totale_prix_facture = _context.factures.AsQueryable().Sum(x => x.prix_facture);                   


            var dates_years = _context.factures.Select(x => x.date_facture.Year ).Distinct().ToArray();


            ////////////////////nbre client par ans///////////////////
            var date_client = _context.factures.Select(x => x.date_facture.Year).Distinct().ToArray();

            List<String> sumclient = new List<String>();

            String z = null;
            foreach (var yy in date_client)
            {
                z = _context.factures.AsQueryable()
                    .Where(x => x.date_facture.Year == yy)
                    .Count().ToString();

                sumclient.Add(z);
            }


            ////////////////////SUM prix Stock par Ans///////////////
            List<String> sumprix_stock_par_fournisseur = new List<String>();

            var datestock = _context.stocks.Select(x => x.date_stock.Year).Distinct().ToArray(); ;

            String y = null;
            foreach (var yy in datestock)
            {
                y = _context.stocks.AsQueryable()
                    .Where(x => x.date_stock.Year == yy)
                    .Sum(x => x.Prix_st).ToString();

                sumprix_stock_par_fournisseur.Add(y);
            }
            ////////////////////////price income per year///////////////////////////////
            List<String> sumprix = new List<String>();

            String x = null;
            foreach (var yy in dates_years)
            {
                 x = _context.factures.AsQueryable()
                     .Where(x => x.date_facture.Year == yy)
                     .Sum(x => x.prix_facture).ToString();

                sumprix.Add(x);
            }
            /////////////////////////////////////////////////////////

            ViewBag.Collectionstock = new String[] { sumprix_stock_par_fournisseur[0], sumprix_stock_par_fournisseur[1],
                                                     sumprix_stock_par_fournisseur[2], sumprix_stock_par_fournisseur[3],
                                                     sumprix_stock_par_fournisseur[4], sumprix_stock_par_fournisseur[5],
                                                     sumprix_stock_par_fournisseur[6]};


            ViewBag.Collection = new String[] { sumprix[0]  , sumprix[1] , sumprix[2],
                                                sumprix[3]  , sumprix[4] , sumprix[5],
                                                sumprix[6] };


            ViewBag.Collectionclient = new String[] { sumclient[0], sumclient[1], sumclient[2],
                                                      sumclient[3], sumclient[4], sumclient[5],
                                                      sumclient[6]};

            ViewBag.Collectiontotaleprixfacture = totale_prix_facture;
            ViewBag.Collectiontotaleprix = totale_prix_article;

          


            return View();
        }




        public IActionResult ViewCategorie()
        {
            
            var electronique = _context.articles.Where(x => x.Categorie == "electronique").Count().ToString();
            var beaute = _context.articles.Where(x => x.Categorie == "produit de beaute").Count().ToString();
            var maison = _context.articles.Where(x => x.Categorie == "produit de maison").Count().ToString();
            var sucre = _context.articles.Where(x => x.Categorie == "produit sucre").Count().ToString();
            var laitier = _context.articles.Where(x => x.Categorie == "produit laitiers").Count().ToString();

            ViewBag.Collectioncat = new string[] { electronique, beaute, maison, sucre, laitier };

            return View();
        }
     



        private IActionResult ViewResult()
        {
            throw new NotImplementedException();
        }

        public  IActionResult ViewAge()
            {
            var client = _context.clients.AsQueryable().Select(x => x.age).Distinct().ToArray();

           
            ViewBag.Collectionage = new string[] { client[0].ToString(), client[1].ToString(),client[2].ToString(), client[3].ToString() }; 
            ViewBag.Collectionintage = new int[] { client[0], client[1], client[2], client[3] }; 
            return View();
        }

 

    }
}
