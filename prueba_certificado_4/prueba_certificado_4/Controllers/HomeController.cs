using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using prueba_certificado_4.Models;

using System.Security.Cryptography.Pkcs;
using System.Net.Http;
using System.Security.Authentication;
using System.Collections.Specialized;

namespace prueba_certificado_4.Controllers
{
    public class HomeController : Controller
    {
        public string certHeader = "";
        public string errorString = "";
        private X509Certificate2 certificate = null;
        public string certThumbprint = "";
        public string certSubject = "";
        public string certIssuer = "";
        public string certSignatureAlg = "";
        public string certIssueDate = "";
        public string certExpiryDate = "";
        public bool isValidCert = false;

        public IActionResult Index()
        {
            string resultado = "";
            //HttpClientHandler httpClientHandler = Request.Cert
            //var client = HttpContext.Connection.ClientCertificate;


            
            

            /*var httpClient = HttpContext.Connection.ClientCertificate;
            httpClient.

            var client = new HttpClient(
                new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Automatic,
                    

                });*/

            //if (result != null)
            //{
                //var clienthandler = HttpContext.Connection.ClientCertificate;
                //return new ContentResult() { Content = client.Subject };

                //try {
                    /*resultado += "<p><b> Certificado  buscado metodo </b></p>";
                    resultado += "<p>";
                    resultado += " expira: " + clienthandler.GetExpirationDateString() + "</p><p>";
                    resultado += " Issuer: " + clienthandler.Issuer + "</p><p>";
                    resultado += " EffectiveDate: " + clienthandler.GetEffectiveDateString() + "</p> <p>";
                    resultado += " Nombre: " + clienthandler.GetNameInfo(X509NameType.SimpleName, true) + "</p> <p>";
                    resultado += " LlavePrivada: " + clienthandler.HasPrivateKey + "</p> <p>";
                    resultado += " SubjectName: " + clienthandler.SubjectName.Name + "</p><p>";
                    resultado += " hash: " + clienthandler.GetHashCode() + "</p><p>";
                    resultado += " llave publica: " + clienthandler.GetPublicKeyString() + "</p><p>";
                    resultado += "</p> <br> <br>";

                    ViewData["Nombre"] = resultado;*/

                    //ViewData["Nombre"] = result.Content;
                //} catch (Exception f) {
                    //ViewData["Nombre"] = "error :" +f.Message;
                //}

                //return Content(resultado);
                
            //}
            //else
            //{
                //return Content("No certificado");
              //  ViewData["Nombre"] = "es null";
            //}

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Firmar(string json_inicial)
        {
            //ViewData["Message"] = "Your contact page.";
            //string json_inicial = TempData["JSON"].ToString();

            //TempData["json_final"] = "FUNCIONA";

            //GetClientCertificate();
            //var store = new X509Store(StoreLocation.CurrentUser);

            var result = json_inicial;

            //string b = certificado.GetCertHashString;
            //HttpClientCertificate clientCertificate = Request.ClientCertificate;
            //string a = store.Certificates.ToString();

            //X509Store computerCaStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);

            

            string resultado = "";

            /*try
            {
                computerCaStore.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certificatesInStore = computerCaStore.Certificates;
                int contador = 1;
                foreach (X509Certificate2 cert in certificatesInStore)
                {
                    resultado += "<p><b> Certificado "+contador+"</b></p>";
                    resultado += "<p>";
                    resultado += " expira: " + cert.GetExpirationDateString() + "</p><p>";
                    resultado += " Issuer: " + cert.Issuer + "</p><p>";
                    resultado += " EffectiveDate: " + cert.GetEffectiveDateString() + "</p> <p>";
                    resultado += " Nombre: " + cert.GetNameInfo(X509NameType.SimpleName, true) + "</p> <p>";
                    resultado += " LlavePrivada: " + cert.HasPrivateKey + "</p> <p>";
                    resultado += " SubjectName: " + cert.SubjectName.Name + "</p><p>";
                    resultado += "</p> <br> <br>";

                    contador++;
                }
            }
            finally
            {
                computerCaStore.Close();
            }
            */

            //var store = CertificateInfo.CreateX509Store();
            //var certificates = CertificateInfo.GetCertificatesList(store);

            //HttpClientCertificate cs = Request.ClientCertificate;


            /*var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.SslProtocols = SslProtocols.Tls12;
            handler.ClientCertificates.Add(new X509Certificate2("cert.crt"));
            var client = new HttpClient(handler);
            var resulta = client.GetAsync("https://apitest.startssl.com").GetAwaiter().GetResult();
            */

            /*NameValueCollection headers = new NameValueCollection(Request.Headers.Count);
            foreach (var key in Request.Headers)
            {
                headers.Add(key, Request.Headers[key]);
            }
            //return nvCollection;

            NameValueCollection headers = Request.Headers["X-ARR-ClientCert"];*/
            /*certHeader = Request.Headers["X-ARR-ClientCert"];// headers["X-ARR-ClientCert"];
            if (!String.IsNullOrEmpty(certHeader))
            {
                try
                {
                    byte[] clientCertBytes = Convert.FromBase64String(certHeader);
                    certificate = new X509Certificate2(clientCertBytes);
                    certSubject = certificate.Subject;
                    certIssuer = certificate.Issuer;
                    certThumbprint = certificate.Thumbprint;
                    certSignatureAlg = certificate.SignatureAlgorithm.FriendlyName;
                    certIssueDate = certificate.NotBefore.ToShortDateString() + " " + certificate.NotBefore.ToShortTimeString();
                    certExpiryDate = certificate.NotAfter.ToShortDateString() + " " + certificate.NotAfter.ToShortTimeString();

                    resultado += "<p><b> Certificado  buscado metodo </b></p>";
                    resultado += "<p>";
                    resultado += " expira: " + certificate.GetExpirationDateString() + "</p><p>";
                    resultado += " Issuer: " + certificate.Issuer + "</p><p>";
                    resultado += " EffectiveDate: " + certificate.GetEffectiveDateString() + "</p> <p>";
                    resultado += " Nombre: " + certificate.GetNameInfo(X509NameType.SimpleName, true) + "</p> <p>";
                    resultado += " LlavePrivada: " + certificate.HasPrivateKey + "</p> <p>";
                    resultado += " SubjectName: " + certificate.SubjectName.Name + "</p><p>";
                    resultado += " hash: " + certificate.GetHashCode() + "</p><p>";
                    resultado += " llave publica: " + certificate.GetPublicKeyString() + "</p><p>";
                    resultado += "</p> <br> <br>";
                }
                catch (Exception ex)
                {
                    errorString = ex.ToString();
                }
                finally
                {
                    isValidCert = IsValidClientCertificate();
                    if (!isValidCert) Response.StatusCode = 403;
                    else Response.StatusCode = 200;
                }
            }
            else
            {
                certHeader = "";
            }*/

            //var clientCertificate = await HttpContext.Connection.GetClientCertificateAsync();
            var client = HttpContext.Connection.ClientCertificate;

            if (client != null)
            {
                //return new ContentResult() { Content = client.Subject };


                resultado += "<p><b> Certificado  buscado metodo </b></p>";
                resultado += "<p>";
                resultado += " expira: " + client.GetExpirationDateString() + "</p><p>";
                resultado += " Issuer: " + client.Issuer + "</p><p>";
                resultado += " EffectiveDate: " + client.GetEffectiveDateString() + "</p> <p>";
                resultado += " Nombre: " + client.GetNameInfo(X509NameType.SimpleName, true) + "</p> <p>";
                resultado += " LlavePrivada: " + client.HasPrivateKey + "</p> <p>";
                resultado += " SubjectName: " + client.SubjectName.Name + "</p><p>";
                resultado += " hash: " + client.GetHashCode() + "</p><p>";
                resultado += " llave publica: " + client.GetPublicKeyString() + "</p><p>";
                resultado += "</p> <br> <br>";

                return Content(resultado);
            }
            else
            {

                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.SslProtocols = SslProtocols.Tls12;
                handler.ClientCertificates.Add(new X509Certificate2());
                var cliente = new HttpClient(handler);
                var resulta = cliente.GetAsync("https://apitest.startssl.com").GetAwaiter().GetResult();
                resultado += "<p>No certificado</p><br><p>" + resulta.Content + "</p>";
                return Content(resultado);
            }

            //X509Certificate2 certificado = GetClientCertificate();

            //X509Certificate2 certificado = GetCert2("localhost");
            /*resultado += "<p><b> Certificado  buscado metodo </b></p>";
            resultado += "<p>";
            resultado += " expira: " + certificado.GetExpirationDateString() + "</p><p>";
            resultado += " Issuer: " + certificado.Issuer + "</p><p>";
            resultado += " EffectiveDate: " + certificado.GetEffectiveDateString() + "</p> <p>";
            resultado += " Nombre: " + certificado.GetNameInfo(X509NameType.SimpleName, true) + "</p> <p>";
            resultado += " LlavePrivada: " + certificado.HasPrivateKey + "</p> <p>";
            resultado += " SubjectName: " + certificado.SubjectName.Name + "</p><p>";
            resultado += " hash: " + certificado.GetHashCode() + "</p><p>";
            resultado += " llave publica: " + certificado.GetPublicKeyString() + "</p><p>";
            resultado += "</p> <br> <br>";*/



            
        }


        //
        // This is a SAMPLE verification routine. Depending on your application logic and security requirements, 
        // you should modify this method
        //
        private bool IsValidClientCertificate()
        {
            // In this example we will only accept the certificate as a valid certificate if all the conditions below are met:
            // 1. The certificate is not expired and is active for the current time on server.
            // 2. The subject name of the certificate has the common name nildevecc
            // 3. The issuer name of the certificate has the common name nildevecc and organization name Microsoft Corp
            // 4. The thumbprint of the certificate is 30757A2E831977D8BD9C8496E4C99AB26CB9622B
            //
            // This example does NOT test that this certificate is chained to a Trusted Root Authority (or revoked) on the server 
            // and it allows for self signed certificates
            //

            if (certificate == null || !String.IsNullOrEmpty(errorString)) return false;

            // 1. Check time validity of certificate
            if (DateTime.Compare(DateTime.Now, certificate.NotBefore) < 0 || DateTime.Compare(DateTime.Now, certificate.NotAfter) > 0) return false;

            // 2. Check subject name of certificate
            bool foundSubject = false;
            string[] certSubjectData = certificate.Subject.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in certSubjectData)
            {
                if (String.Compare(s.Trim(), "CN=nildevecc") == 0)
                {
                    foundSubject = true;
                    break;
                }
            }
            if (!foundSubject) return false;

            // 3. Check issuer name of certificate
            bool foundIssuerCN = false, foundIssuerO = false;
            string[] certIssuerData = certificate.Issuer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in certIssuerData)
            {
                if (String.Compare(s.Trim(), "CN=nildevecc") == 0)
                {
                    foundIssuerCN = true;
                    if (foundIssuerO) break;
                }

                if (String.Compare(s.Trim(), "O=Microsoft Corp") == 0)
                {
                    foundIssuerO = true;
                    if (foundIssuerCN) break;
                }
            }

            if (!foundIssuerCN || !foundIssuerO) return false;

            // 4. Check thumprint of certificate
            if (String.Compare(certificate.Thumbprint.Trim().ToUpper(), "30757A2E831977D8BD9C8496E4C99AB26CB9622B") != 0) return false;

            // If you also want to test if the certificate chains to a Trusted Root Authority you can uncomment the code below
            //
            //X509Chain certChain = new X509Chain();
            //certChain.Build(certificate);
            //bool isValidCertChain = true;
            //foreach (X509ChainElement chElement in certChain.ChainElements)
            //{
            //    if (!chElement.Certificate.Verify())
            //    {
            //        isValidCertChain = false;
            //        break;
            //    }
            //}
            //if (!isValidCertChain) return false;

            return true;
        }


        private static X509Certificate2 GetCert2(string hostname)
        {
            X509Store myX509Store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            myX509Store.Open(OpenFlags.ReadWrite);
            X509Certificate2 myCertificate = myX509Store.Certificates.OfType<X509Certificate2>().FirstOrDefault(cert => cert.GetNameInfo(X509NameType.SimpleName, false) == hostname);
            return myCertificate;
        }


        private X509Certificate2 GetClientCertificate()
        {
            X509Store userCaStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            try
            {
                userCaStore.Open(OpenFlags.OpenExistingOnly);
                //Se obtienen solamente los certificados válidos en cuanto a fecha se refiera
                X509Certificate2Collection certificatesInStore = userCaStore.Certificates
                                                                .Find(X509FindType.FindByTimeExpired, DateTime.Now, false);
                X509Certificate2 clientCertificate = null;
                if (certificatesInStore.Count > 0)
                {

                    clientCertificate = certificatesInStore[0];
                }
                else
                {
                    return null;
                }
                return clientCertificate;
            }
            catch
            {
                throw;
            }
            finally
            {
                userCaStore.Close();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
