using JWT;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Efebyte_Api
{
    public class Api
    {
        /// <summary>
        /// Metodo para realizar una solicitud POST enviando un objeto
        /// </summary>
        /// <param name="objeto"> object a enviar, si es una solicitud con parametros el objeto no debe incluir arrays </param>
        /// <param name="nombres"> array de strings con los nombres de los parametros (deben ser igual a los del objeto) </param>
        /// <param name="url_base"> url base, Ej: http://www.ejemplo.com </param>
        /// <param name="url"> direccion url de la consulta. Ej: /solicitud/prueba/1 </param>
        /// <param name="token"> token de seguridad si es requerido </param>
        /// <returns> string con la respuesta de la api </returns>
        public async Task<string> SolicitudPostObject(object objeto, string[] nombres, string url_base, string url, string token)
        {
            string respuesta = "";
            try
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri(url_base) };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (token != null) client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);

                HttpResponseMessage response = (nombres != null) ? await client.PostAsync(url, getParametros(objeto, nombres))
                                                                 : (objeto != null) ? await client.PostAsJsonAsync(url, objeto) 
                                                                                    : await client.PostAsync(url, null);
                
                respuesta = await response.Content.ReadAsStringAsync();
            }
            catch (Exception f)
            {
                respuesta = f.Message;
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo para realizar una solicitud PUT enviando un objeto
        /// </summary>
        /// <param name="objeto"> object a enviar, si es una solicitud con parametros el objeto no debe incluir arrays </param>
        /// <param name="nombres"> array de strings con los nombres de los parametros (deben ser igual a los del objeto) </param>
        /// <param name="url_base"> url base. Ej: http://www.ejemplo.com </param>
        /// <param name="url"> direccion url de la consulta. Ej: /solicitud/prueba/1 </param>
        /// <param name="token"> token de seguridad si es requerido </param>
        /// <returns> string con la respuesta de la api </returns>
        public async Task<string> SolicitudPutObject(object objeto, string[] nombres, string url_base, string url, string token)
        {
            string respuesta = "";
            try
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri(url_base) };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (token != null)client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
                HttpResponseMessage response = (nombres != null) ? await client.PutAsync(url, getParametros(objeto, nombres)) 
                                                                 : (objeto != null) ? await client.PutAsJsonAsync(url, objeto) 
                                                                                    : await client.PutAsync(url, null);
                respuesta = await response.Content.ReadAsStringAsync();
            }
            catch (Exception f)
            {
                respuesta = f.Message;
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo para realizar una solicitud GET
        /// </summary>
        /// <param name="url_base"> url base, Ej: http://www.ejemplo.com </param>
        /// <param name="url"> direccion url de la consulta. Ej: /solicitud/prueba/1 </param>
        /// <param name="token"> token de seguridad si es requerido </param>
        /// <returns> string con la respuesta de la api </returns>
        public async Task<string> SolicitudGet(string url_base, string url, string token)
        {
            string respuesta = "";
            try
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri(url_base) };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (token != null) client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
                HttpResponseMessage response = await client.GetAsync(url);
                respuesta = await response.Content.ReadAsStringAsync();
            }
            catch (Exception f)
            {
                respuesta = f.Message;
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo para realizar una solicitud DELETE
        /// </summary>
        /// <param name="url_base"> url base, Ej: http://www.ejemplo.com </param>
        /// <param name="url"> direccion url de la consulta. Ej: /solicitud/prueba/1 </param>
        /// <param name="token"> token de seguridad si es requerido </param>
        /// <returns> string con la respuesta de la api </returns>
        public async Task<string> SolicitudDelete(string url_base, string url, string token)
        {
            string respuesta = "";
            try
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri(url_base) };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (token != null) client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
                HttpResponseMessage response = await client.DeleteAsync(url);
                respuesta = await response.Content.ReadAsStringAsync();
            }
            catch (Exception f)
            {
                respuesta = f.Message;
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo para obtener los parametros de un objeto generico
        /// </summary>
        /// <param name="o"></param>
        /// <param name="nombres"></param>
        /// <returns>FormUrlEncodedContent</returns>
        private FormUrlEncodedContent getParametros(object o, string[] nombres)
        {
            List<KeyValuePair<string, string>> keys = new List<KeyValuePair<string, string>>();

            foreach (string nombre in nombres)
            {
                PropertyInfo propertyInfo = o.GetType().GetProperty(nombre);

                string text = (string)(propertyInfo.GetValue(o, null));

                keys.Add(new KeyValuePair<string, string>(nombre, text));
            }

            return new FormUrlEncodedContent(keys);
        }

        /// <summary>
        /// Metodo para desencriptar un token
        /// </summary>
        /// <param name="token"> string con el token </param>
        /// <param name="key"> string con la key </param>
        /// <returns> string con el token desencriptado </returns>
        public static string desencriptarToken(string token, string key)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                return decoder.Decode(token, key, verify: true);
            }
            catch (TokenExpiredException)
            {
                return "El Token expiro";
            }
            catch (SignatureVerificationException)
            {
                return "La firma del token es invalida";
            }
        }
    }
}
